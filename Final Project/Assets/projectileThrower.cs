using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class projectileThrower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float speed = 10;
    [SerializeField] float TimeTillRecycle;
    float canonPosY; 
    int canonPosX = -30;
    Vector3 canonPosVec;
    public Queue<GameObject> projectileList;
    public GameObject projectile;
   
    void Start(){
      projectileList = new Queue<GameObject>();
        canonPosY = this.transform.position.y;
        if(this.transform.rotation.z == 0){
                canonPosX = -30;
              }else{
                canonPosX = 30;
                //Debug.Log("True");
              }
        canonPosVec = new Vector3(canonPosX,canonPosY,0);
        // Debug.Log(this.transform.position);
        SpawnProjectiles();
        ClearProjectiles(projectileList);
    }
    
    public void Launch(Vector3 targetPos){
      if(projectile == null){
        Debug.Log("NULL");
      }
      if (this.gameObject == null){
        Debug.Log("GO NULL");
      }
      if(projectileList == null){
        Debug.Log("list null");
      }
      if(projectileList.Count > 5){
          projectile = projectileList.Dequeue();
          projectile.SetActive(true);
          projectile.GetComponent<Rigidbody2D>().velocity =  projectile.transform.up* speed;
          Debug.Log("Sent Count  " + projectileList.Count);
          projectileList.Enqueue(projectile);
          
      }else{
         GameObject newProjectile = Instantiate(projectilePrefab, transform.position,Quaternion.identity);
      newProjectile.transform.rotation = Quaternion.LookRotation(transform.forward,targetPos - transform.position );
      newProjectile.GetComponent<Rigidbody2D>().velocity = newProjectile.transform.up *speed;
      projectileList.Enqueue(newProjectile);
       Debug.Log("Enqueded");
      // collectProjectiles(newProjectile);
     
      }
      //Debug.Log(projectileList.Count);  
        //Destroy(newProjectile,4.5f);
    }

    public void collectProjectiles(GameObject proj){
      while(proj.transform.position.x - transform.position.x < 50){
        
      }
    //Debug.Log("Enqueded");
      projectileList.Enqueue(proj);
      }

      
    void ClearProjectiles(Queue<GameObject>lists){
      StartCoroutine(ClearProjectilesCo( lists));
      IEnumerator ClearProjectilesCo(Queue<GameObject> projlist){
        while(true){
           
          yield return new WaitForSeconds(TimeTillRecycle);
          Debug.Log("Count of proj "+ projlist.Count);
          foreach (GameObject item in projlist)
          {
            
            if(item.transform.position.x  < - 24 || item.transform.position.x > 24){
              item.transform.position = transform.position;
              item.SetActive(false);
            }
            
          }
         

        }
      }
    }
    void SpawnProjectiles(){
        StartCoroutine(SpawnProjectilesRoutine());
        IEnumerator SpawnProjectilesRoutine(){

            while (true)
            {
                Launch(canonPosVec);
              yield return new WaitForSeconds(1.5f);
              
              //Launch(canonPosVec);
            }
        }
    }
}
