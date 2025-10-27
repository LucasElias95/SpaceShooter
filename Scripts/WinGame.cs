using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public Text scoreText;
  
    public void Show()
    {
        this.gameObject.SetActive(true);
        this.scoreText.text = (ScoreController.Score + "x");
        Time.timeScale = 0;
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Fase01");
    }
}
