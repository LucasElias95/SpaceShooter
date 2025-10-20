using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
  public Text scoreText;
  public LifeBar lifeBar;
  public GameObject pause; //Se for Text deve receber pause.enable = false/true se for GameObject recebe o .SetActive()
  public bool isPause = false; 

  private PlayerShip player;

  void Start()
  {
    this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShip>();
    pause.SetActive(false);
  }
  
  void Update()
  {
    this.lifeBar.ShowLife(this.player.Lifes);
    this.scoreText.text = (ScoreController.Score + "x");
    Pause();
  }

  public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
            {
                Time.timeScale = 0f;      // Pausa o jogo
                pause.SetActive(true);     // Mostra o texto de pausa
                isPause = true;
            }
            else
            {
                Time.timeScale = 1f;      // Despausa o jogo
                pause.SetActive(false);    // Esconde o texto de pausa
                isPause = false;
            }
        }
    }
}
