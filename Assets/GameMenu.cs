using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject gamePanel;

    public void Play()
    {
        SceneManager.LoadScene("save 1");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void Back()
    {
        creditsPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}