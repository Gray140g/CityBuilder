using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] buildingPrefabs;

    public void Spawn()
    {
        for (int i = 0; i < SaveData.current.buildings.placedBuildingIDs.Count; i++)
        {
            Vector3 pos;
            pos = SaveData.current.buildings.coords[i];

            GameObject building = Instantiate(buildingPrefabs[SaveData.current.buildings.placedBuildingIDs[i]], pos, Quaternion.identity, null);
            BuildingData data = building.GetComponent<BuildingData>();

            data.index = i;
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
