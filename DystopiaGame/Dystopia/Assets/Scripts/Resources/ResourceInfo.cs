using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resourceName;
    [SerializeField] private TextMeshProUGUI desc;
    [SerializeField] private Image icon;

    [SerializeField] private Sprite eliteSprite;
    [SerializeField] private Sprite peasantSprite;
    [SerializeField] private Sprite foodSprite;
    [SerializeField] private Sprite matSprite;

    [SerializeField] private Population pop;
    [SerializeField] private Food food;
    [SerializeField] private Materials mat;

    [SerializeField] private MenuOpener opener;

    public void OnClick(int type)
    {
        if(!opener.buildIsOpen)
        {
            if (type == 0)
            {
                resourceName.text = "Elites";
                icon.sprite = eliteSprite;
                desc.text = "Total Elites: " + pop.totalElites +
                    "\n-----------------------------------\nHoused: " + pop.housedElites + "\nHomeless: " + pop.homelessElites +
                    "\n-----------------------------------\nWorking: " + pop.workingElites + "\nUnemployed: " + (pop.totalElites - pop.workingElites);
            }
            else if (type == 1)
            {
                resourceName.text = "Peasants";
                icon.sprite = peasantSprite;
                desc.text = "Total Peasants: " + pop.totalPeasants +
                    "\n-----------------------------------\nHoused: " + pop.housedPeasants + "\nHomeless: " + pop.homelessPeasants +
                    "\n-----------------------------------\nWorking: " + pop.workingPeasants + "\nUnemployed: " + (pop.totalPeasants - pop.workingPeasants);
            }
            else if (type == 2)
            {
                resourceName.text = "Food";
                icon.sprite = foodSprite;
                desc.text = "Total Food: " + food.food + "\nDaily Gain: " + food.dailyFood + "\nConsumption: " + food.eat +
                    "\n-----------------------------------\nWorkers: " + food.workers + "\nMax Workers: " + food.maxWorkers;
            }
            else
            {
                resourceName.text = "Money";
                icon.sprite = matSprite;
                desc.text = "Total Money: " + mat.materials + "\nDaily Gain: " + mat.dailyMaterials +
                    "\n-----------------------------------\nWorkers: " + mat.workers + "\nMax Workers: " + mat.maxWorkers;
            }
        }
    }
}
