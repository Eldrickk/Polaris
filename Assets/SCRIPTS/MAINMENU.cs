using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAINMENU : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}