using System.Collections.Generic;
using UnityEngine;

public class BuildingLoad : MonoBehaviour
{
    [SerializeField] private GameObject[] buildingPrefabs;

    public List<int> placedBuildingIDs = new List<int>();
    public List<float> xCoords = new List<float>();
    public List<float> yCoords = new List<float>();
    public List<float> zCoords = new List<float>();

    public void OnLoad()
    {
        for (int i = 0; i < placedBuildingIDs.Count; i++)
        {
            Vector3 pos = new Vector3();
            pos.x = xCoords[i];
            pos.y = yCoords[i];
            pos.z = zCoords[i];

            Instantiate(buildingPrefabs[placedBuildingIDs[i]], pos, Quaternion.identity, null);
        }
    }

    public void Save()
    {
        SaveSystem.Save(this);
    }

    public void Load()
    {
        SaveData data = SaveSystem.Load();

        for (int i = 0; i < data.placedBuildingIDs.Length; i++)
        {
            placedBuildingIDs.Add(data.placedBuildingIDs[i]);
            xCoords.Add(data.xCoords[i]);
            yCoords.Add(data.yCoords[i]);
            zCoords.Add(data.zCoords[i]);
        }

        OnLoad();
    }
}