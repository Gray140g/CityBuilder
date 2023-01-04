using System.Collections;
using UnityEngine;
using TMPro;

public class LossText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] lossTexts;
    //[SerializeField] private Animator[] anim;
    [SerializeField] private Deactivate[] deactivation;

    [SerializeField] private Color green;
    [SerializeField] private Color red;

    public void StartAnimation(int amount, int type)
    {
        if (amount > 0)
        {
            lossTexts[type].text = "+" + amount;
            lossTexts[type].color = green;
            lossTexts[type].gameObject.SetActive(true);
            //anim[type].SetTrigger("ChangeAmount");
            deactivation[type].StartCoroutine("Inactivate");
        }
        else if (amount < 0)
        {
            lossTexts[type].text = amount.ToString();
            lossTexts[type].color = red;
            lossTexts[type].gameObject.SetActive(true);
            //anim[type].SetTrigger("ChangeAmount");
            deactivation[type].StartCoroutine("Inactivate");
        }
    }
}
