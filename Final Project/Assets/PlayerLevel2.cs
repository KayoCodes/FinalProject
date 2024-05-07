using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLevel2 : MonoBehaviour
{
    // Start is called before the first frame update
      [SerializeField] float speed = 8f;
    [SerializeField] Vector3 homePosition = new Vector3(-17,8,0);
    [SerializeField] GameObject applePrefab;
   
    [SerializeField] string scenename;
    [SerializeField] GameObject ParticleSystemObj;
    GameObject apple1;
    GameObject apple2;
    GameObject apple3;

    BoxCollider2D a1;
    BoxCollider2D a2;
    BoxCollider2D a3;

    SpriteRenderer s1;
    SpriteRenderer s2;
    SpriteRenderer s3;
    
   [SerializeField] Vector3 apple1Location = new Vector3(-10.1f,-4.38f,0);
    [SerializeField] Vector3 apple2Location = new Vector3(-3.91f, 1.82f,0);
    [SerializeField] Vector3 apple3Location = new Vector3(6.8f, -2.91f,0);
    public bool islevel2;
    
    public int Captured = 0;
    Rigidbody2D rb;
   
    void Start()
    {
        if (PlayerPrefs.GetInt("level") == 2){
            islevel2 = true;
        }else{
            islevel2 = false;
        }
        apple1 = Instantiate(applePrefab,apple1Location,Quaternion.identity);
        apple2 = Instantiate(applePrefab, apple2Location,Quaternion.identity);
        apple3 = Instantiate(applePrefab, apple3Location,Quaternion.identity);
        a1 =apple1.GetComponent<BoxCollider2D>();
        a2 =apple2.GetComponent<BoxCollider2D>();
        a3=apple3.GetComponent<BoxCollider2D>();

        s1 =apple1.GetComponent<SpriteRenderer>();
        s2=apple2.GetComponent<SpriteRenderer>();
        s3 =apple3.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Respawn(){
        this.transform.position = new Vector3(-17,8,0);
        this.GetComponent<BoxCollider2D>().enabled= true;
        this.GetComponent<SpriteRenderer>().enabled = true;
        a1.enabled = true;
        a2.enabled = true;
        a3.enabled = true;
        s1.enabled = true;
        s2.enabled = true;
        s3.enabled = true;
        
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "projectile"){
            GetComponent<AudioSource>().Play();
            this.GetComponent<BoxCollider2D>().enabled= false;
        GameObject particle = Instantiate(ParticleSystemObj,this.transform.position,this.transform.rotation);
        ParticleSystem ps = particle.GetComponent<ParticleSystem>();
        var emissions = ps.emission;
        emissions.enabled = true; 
        this.GetComponent<SpriteRenderer>().enabled = false;
         Invoke("Respawn", 1.0f);
         Destroy(particle,1.25f);

         Captured = 0;
        }

        if (other.gameObject.tag == "Apple"){
            other.GetComponent<BoxCollider2D>().enabled= false;
            other.GetComponent<SpriteRenderer>().enabled= false;
            Captured +=1;
        }
        if(other.gameObject.tag=="complete"){
            Debug.Log("complete");
        }

        if(other.gameObject.tag=="complete" && Captured == 3){
            PlayerPrefs.SetInt("deaths",deathCounter.deaths.deathTotal);
            if(islevel2){
                PlayerPrefs.SetInt("level",3);
            SceneManager.LoadScene("Level3");
            }else{
                SceneManager.LoadScene("WinScreen");
            }
            
        }
        
    }
}
