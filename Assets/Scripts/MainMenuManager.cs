using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Value difficulty;
    public void LoadGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    private void OnEnable()
    {
        difficulty.value = 0;
    }

}
