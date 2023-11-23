using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource ButtonClick;
    //public AudioSource RunestoneReveal;
    

    public void PlayButton()
    {
        ButtonClick.Play();
    }


    /*public void PlayRunestoneReveal()
    {
        RunestoneReveal.Play();
    }
    */
}
