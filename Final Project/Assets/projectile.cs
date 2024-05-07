using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
    if(other.gameObject.tag == "character"){
        deathCounter.deaths.RegisterDeath();
        //  && other.GetComponent<player>() != null
       // Debug.Log("Hit");
       
        // other.transform.position = new Vector3(-17,8,0);
        
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
        Invoke("setActive4seconds",2.0f);
    }
   }

   void setActive4seconds(){
    this.gameObject.transform.position = new Vector3(-28f,5f,0f);
    this.gameObject.SetActive(true);
   }
}
