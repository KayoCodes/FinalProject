using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Rendering;
using TMPro;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour

{
    [Header("Audio")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;
    [Header("Resolution")]
    [SerializeField] TMP_Dropdown resDropdown;
    [SerializeField] Toggle fullscreenToggle;
    [Header("Characters")]
    [SerializeField] Toggle char1Toggle;
    [SerializeField] Toggle char2Toggle;

    Resolution [] resolutions;
   [SerializeField] Canvas canvas;
    void Start()
    {
       masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume"); 
       musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
       sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");

       int characterNum = PlayerPrefs.GetInt("character");
       if(characterNum == 1 || characterNum == 0){
        char1Toggle.isOn = true;
        PlayerPrefs.SetInt("character",1);

       }else if(characterNum == 2){
        char2Toggle.isOn = true;
       }


       
       
       GetResolutionOptions();
       resDropdown.value = PlayerPrefs.GetInt("Resolution");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void char1toggle(){
       char2Toggle.isOn = !char1Toggle.isOn;
       if(char1Toggle.isOn){
        PlayerPrefs.SetInt("character",1);
       }else{
        PlayerPrefs.SetInt("character",2);
       }
      
    }
    public void char2toggle(){
        char1Toggle.isOn = !char2Toggle.isOn;
        if(char1Toggle.isOn){
        PlayerPrefs.SetInt("character",1);
       }else{
        PlayerPrefs.SetInt("character",2);
       }

    }

    float ConvertToDec(float sliderValue){
        return Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20;
    }
    void GetResolutionOptions(){
        resDropdown.ClearOptions();
        resolutions = Screen.resolutions;
        for(int i =0; i < resolutions.Length; i ++){
            TMP_Dropdown.OptionData newOption;
            newOption = new TMP_Dropdown.OptionData(resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString());
            resDropdown.options.Add(newOption);
;        }
    }
    public void ChooseResolution(){
        Screen.SetResolution(resolutions[resDropdown.value].width,resolutions[resDropdown.value].height,fullscreenToggle.isOn);
        PlayerPrefs.SetInt("Resolution",resDropdown.value);
        PlayerPrefs.SetInt("toggle",1 );
    }

    public void SetMasterVolume( ){
    audioMixer.SetFloat("MasterVolume",ConvertToDec(masterVolumeSlider.value));
    PlayerPrefs.SetFloat("MasterVolume",masterVolumeSlider.value);
    }
    public void SetMusicVolume( ){
    audioMixer.SetFloat("MusicVolume",ConvertToDec(musicVolumeSlider.value));
    PlayerPrefs.SetFloat("MusicVolume",musicVolumeSlider.value);
    }
    public void SetSFXVolume( ){
    audioMixer.SetFloat("SFXVolume",ConvertToDec(sfxVolumeSlider.value));
    PlayerPrefs.SetFloat("sfxVolume",sfxVolumeSlider.value);
    }
    public void OpenOptions(){
        canvas.enabled = true;

    }

    public void CloseOptions(){
        canvas.enabled = false;
    }

   
}
