using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // volumeSlider is a UI element

public class SoundManager : MonoBehaviour
{
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        // Check if saved data
        // PlayerPrefs: Stores and accesses player preferences between game sessions.
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1); // volume 100%
            Load();
        }

        else
        {
            Load();
        }  
    }

   // Change volume
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value; // ex. Game volume is 50%, when slider volume 0,5
        Save(); // save data
    }

    // Save data with PlayerPrefs, set.
    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    // Load with saved data PlayerPrefs, get.
    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        AudioListener.volume = volumeSlider.value;
    }
}
