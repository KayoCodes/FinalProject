using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewProjectileShooter : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] GameObject projectilePrefab;
    [SerializeField] float speed = 10;
    [SerializeField] int canonPosX = -30;
    [SerializeField] float canonPosY = -7.46f;
    [SerializeField] float CanonWaitTime =1.5f;
    [SerializeField] float TimeTillRecycle;
    public Queue<GameObject> projectileList;
    [SerializeField] int projlimit = 10;
    [SerializeField] int projcount = 0;
    public GameObject projectile;
    //float canonPosY; 
    //int canonPosX = -30;
    Vector3 canonPosVec;
    void Start(){
        projectileList = new Queue<GameObject>();
        canonPosVec = new Vector3(canonPosX,canonPosY,0);
        // Debug.Log(this.transform.position);
        SpawnProjectiles();
        ClearProjectiles(projectileList);
    }

    // public void Launch(Vector3 targetPos){
    //      GameObject newProjectile = Instantiate(projectilePrefab, transform.position,Quaternion.identity);
    //   newProjectile.transform.rotation = Quaternion.LookRotation(transform.forward,targetPos - transform.position );
    //   newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.up *speed;
    //    Destroy(newProjectile,4.5f);
    // }

    public void Launch(Vector3 targetPos){
      if(projectileList.Count > 8 ){
          projectile = projectileList.Dequeue();
          projectile.SetActive(true);
          projectile.GetComponent<Rigidbody2D>().velocity =  projectile.transform.up* speed;
          //Debug.Log("Sent Location  " + projectile.transform.position);
          projectileList.Enqueue(projectile);
          
      }else{
         GameObject newProjectile = Instantiate(projectilePrefab, transform.position,Quaternion.identity);
        
      newProjectile.transform.rotation = Quaternion.LookRotation(transform.forward,targetPos - transform.position );
      newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.up *speed;
      projectileList.Enqueue(newProjectile);
      // Debug.Log("Enqueded");
      // collectProjectiles(newProjectile);
     
      }
      //Debug.Log(projectileList.Count);  
        //Destroy(newProjectile,4.5f);
    }
    void SpawnProjectiles(){
        StartCoroutine(SpawnProjectilesRoutine());
        IEnumerator SpawnProjectilesRoutine(){

            while (true)
            {
                Launch(canonPosVec);
              yield return new WaitForSeconds(CanonWaitTime);
              
              //Launch(canonPosVec);
            }
        }
    }

    void ClearProjectiles(Queue<GameObject>lists){
      StartCoroutine(ClearProjectilesCo( lists));
      IEnumerator ClearProjectilesCo(Queue<GameObject> projlist){
        while(true){
           
          yield return new WaitForSeconds(TimeTillRecycle);
          Debug.Log("Count of proj "+ projlist.Count);
          foreach (GameObject item in projlist)
          {
            
            if(item.transform.position.x  < -24 || item.transform.position.x > 24){
              item.transform.position = transform.position;
              item.SetActive(false);
            }
            
          }
         

        }
      }
    }
}
