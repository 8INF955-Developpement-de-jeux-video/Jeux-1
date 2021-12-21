using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    int max = 0;
    public void GameOver()
    {
        GameOverScreen.setup(max);
    }
    
}
