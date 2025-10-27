using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnableDisable : MonoBehaviour
{
    public GameObject activeButton;
    public GameObject[] enable_;
    public GameObject[] disable_;

    void Start()
    {
        Button btnMenu = activeButton.GetComponent<Button>();
        btnMenu.onClick.AddListener(() => StartCoroutine(OnClickWithDelay()));
    }

    IEnumerator OnClickWithDelay()
    {
        yield return new WaitForSeconds(1f); // Espera 1 segundo

        // Verifica se pelo menos um dos disable_ está ativo
        bool algumAtivo = false;
        foreach (GameObject obj in disable_)
        {
            if (obj.activeSelf)
            {
                algumAtivo = true;
                break;
            }
        }

        if (algumAtivo)
        {
            // Desativa todos de disable_ e ativa todos de enable_
            foreach (GameObject obj in disable_)
                obj.SetActive(false);

            foreach (GameObject obj in enable_)
                obj.SetActive(true);
        }
        else
        {
            // Ativa todos de disable_
            foreach (GameObject obj in disable_)
                obj.SetActive(true);
        }
    }
}
