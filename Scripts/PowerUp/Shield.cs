using UnityEngine;

public class Shield : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Quantidade de dano que pode ser recebido peo escudo, antes de ser desativado")]
    private int totalProtection;
    /// <sumary>
    /// Qunatidade atual de dano que o escudo ainda pode receber
    /// </sumary>
    
    private int actualProtection;

    public void Enable()
    {
        this.actualProtection = this.totalProtection;
        this.gameObject.SetActive(true);
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

    public bool Active{
        get{
            return this.gameObject.activeSelf;
        }
    }

    public void Damaged()
    {
        this.actualProtection--;
        if (this.actualProtection <=0)
        {
            Disable();
        }
    }
}
