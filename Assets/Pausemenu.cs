using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    public static GamePause = false;

    public GameObject PausemenuUI;


    void Start()
    {
        PausemenuUI = GameObject.Find("Pausemenu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
            { Resume();
            } else
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        PausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
    }
    void Pause()
    {
        PausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
    }

    public void Menu()
    {
        Debug.Log('Main menu')
    }
    public voit Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
