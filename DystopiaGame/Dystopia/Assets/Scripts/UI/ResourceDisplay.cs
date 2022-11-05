using UnityEngine;
using TMPro;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] private Population pop;
    [SerializeField] private Food food;
    [SerializeField] private Materials mat;

    [SerializeField] private TextMeshProUGUI eliteText;
    [SerializeField] private TextMeshProUGUI peasantText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private TextMeshProUGUI materialsText;
    [SerializeField] private TextMeshProUGUI ignoranceText;

    private void Update()
    {
        if(pop.totalElites < 1000)
        {
            eliteText.text = pop.totalElites.ToString();
        }
        else if(pop.totalElites >= 1000 && pop.totalElites < 1000000)
        {
            float eliteDisplay = (float) (pop.totalElites - 50) / 1000;
            eliteText.text = eliteDisplay.ToString("f1") + "k";
        }
        else
        {
            float eliteDisplay = (float) (pop.totalElites - 50000) / 1000000;
            eliteText.text = eliteDisplay.ToString("f1") + "m";
        }

        if (pop.totalPeasants < 1000)
        {
            peasantText.text = pop.totalPeasants.ToString();
        }
        else if (pop.totalPeasants >= 1000 && pop.totalPeasants < 1000000)
        {
            float peasantDisplay = (float)(pop.totalPeasants - 50) / 1000;
            peasantText.text = peasantDisplay.ToString("f1") + "k";
        }
        else
        {
            float peasantDisplay = (float)(pop.totalPeasants - 50000) / 1000000;
            peasantText.text = peasantDisplay.ToString("f1") + "m";
        }

        if (food.food < 1000)
        {
            foodText.text = food.food.ToString();
        }
        else if (food.food >= 1000 && food.food < 1000000)
        {
            float foodDisplay = (float)(food.food - 50) / 1000;
            foodText.text = foodDisplay.ToString("f1") + "k";
        }
        else
        {
            float foodDisplay = (float)(food.food - 50000) / 1000000;
            foodText.text = foodDisplay.ToString("f1") + "m";
        }

        if (mat.materials < 1000)
        {
            materialsText.text = mat.materials.ToString();
            ignoranceText.text = mat.materials.ToString();
        }
        else if (mat.materials >= 1000 && mat.materials < 1000000)
        {
            float matDisplay = (float)(mat.materials - 50) / 1000;
            materialsText.text = matDisplay.ToString("f1") + "k";
            ignoranceText.text = matDisplay.ToString("f1") + "k";
        }
        else
        {
            float matDisplay = (float)(mat.materials - 50000) / 1000000;
            materialsText.text = matDisplay.ToString("f1") + "m";
            ignoranceText.text = matDisplay.ToString("f1") + "m";
        }
    }
}
