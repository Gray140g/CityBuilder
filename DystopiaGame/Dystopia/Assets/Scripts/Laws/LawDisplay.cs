using UnityEngine;
using UnityEngine.UI;

public class LawDisplay : MonoBehaviour
{
    [SerializeField] private TimeManager manager;
    [SerializeField] private LawTree tree;
    public LawScriptableObject law;
    [SerializeField] private LawDisplay[] childButtons;

    public bool parentIsUnlocked = false;

    private void Start()
    {
        law.content = GameObject.FindGameObjectWithTag("BalanceManager").GetComponent<PeasantContent>();

        if(manager.testing)
        {
            law.unlocked = false;
        }
    }

    public void OnClick()
    {
        tree.currentLaw = this;
        tree.OnClick();
    }

    public void OnUnlock()
    {
        if(!law.unlocked)
        {
            law.onUnlock();

            foreach (LawDisplay button in childButtons)
            {
                button.parentIsUnlocked = true;
            }

            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
