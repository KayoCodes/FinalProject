using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
   
    //public Animator transitionAnim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(){
        SceneManager.LoadScene("FirstLevel");
       // screen.FadeToColor("Movement");


    }
    public void Quit(){
        Application.Quit();
    }
}
