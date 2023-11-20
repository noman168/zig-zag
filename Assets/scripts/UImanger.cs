using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class UImanger : MonoBehaviour

{
    public GameObject[] characters;
    public int Character = 0;
    public GameObject maimenu_panel;
   public GameObject chrcter_panel;
    public string characterName;
    public string characterSprite;
    // Start is called before the first frame update
    
    public void Playbtn()
    {
        SceneManager.LoadSceneAsync(1);
       // maimenu_panel.SetActive(false);
       // chrcter_panel.SetActive(true);


    }
    public void chrbtn()
    {
        characters[PlayerPrefs.GetInt("character",Character)].SetActive(false);
        characters[Character].SetActive(true);

        chrcter_panel.SetActive(true);
        maimenu_panel.SetActive(false);
        

    }
    public void Backbtn()
    {
       
        chrcter_panel.SetActive(false);
        maimenu_panel.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void playselectbtn()
    {

        // SceneManager.LoadSceneAsync(1);
        // chrcter_panel.SetActive(false);
        // maimenu_panel.SetActive(true);
        //characters[].SetActive(false);

        PlayerPrefs.SetInt("character", Character);


    }

    public void NextCharacter()
    {
        for(int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }
        Character++;
        if (Character > 2)
        {
            Character = 0;
        
        }
        characters[Character].SetActive(true);
      // characters[PlayerPrefs.GetInt("character", Character)].SetActive(true);



        // Character = (Character + 1) % characters.Length;
    }
    public void previousCharacter()
    {
        for(int i = 0;i < characters.Length;i++)
        {
            characters[i].SetActive(false);
        }
       characters[Character].SetActive(false);
        Character--;
        if (Character < 0)
        {
            Character = 2;
        }
        characters[Character].SetActive(true);
       
    }
    
}