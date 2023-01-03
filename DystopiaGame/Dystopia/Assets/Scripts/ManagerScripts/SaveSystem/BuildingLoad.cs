using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingLoad
{
    public List<int> placedBuildingIDs = new List<int>();
    public List<Vector3> coords = new List<Vector3>();
}