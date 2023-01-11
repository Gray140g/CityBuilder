using UnityEngine;

public class ResourceSave : MonoBehaviour
{
    [SerializeField] private Population pop;
    [SerializeField] private Food food;
    [SerializeField] private Materials mat;
    [SerializeField] private Propaganda prop;
    [SerializeField] private Ignorance ign;
    [SerializeField] private Influence inf;
    [SerializeField] private PopStats popStats;
    [SerializeField] private PeasantContent content;
    [SerializeField] private Calendar cal;

    private void Start()
    {
        OnLoad();

        if(pop.totalPeasants == 0 && pop.totalElites == 0 && food.food == 0 && mat.materials == 0)
        {
            pop.totalPeasants = 50;
            pop.homelessPeasants = 50;
            pop.totalElites = 25;
            pop.homelessElites = 25;
            food.food = 240;
            mat.materials = 200;
        }
    }

    public void OnSave()
    {
        SaveData.current.resources.peasantPop = pop.totalPeasants;
        SaveData.current.resources.housedPeasants = pop.housedPeasants;
        SaveData.current.resources.workingPeasants = pop.workingPeasants;
        SaveData.current.resources.availablePeasantHousing = pop.availablePeasantHousing;
        SaveData.current.resources.totalPeasantHousing = pop.totalPeasantHousing;

        SaveData.current.resources.elitePop = pop.totalElites;
        SaveData.current.resources.housedElites = pop.housedElites;
        SaveData.current.resources.workingElites = pop.workingElites;
        SaveData.current.resources.availableEliteHousing = pop.availableEliteHousing;
        SaveData.current.resources.totalEliteHousing = pop.totalEliteHousing;

        SaveData.current.resources.food = food.food;
        SaveData.current.resources.money = mat.materials;
        SaveData.current.resources.propaganda = prop.propAmount;
        SaveData.current.resources.ignorance = ign.ignorance;
        SaveData.current.resources.influence = inf.influence;

        SaveData.current.resources.peasantHungerLevels = popStats.peasantHungerLevels;
        SaveData.current.resources.eliteHungerLevels = popStats.eliteHungerLevels;

        SaveData.current.resources.balance = content.balance;
        SaveData.current.resources.happiness = content.happiness;
        SaveData.current.resources.fear = content.fear;
        SaveData.current.resources.patriotism = content.patriotism;

        SaveData.current.resources.day = cal.day;
        SaveData.current.resources.month = cal.currentIndex;
        SaveData.current.resources.year = cal.year;
        SaveData.current.resources.hour = cal.hour;
        SaveData.current.resources.min = cal.min;

        SaveSystem.Save("resourcesave", SaveData.current);
    }

    public void OnLoad()
    {
        SaveData.current = (SaveData)SaveSystem.Load(Application.persistentDataPath + "/saves/resourcesave.save");

        pop.totalPeasants = SaveData.current.resources.peasantPop;
        pop.housedPeasants = SaveData.current.resources.housedPeasants;
        pop.homelessPeasants = pop.totalPeasants - pop.housedElites;
        pop.workingPeasants = SaveData.current.resources.workingPeasants;
        pop.totalPeasantHousing = SaveData.current.resources.totalPeasantHousing;
        pop.availablePeasantHousing = SaveData.current.resources.availablePeasantHousing;

        pop.totalElites = SaveData.current.resources.elitePop;
        pop.housedElites = SaveData.current.resources.housedElites;
        pop.homelessElites = pop.totalElites - pop.housedElites;
        pop.workingElites = SaveData.current.resources.workingElites;
        pop.totalEliteHousing = SaveData.current.resources.totalEliteHousing;
        pop.availableEliteHousing = SaveData.current.resources.availableEliteHousing;

        food.food = SaveData.current.resources.food;
        mat.materials = SaveData.current.resources.money;
        prop.propAmount = SaveData.current.resources.propaganda;
        ign.ignorance = SaveData.current.resources.ignorance;
        inf.influence = SaveData.current.resources.influence;

        popStats.peasantHungerLevels = SaveData.current.resources.peasantHungerLevels;
        popStats.eliteHungerLevels = SaveData.current.resources.eliteHungerLevels;

        content.balance = SaveData.current.resources.balance;
        content.happiness = SaveData.current.resources.happiness;
        content.fear = SaveData.current.resources.fear;
        content.patriotism = SaveData.current.resources.patriotism;

        cal.day = SaveData.current.resources.day;
        cal.currentIndex = SaveData.current.resources.month;
        cal.year = SaveData.current.resources.year;
        cal.hour = SaveData.current.resources.hour;
        cal.min = SaveData.current.resources.min;

        content.LoadBarValues();
    }
}
