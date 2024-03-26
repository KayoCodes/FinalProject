using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] playerL2 Player;
    [SerializeField] GameObject canon;
    projectileThrower ProjectileThrower;
    void Start()
    {
      ProjectileThrower = canon.GetComponent<projectileThrower>();  
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
       if(Input.GetKeyDown(KeyCode.E)){
        ProjectileThrower.Launch(new Vector3(-30,4,0));
       }

       Player.MoveCreatureTransform(input);
    }
}
