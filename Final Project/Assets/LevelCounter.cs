using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCounter : MonoBehaviour

{
   
   [SerializeField] private TextMeshProUGUI levelCounterText;
   [SerializeField] int levelnumber;
    public static  LevelCounter level;
    int levelTotal= 0;

    void Awake(){
        if(level != null){
            Destroy(this.gameObject);
        }
        level= this;
    }
    void Start()
    {
        levelCounterText.text = "Level " + levelnumber.ToString();
    }

    // Update is called once per frame
   public void RegisterLevel(){
       levelTotal +=1;
       levelCounterText.text = "Level " + levelTotal.ToString();
    }
}
