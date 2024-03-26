using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 8f;
    [SerializeField] Vector3 homePosition = new Vector3(-17,8,0);
    [SerializeField] GameObject applePrefab;
    [SerializeField] string scenename;
    
    bool flagHit;
    bool appleRecieved;
    
    

    Rigidbody2D rb;
    void Start()
    {
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

    void OnTriggerEnter2D(Collider2D other){
    if(other.gameObject.tag == "complete" ){
        if(appleRecieved == true){
            flagHit = true;
        }
        
    }
    if(other.gameObject.tag == "projectile"){
        GameObject newProjectile = Instantiate(applePrefab, new Vector3(-1.45f,0,0),Quaternion.identity); 
        //SceneManager.LoadScene(scenename);
        flagHit = false;
        appleRecieved = false;

    }
    if(other.gameObject.tag == "Apple"){
        appleRecieved = true;
        
        Destroy(other.gameObject);
    }
    if (flagHit && appleRecieved){
        SceneManager.LoadScene("Level2");
        
        LevelCounter.level.RegisterLevel();
        flagHit = false;
        appleRecieved = false;
            GameObject newProjectile = Instantiate(applePrefab, new Vector3(-1.45f,0,0),Quaternion.identity); 

       
        this.transform.position = homePosition;
    }
   }

  
}
