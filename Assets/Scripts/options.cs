using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options : MonoBehaviour
{
    public GameObject Panel;
    bool visible = false;

    public DropDown DResolution;

    public AudioSource audioSource;
    public Slider slider;
    public Text TxtVolume;

    void Update()
    {
        if (input.GetKeyDown(KeyCode.Escape))
        {
            visible = !visible;
            Panel.SetActive(visible);
        }
    }

    public void SetResolution()
    {
        switch(DResolution.value)
        {
            Case 0:
            Screen.SetResolution(640, 360, true);
            break;
            Case 1:
            Screen.SetResolution(1920, 1080, true);
            break;
        } 
    }

    public void sliderChanger()
    {
        audiosource.volume = slider.value;
        TxtVolume.text = "Volume" + (audiosource.volume * 100).ToString("00") + "%";
    }


}
