using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void NewGame()
    {
        Debug.Log("Botão clicado");
        // Carrega a cena 
        SceneManager.LoadScene("Fase01");
    }
}
