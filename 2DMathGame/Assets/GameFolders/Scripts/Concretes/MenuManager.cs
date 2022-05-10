using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NextMenu()
    {
        SceneManager.LoadScene("SecondMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
