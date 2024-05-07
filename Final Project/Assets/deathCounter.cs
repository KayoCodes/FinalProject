using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class deathCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI deathCounterText;
    public static  deathCounter deaths;
    public int deathTotal = 0;
    

    void Awake(){
         if(deaths != null){
           
            
            Destroy(this.gameObject);
           
        }
        deathTotal = PlayerPrefs.GetInt("deaths", 0);
        deaths =this;
    }
     void Start(){
        Debug.Log("Start");
        
        deathCounterText.text = "Deaths " + deathTotal.ToString();
    }

    public void RegisterDeath(){
       deathTotal +=1;
       deathCounterText.text = "Deaths " + deathTotal.ToString();
    }
}
