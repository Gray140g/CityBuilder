using UnityEngine;
using TMPro;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] private Population pop;
    [SerializeField] private Food food;
    [SerializeField] private Materials mat;
    [SerializeField] private Ignorance ign;
    [SerializeField] private Influence inf;

    [SerializeField] private TextMeshProUGUI eliteText;
    [SerializeField] private TextMeshProUGUI peasantText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private TextMeshProUGUI materialsText;
    [SerializeField] private TextMeshProUGUI ignoranceText;
    [SerializeField] private TextMeshProUGUI influenceText;

    private void Update()
    {
        PopDisplay();
        FoodDisplay();
        MatDisplay();
        IgnDisplay();
        //InfDisplay();
    }

    private void PopDisplay()
    {
        if (pop.totalElites < 1000)
        {
            eliteText.text = pop.totalElites.ToString();
        }
        else if (pop.totalElites >= 1000 && pop.totalElites < 1000000)
        {
            float eliteDisplay = (float)(pop.totalElites - 50) / 1000;
            eliteText.text = eliteDisplay.ToString("f1") + "k";
        }
        else
        {
            float eliteDisplay = (float)(pop.totalElites - 50000) / 1000000;
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
    }

    private void FoodDisplay()
    {
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
    }

    private void MatDisplay()
    {
        if (mat.materials < 1000)
        {
            materialsText.text = mat.materials.ToString();
        }
        else if (mat.materials >= 1000 && mat.materials < 1000000)
        {
            float matDisplay = (float)(mat.materials - 50) / 1000;
            materialsText.text = matDisplay.ToString("f1") + "k";
        }
        else
        {
            float matDisplay = (float)(mat.materials - 50000) / 1000000;
            materialsText.text = matDisplay.ToString("f1") + "m";
        }
    }

    private void IgnDisplay()
    {
        if (ign.ignorance < 1000)
        {
            ignoranceText.text = ign.ignorance.ToString();
        }
        else if (ign.ignorance >= 1000 && ign.ignorance < 1000000)
        {
            float ignDisplay = (float)(ign.ignorance - 50) / 1000;
            ignoranceText.text = ignDisplay.ToString("f1") + "k";
        }
        else
        {
            float ignDisplay = (float)(ign.ignorance - 50000) / 1000000;
            ignoranceText.text = ignDisplay.ToString("f1") + "m";
        }
    }

    private void InfDisplay()
    {
        if (inf.influence < 1000)
        {
            influenceText.text = inf.influence.ToString();
        }
        else if (inf.influence >= 1000 && inf.influence < 1000000)
        {
            float infDisplay = (float)(inf.influence - 50) / 1000;
            influenceText.text = infDisplay.ToString("f1") + "k";
        }
        else
        {
            float infDisplay = (float)(inf.influence - 50000) / 1000000;
            influenceText.text = infDisplay.ToString("f1") + "m";
        }
    }
}
