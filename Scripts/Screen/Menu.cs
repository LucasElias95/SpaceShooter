using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject page1;

    [SerializeField]
    private GameObject page2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        page1.SetActive(false);
        page2.SetActive(false);
    }
    public void NewGame()
    {
        Debug.Log("Botão clicado");
        // Carrega a cena 
        SceneManager.LoadScene("Fase01");
    }
}
