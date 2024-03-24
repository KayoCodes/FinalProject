using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 8f;
    [SerializeField] Vector3 homePosition = new Vector3(0,-5,0);

    Rigidbody2D rb;
    void Start()
    {
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
}
