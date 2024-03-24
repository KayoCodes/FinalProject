using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
    if(other.gameObject.tag == "character" && other.GetComponent<player>() != null){
        deathCounter.deaths.RegisterDeath();
        Debug.Log("Hit");
        other.transform.position = new Vector3(-17,8,0);
        
        Destroy(this.gameObject);
    }
   }
}
