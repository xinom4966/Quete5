using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void TutoBtn()
    {
        SceneManager.LoadScene("TutoMenu");
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
}
