using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static timeManager singleton;
    void Awake(){
        if(singleton != null){
            Destroy(this.gameObject);
        }else{
            singleton = this;
        }
    }
    void Start()
    {
        
    }

    public void Pause(){
        Time.timeScale = 0.0000001f;
        Time.fixedDeltaTime = 0.02f * 0.000001f;
    }
    public void ResetTime(){
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.01667f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
