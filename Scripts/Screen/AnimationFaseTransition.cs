using UnityEngine;
using TMPro;
public class AnimationFaseTransition : MonoBehaviour
{
    public delegate void FinishAnimationFaseTransitionDelegate();
    public FinishAnimationFaseTransitionDelegate FinishAnimationFaseTransition;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private Animator animator;

    private static AnimationFaseTransition instance;

    private void Awake()
    {
        instance = this;
        Hide();
    }

    public static AnimationFaseTransition Instance{
        get{
            return instance;
        }
    }

    public void Show(string nameFase )
    {
        this.gameObject.SetActive(true);
        this.text.text = nameFase;
        this.animator.Play("FaseTransition");
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void FinishAnimation()
    {
        Hide();
        if (this.FinishAnimationFaseTransition != null)
        {
            this.FinishAnimationFaseTransition.Invoke();
        }
    }
}
