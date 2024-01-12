using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoMenu : MonoBehaviour
{
    public void BackBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
