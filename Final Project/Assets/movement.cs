using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour

{
    Rigidbody2D rb;
    bool paused = true;
    [SerializeField] float speed;
    void Start()
    {
        speed = 8f;
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Position "+ this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 input = Vector3.zero;
        if(Input.GetKey(KeyCode.A)){
        input.x += -1;
       }

        if(Input.GetKey(KeyCode.D)){
        input.x += 1;
       }
       if(Input.GetKey(KeyCode.S)){
        input.y += -1;
       }

        if(Input.GetKey(KeyCode.W)){
        input.y += 1;
       }

       if (Input.GetKey(KeyCode.Space)){
        // if(paused){
        //     timeManager.singleton.Pause();
        //     paused = false;
        // }else{
        //     timeManager.singleton.ResetTime();
        //     paused = true;
        // }
        timeManager.singleton.Pause();
       }

       if(Input.GetKey(KeyCode.R)){
        timeManager.singleton.ResetTime();  
       }
       MoveCreatureRB(input);
    }
     public void MoveCreatureRB(Vector3 direction){
        rb.velocity = direction * speed;
    }
}
