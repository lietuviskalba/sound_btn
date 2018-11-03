using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSoundByte : MonoBehaviour {

    private AudioSource currSound;
    private AudioSource[] sounds;

    public Text btnName;

    public GameObject soundButtons;
    public GameObject backButton;
    public GameObject tint;
    public GameObject txtTint;

    void Start () {
        // Store all the sounds from the game obj sound board childrens
        sounds = GetComponentsInChildren<AudioSource>();
        currSound = sounds[0]; //Set a default sound just in case
        backButton.SetActive(false);
        txtTint.SetActive(false);
    }

    public void SelectSound(int soundNr)
    {
        currSound = sounds[soundNr]; //assign current sound
        SetButtonNameOnTint(currSound);

        //Do prepartion when button pressed
        soundButtons.SetActive(false);
        backButton.SetActive(true);
        tint.SetActive(false);
        txtTint.SetActive(true);
    }

    public void ReturnToMenu()
    {
        //Preperations when returning to menu
        soundButtons.SetActive(true);
        backButton.SetActive(false);
        tint.SetActive(true);
        txtTint.SetActive(false);
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
