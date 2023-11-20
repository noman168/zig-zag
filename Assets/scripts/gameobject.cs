using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class gameobject : MonoBehaviour
{
    public GameObject[] characters;
   

    // Start is called before the first frame update
    void Awake()
    {
       
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }
        PlayerPrefs.GetInt("character");
        int a = PlayerPrefs.GetInt("character");
        characters[a].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
