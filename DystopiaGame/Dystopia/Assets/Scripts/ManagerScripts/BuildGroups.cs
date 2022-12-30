using System.Collections.Generic;
using UnityEngine;

public class BuildGroups : MonoBehaviour
{
    public List<string> allBuildingNames = new List<string>();

    public List<GameObject> peasantHousingBuildings = new List<GameObject>();
    public List<GameObject> eliteHousingBuildings = new List<GameObject>();
    public List<GameObject> materialGatheringBuildings = new List<GameObject>();
    public List<GameObject> foodGatheringBuildings = new List<GameObject>();
    public List<GameObject> eliteWorkBuildings = new List<GameObject>();
    public List<GameObject> otherBuildings = new List<GameObject>();

    public void AddToList(GameObject building, int type)
    {
        if(type == 1)
        {
            peasantHousingBuildings.Add(building);
        }
        else if(type == 2)
        {
            eliteHousingBuildings.Add(building);
        }
        else if(type == 3)
        {
            materialGatheringBuildings.Add(building);
        }
        else if(type == 4)
        {
            foodGatheringBuildings.Add(building);
        }
        else if (type == 5)
        {
            eliteWorkBuildings.Add(building);
        }
        else
        {
            otherBuildings.Add(building);
        }

        allBuildingNames.Add(building.GetComponent<Building>().buildingName);
    }

    public void RemoveFromList(GameObject building, int type)
    {
        if (type == 1)
        {
            peasantHousingBuildings.Remove(building);
        }
        else if (type == 2)
        {
            eliteHousingBuildings.Remove(building);
        }
        else if (type == 3)
        {
            materialGatheringBuildings.Remove(building);
        }
        else if (type == 4)
        {
            foodGatheringBuildings.Remove(building);
        }
        else if (type == 5)
        {
            eliteWorkBuildings.Remove(building);
        }
        else
        {
            otherBuildings.Remove(building);
        }

        allBuildingNames.Remove(building.GetComponent<Building>().buildingName);
    }
}
