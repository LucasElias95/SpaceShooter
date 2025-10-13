using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
  public Text scoreText;
  public LifeBar lifeBar;
  public Text pause; //Text deve receber .enable = false/true
  public bool isPause = false; 

  private PlayerShip player;

  void Start()
  {
    this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShip>();
    pause.enabled = false;
  }
  
  void Update()
  {
    this.lifeBar.ShowLife(this.player.Lifes);
    this.scoreText.text = (ScoreController.Score + "x");
    Pause();
  }

   void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
            {
                Time.timeScale = 0f;      // Pausa o jogo
                pause.enabled = true;     // Mostra o texto de pausa
                isPause = true;
            }
            else
            {
                Time.timeScale = 1f;      // Despausa o jogo
                pause.enabled = false;    // Esconde o texto de pausa
                isPause = false;
            }
        }
    }
}
