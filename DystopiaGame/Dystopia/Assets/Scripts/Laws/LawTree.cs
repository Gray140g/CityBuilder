using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LawTree : MonoBehaviour
{
    public LawDisplay currentLaw;

    [SerializeField] private TextMeshProUGUI nameDisplay;
    [SerializeField] private TextMeshProUGUI descDisplay;
    [SerializeField] private Image imageDisplay;
    [SerializeField] private Button unlockButton;

    public void OnClick()
    {
        nameDisplay.text = currentLaw.law.lawName;
        descDisplay.text = currentLaw.law.desc;
        imageDisplay.sprite = currentLaw.law.icon;

        if(currentLaw.parentIsUnlocked)
        {
            unlockButton.interactable = true;
        }
        else
        {
            unlockButton.interactable = false;
        }
    }

    public void Unlock()
    {
        currentLaw.OnUnlock();
    }
}
