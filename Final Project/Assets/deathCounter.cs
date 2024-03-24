using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class deathCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI deathCounterText;
    public static  deathCounter deaths;
    int deathTotal = 0;

    void Awake(){
        if(deaths != null){
            Destroy(this.gameObject);
        }
        deaths = this;
    }
     void Start(){
        deathCounterText.text = "Deaths " + deathTotal.ToString();
    }

    public void RegisterDeath(){
       deathTotal +=1;
       deathCounterText.text = "Deaths " + deathTotal.ToString();
    }
}
