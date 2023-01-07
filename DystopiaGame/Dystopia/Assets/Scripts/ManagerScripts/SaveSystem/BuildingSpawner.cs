using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] private BuildGroups groups;

    [SerializeField] private GameObject[] buildingPrefabs;

    private void Start()
    {
        OnLoad();
    }

    public void Spawn()
    {
        for (int i = 0; i < SaveData.current.buildings.placedBuildingIDs.Count; i++)
        {
            Vector3 pos;
            pos = SaveData.current.buildings.coords[i];

            GameObject building = Instantiate(buildingPrefabs[SaveData.current.buildings.placedBuildingIDs[i]], pos, Quaternion.identity, null);
            BuildingData data = building.GetComponent<BuildingData>();
            Building buildingScript = building.GetComponent<Building>();

            if(SaveData.current.buildings.buildingHasWorkers[i])
            {
                data.currentWorkers = SaveData.current.buildings.currentWorkers[i];
                if(data.workers != null)
                {
                    data.workers.workers = data.currentWorkers;
                }
            }

            data.pos = pos;

            data.rotateIndex = SaveData.current.buildings.rotateIndex[i];
            data.LoadRotations();

            groups.AddToList(building, buildingScript.typeInt);

            buildingScript.outline.SetActive(false);
            data.index = i;
            data.indexFloat = i;

            Debug.Log(i + ": " + SaveData.current.buildings.coords[i]);
        }
    }

    public void OnSave()
    {
        SaveSystem.Save("buildingsave", SaveData.current);
    }

    public void OnLoad()
    {
        SaveData.current = (SaveData)SaveSystem.Load(Application.persistentDataPath + "/saves/buildingsave.save");
        Spawn();
    }
}
