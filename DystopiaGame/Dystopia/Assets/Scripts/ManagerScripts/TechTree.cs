using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TechTree : MonoBehaviour
{
    [SerializeField] private Button[] techTreeButtons;
    [SerializeField] private Button[] buildMenuButtons;
    [SerializeField] private int[] parentIndex;
    public bool[] isUnlocked;
    [SerializeField] private int[] costs;

    [SerializeField] private Sprite[] icons;
    [SerializeField] private string[] names;
    [SerializeField] private string[] descriptions;

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI buildName;
    [SerializeField] private TextMeshProUGUI desc;

    private int currentCost;
    private int currentIndex;

    [SerializeField] private Materials mat;

    private void Start()
    {
        CheckUnlocks();
    }

    public void CheckUnlocks()
    {
        for (int i = 0; i < isUnlocked.Length; i++)
        {
            if(isUnlocked[i] == true)
            {
                buildMenuButtons[i].interactable = true;
                techTreeButtons[i].interactable = false;
            }
            else
            {
                buildMenuButtons[i].interactable = false;
                techTreeButtons[i].interactable = true;
            }
        }
    }

    public void Unlock()
    {
        if(!isUnlocked[currentIndex])
        {
            if (parentIndex[currentIndex] == 100)
            {
                if (mat.materials >= currentCost)
                {
                    mat.materials -= currentCost;
                    isUnlocked[currentIndex] = true;
                    buildMenuButtons[currentIndex].interactable = true;
                    techTreeButtons[currentIndex].interactable = false;
                }
            }
            else if (isUnlocked[parentIndex[currentIndex]])
            {
                if (mat.materials >= currentCost)
                {
                    mat.materials -= currentCost;
                    isUnlocked[currentIndex] = true;
                    buildMenuButtons[currentIndex].interactable = true;
                    techTreeButtons[currentIndex].interactable = false;
                }
            }
        }
    }
    public void Click(int index)
    {
        currentIndex = index;
        currentCost = costs[index];
        icon.sprite = icons[index];
        buildName.text = names[index];
        desc.text = descriptions[index];
    }
}
