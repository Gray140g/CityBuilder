using UnityEngine;
using UnityEngine.UI;

public class MenuOpener : MonoBehaviour
{
    [SerializeField] private GameObject balanceBar;
    [SerializeField] private GameObject[] infoBars;
    [SerializeField] private Image balanceImage;
    [SerializeField] private Sprite[] buttonSprites;

    [SerializeField] private Color red;

    public bool buildIsOpen = false;
    public bool editIsOpen = false;
    public bool commandIsOpen = false;
    private bool balanceIsOpen = false;
    public bool inInfo = false;

    public void CloseBuild()
    {
        buildIsOpen = false;
    }

    public void CloseEdit()
    {
        editIsOpen = false;
    }

    public void OpenBalance()
    {
        if(balanceIsOpen)
        {
            balanceIsOpen = false;
            balanceBar.SetActive(false);
            balanceImage.sprite = buttonSprites[1];
            foreach (GameObject slider in infoBars)
            {
                slider.SetActive(true);
            }
        }
        else
        {
            balanceIsOpen = true;
            foreach (GameObject slider in infoBars)
            {
                slider.SetActive(false);
            }
            balanceBar.SetActive(true);
            balanceImage.sprite = buttonSprites[0];
        }
    }

    public void EnterInfo(string action)
    {
        if(action == "enter")
        {
            inInfo = true;
        }
        else
        {
            inInfo = false;
        }
    }
}
