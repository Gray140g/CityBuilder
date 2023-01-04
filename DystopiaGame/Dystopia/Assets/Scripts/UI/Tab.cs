using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tab : MonoBehaviour
{
    [SerializeField] private Image thisTab;
    [SerializeField] private GameObject thisTabObject;
    [SerializeField] private GameObject thisMenu;
    [SerializeField] private Image[] otherTabs;
    [SerializeField] private GameObject[] otherTabsObject;
    [SerializeField] private GameObject[] otherMenus;
    [SerializeField] private GameObject[] sideMenus;

    [SerializeField] private TextMeshProUGUI menuName;

    [SerializeField] private Color color;

    public void Clicked(string n)
    {
        menuName.text = n;
        thisTab.color = color;
        thisMenu.SetActive(true);
        thisTabObject.GetComponent<Image>().color = Color.white;

        foreach (Image tab in otherTabs)
        {
            tab.color = Color.white;
        }

        foreach (GameObject tab in otherTabsObject)
        {
            tab.GetComponent<Image>().color = Color.black;
        }

        foreach (GameObject menu in otherMenus)
        {
            menu.SetActive(false);
        }
    }

    public void OpenBuildMenu(string n)
    {
        thisTabObject.SetActive(true);
        menuName.text = n;

        foreach (GameObject tab in otherTabsObject)
        {
            tab.SetActive(true);
        }

        foreach (GameObject menu in sideMenus)
        {
            menu.SetActive(false);
        }
    }

    public void ExitBuildMenu()
    {
        thisTabObject.SetActive(false);

        foreach (GameObject tab in otherTabsObject)
        {
            tab.SetActive(false);
        }

        foreach (GameObject menu in otherMenus)
        {
            menu.SetActive(false);
        }
    }
}
