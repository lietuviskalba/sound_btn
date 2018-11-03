using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySound : MonoBehaviour {

    public GameObject soundBoard;
    SelectSoundByte selectSound;
    public Animator anim;
    public LayerMask buttonMask;

    void Start()
    {
        selectSound = soundBoard.GetComponent<SelectSoundByte>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(toMouse, out hit, buttonMask))
            {               
                anim.SetTrigger("press"); // Play the animation
                selectSound.GetSelectedSound().Play(); // play the sound            
            }            
        }  
    }

    
}
