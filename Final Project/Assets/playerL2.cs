using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerL2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 8f;
    [SerializeField] Vector3 homePosition = new Vector3(-17,8,0);
    [SerializeField] GameObject apple0Prefab;
    
    //[SerializeField] string scenename;
    GameObject apple1;
    GameObject apple2;
    
    GameObject apple3;
    Vector3 locA1;
    Vector3 locA2;
    Vector3 locA3;
    
    
    bool flagHit;
    bool appleRecieved;
    
    
    

    Rigidbody2D rb;
    void Start()
    {
         apple1 = GameObject.Find("Apple1");
         apple2 = GameObject.Find("apple2");
         apple3 = GameObject.Find("apple3");

         locA1 = apple1.transform.position;
         locA2 = apple2.transform.position;
         locA3 = apple3.transform.position;
         Debug.Log(locA1);
         Debug.Log(locA2);
         Debug.Log(locA3);
        flagHit = false;
        appleRecieved = false;
        this.transform.position = new Vector3(-17,8,0);
        rb = GetComponent<Rigidbody2D>();
       //SpriteRenderer sr = box.GetComponent<SpriteRenderer>();
       playerL2 Player = GetComponent<playerL2>();
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
        //GameObject newProjectile = Instantiate(applePrefab, new Vector3(-1.45f,0,0),Quaternion.identity); 
        //SceneManager.LoadScene(scenename);
        Destroy(apple1);
        Destroy(apple2);
        Destroy(apple3);
        GameObject newProjectile1 = Instantiate(apple0Prefab, locA1,Quaternion.identity); 
        GameObject newProjectile2 = Instantiate(apple0Prefab, locA2,Quaternion.identity); 
        GameObject newProjectile3 = Instantiate(apple0Prefab, locA3,Quaternion.identity); 
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
           // GameObject newProjectile = Instantiate(apple0Prefab, apple1,Quaternion.identity); 

       
        this.transform.position = homePosition;
    }
   }

  
}