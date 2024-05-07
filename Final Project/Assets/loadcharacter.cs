using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadcharacter : MonoBehaviour
{
    [SerializeField] GameObject[] characterPrefabs;

    void Start()
    {
        int characterNum = PlayerPrefs.GetInt("character");
        GameObject prefab = characterPrefabs[characterNum -1];
        GameObject clone = Instantiate(prefab, new Vector3(-17,8,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
