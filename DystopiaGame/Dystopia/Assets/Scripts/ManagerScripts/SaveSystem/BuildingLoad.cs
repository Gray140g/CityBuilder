using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingLoad
{
    public List<int> placedBuildingIDs = new List<int>();
    public List<Vector3> coords = new List<Vector3>();
    public List<bool> buildingHasWorkers = new List<bool>();
    public List<int> currentWorkers = new List<int>();
    public List<int> rotateIndex = new List<int>();
    public List<bool> hasColliderRotate = new List<bool>();
}