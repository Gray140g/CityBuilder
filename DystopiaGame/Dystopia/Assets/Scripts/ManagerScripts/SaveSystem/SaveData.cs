using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    public int[] placedBuildingIDs;
    public float[] xCoords;
    public float[] yCoords;
    public float[] zCoords;

    public SaveData(BuildingLoad buildLoad)
    {
        placedBuildingIDs = buildLoad.placedBuildingIDs.ToArray();
        xCoords = buildLoad.xCoords.ToArray();
        yCoords = buildLoad.yCoords.ToArray();
        zCoords = buildLoad.zCoords.ToArray();
    }
}
