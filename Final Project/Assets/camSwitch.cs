using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject cam1;
    [SerializeField] GameObject cam2;

    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F)){
        cam2.SetActive(true);
        cam1.SetActive(false);
       }
    }
}
