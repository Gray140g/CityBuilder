using UnityEngine;

public class ResourceSave : MonoBehaviour
{
    [SerializeField] private Population pop;
    [SerializeField] private Food food;
    [SerializeField] private Materials mat;
    [SerializeField] private Propaganda prop;
    [SerializeField] private Ignorance ign;
    [SerializeField] private Influence inf;
    [SerializeField] private PeasantContent content;

    private void Start()
    {
        OnLoad();
    }

    public void OnSave()
    {
        SaveData.current.resources.peasantPop = pop.totalPeasants;
        SaveData.current.resources.elitePop = pop.totalElites;
        SaveData.current.resources.food = food.food;
        SaveData.current.resources.money = mat.materials;
        SaveData.current.resources.propaganda = prop.propAmount;
        SaveData.current.resources.ignorance = ign.ignorance;
        SaveData.current.resources.influence = inf.influence;

        SaveData.current.resources.balance = content.balance;
        SaveData.current.resources.happiness = content.happiness;
        SaveData.current.resources.fear = content.fear;
        SaveData.current.resources.patriotism = content.patriotism;

        SaveSystem.Save("resourcesave", SaveData.current);
    }

    public void OnLoad()
    {
        SaveData.current = (SaveData)SaveSystem.Load(Application.persistentDataPath + "/saves/resourcesave.save");

        pop.totalPeasants = SaveData.current.resources.peasantPop;
        pop.totalElites = SaveData.current.resources.elitePop;
        food.food = SaveData.current.resources.food;
        mat.materials = SaveData.current.resources.money;
        prop.propAmount = SaveData.current.resources.propaganda;
        ign.ignorance = SaveData.current.resources.ignorance;
        inf.influence = SaveData.current.resources.influence;

        content.balance = SaveData.current.resources.balance;
        content.happiness = SaveData.current.resources.happiness;
        content.fear = SaveData.current.resources.fear;
        content.patriotism = SaveData.current.resources.patriotism;

        content.LoadBarValues();
    }
}
