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

    private void OnEnable()
    {
        difficulty.value = 0;
    }

}
