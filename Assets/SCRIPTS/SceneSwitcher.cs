using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;
    }
    public void backMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void playLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void playLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void playLevel3()
    {
        SceneManager.LoadScene(3);
    }
}
