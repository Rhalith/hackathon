using System.Collections;
using System.Collections.Generic;
using UnityEngine; using UnityEngine.SceneManagement;

public class MenuDirector : MonoBehaviour
{
    public GameObject Creditspart, MenuButtons, SettingsPart;
    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void Credits(string x)
    {
        if (x == "open")
        {
            MenuButtons.SetActive(false);
            Creditspart.SetActive(true);
        }
        else
        {
            MenuButtons.SetActive(true);
            Creditspart.SetActive(false);
        }

    }

    public void Settings(string x)
    {
        if (x == "open")
        {
            MenuButtons.SetActive(false);
            SettingsPart.SetActive(true);
        }
        else
        {
            MenuButtons.SetActive(true);
            SettingsPart.SetActive(false);
        }

    }
}
