using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileThrower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float speed = 10;
    float canonPosY; 
    int canonPosX = -30;
    Vector3 canonPosVec;
    void Start(){
        canonPosY = this.transform.position.y;
        if(this.transform.rotation.z == 0){
                canonPosX = -30;
              }else{
                canonPosX = 30;
                Debug.Log("True");
              }
        canonPosVec = new Vector3(canonPosX,canonPosY,0);
        Debug.Log(this.transform.position);
        SpawnProjectiles();
    }

    public void Launch(Vector3 targetPos){
         GameObject newProjectile = Instantiate(projectilePrefab, transform.position,Quaternion.identity);
      newProjectile.transform.rotation = Quaternion.LookRotation(transform.forward,targetPos - transform.position );
      newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.up *speed;
       Destroy(newProjectile,4.5f);
    }
    void SpawnProjectiles(){
        StartCoroutine(SpawnProjectilesRoutine());
        IEnumerator SpawnProjectilesRoutine(){
            while (true)
            {
              yield return new WaitForSeconds(2);
              
              Launch(canonPosVec);
            }
        }
    }
}
