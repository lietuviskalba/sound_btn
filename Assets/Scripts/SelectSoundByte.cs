using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSoundByte : MonoBehaviour {

    private AudioSource currSound;
    private AudioSource[] sounds;

    public Text btnName;

    private GameObject[] menuUI;
    private GameObject[] ingameMenuUI;

    public GameObject soundButtons;
    public GameObject backButton;
    public GameObject tint;
    public GameObject txtTint;


    void Start () {      
        sounds = GetComponentsInChildren<AudioSource>(); // Store all the sounds
        currSound = sounds[0]; //Set a default sound just in case

        menuUI = GameObject.FindGameObjectsWithTag("Menu");
        ingameMenuUI = GameObject.FindGameObjectsWithTag("IngameMenu");

        SwitchMenuUI(false, "gameMenu"); // turn off the game menu at start
    }

    public void SwitchMenuUI(bool onOff, string type)
    {
        // check wich menu it is and activte it acordingly
        if (type.Equals("gameMenu"))
        {
            foreach (GameObject menu in ingameMenuUI) { menu.SetActive(onOff); }
        }
        else if (type.Equals("startMenu"))
        {
            foreach (GameObject menu in menuUI) { menu.SetActive(onOff); }
        }       
    }

    public void SelectSound(int soundNr)
    {
        currSound = sounds[soundNr]; //assign current sound
        SetButtonNameOnTint(currSound);

        SwitchMenuUI(true, "gameMenu");
        SwitchMenuUI(false, "startMenu");

    }

    public void ReturnToMenu()
    {
        SwitchMenuUI(false, "gameMenu");
        SwitchMenuUI(true, "startMenu");
    }

    public void SetButtonNameOnTint(AudioSource audioName)
    {
        btnName = txtTint.GetComponentInChildren<Text>(); // get the txt compoentn from the panels child
        string name = audioName.ToString();
        string sortedName = "";

        //Sort out just the name of the button
        foreach (string word in name.Split(' '))
        {            
            if (word.Equals("sound")) {break; }

            sortedName += word + " ";
        }

        btnName.text = sortedName;
    }

    public void RandomSound()
    {
        int countButtons = 0;
        
        GameObject[] allSounds; // make an empty arr of objs
        allSounds = GameObject.FindGameObjectsWithTag("SoundBoardButtons"); // store with this tag

        foreach (GameObject sound in allSounds){countButtons++;} // inc the count

        int randSound = Random.Range(0, countButtons); // get rand value

        SelectSound(randSound);
    }
    public AudioSource GetSelectedSound()
    {
        return currSound;
    }
}
