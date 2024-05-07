using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 8f;
    [SerializeField] Vector3 homePosition = new Vector3(-17,8,0);
    [SerializeField] GameObject applePrefab;
    [SerializeField] string scenename;
    [SerializeField] GameObject ParticleSystemObj;
    GameObject apple;
    SpriteRenderer appleSR;
    BoxCollider2D appleBC;
   
    
     
    
    bool flagHit;
    bool appleRecieved;

    
    

    Rigidbody2D rb;
    void Awake(){
    PlayerPrefs.SetInt("deaths",0);
    
    }
    void Start()

    {
        apple = Instantiate(applePrefab, new Vector3(-1.45f,0,0),Quaternion.identity); 
        appleBC = apple.GetComponent<BoxCollider2D>();
        appleSR = apple.GetComponent<SpriteRenderer>();
        flagHit = false;
        appleRecieved = false;
        this.transform.position = new Vector3(-17,8,0);
        rb = GetComponent<Rigidbody2D>();
       //SpriteRenderer sr = box.GetComponent<SpriteRenderer>();
       player Player = GetComponent<player>();
       Player.speed = 15f;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveCreatureTransform(Vector3 direction){
        transform.position += direction *Time.deltaTime *speed;
    }
    public void Respawn(){
        this.transform.position = new Vector3(-17,8,0);
        this.GetComponent<BoxCollider2D>().enabled= true;
        this.GetComponent<SpriteRenderer>().enabled = true;
        appleSR.enabled = true;
        
    }

    void OnTriggerEnter2D(Collider2D other){
    if(other.gameObject.tag == "complete" ){
        if(appleRecieved == true){
            flagHit = true;
        }
        
    }

    
    if(other.gameObject.tag == "projectile"){
        
        
        this.GetComponent<BoxCollider2D>().enabled= false;
        GameObject particle = Instantiate(ParticleSystemObj,this.transform.position,this.transform.rotation);
        ParticleSystem ps = particle.GetComponent<ParticleSystem>();
        var emissions = ps.emission;
        emissions.enabled = true;
        this.GetComponent<SpriteRenderer>().enabled = false;
        
        GetComponent<AudioSource>().Play();
       
        Invoke("Respawn",1.0f);
       
       Destroy(particle,1.25f);
        
        //SceneManager.LoadScene(scenename);
        flagHit = false;
        appleRecieved = false;

    }
    if(other.gameObject.tag == "Apple"){
        appleRecieved = true;
        
        appleSR.enabled = false;
        
        
       
        
        
    }
    if (flagHit && appleRecieved){
        PlayerPrefs.SetInt("deaths",deathCounter.deaths.deathTotal);
        Debug.Log("Player.cs");
        PlayerPrefs.SetInt("level",2);
        SceneManager.LoadScene("Level2");
        
        
        
        
        LevelCounter.level.RegisterLevel();
        
        flagHit = false;
        appleRecieved = false;
            GameObject newProjectile = Instantiate(applePrefab, new Vector3(-1.45f,0,0),Quaternion.identity); 

       
        this.transform.position = homePosition;
    }
   }

  
}
