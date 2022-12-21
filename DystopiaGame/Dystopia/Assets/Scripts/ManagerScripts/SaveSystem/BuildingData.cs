using UnityEngine;

public class BuildingData : MonoBehaviour
{
    private BuildingLoad buildLoad;

    public int prefabID;

    public float x;
    public float y;
    public float z;

    private void Start()
    {
        buildLoad = GameObject.FindGameObjectWithTag("GameManager").GetComponent<BuildingLoad>();
    }

    public void OnPlace()
    {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        z = gameObject.transform.position.z;

        buildLoad.placedBuildingIDs.Add(prefabID);
        buildLoad.xCoords.Add(x);
        buildLoad.yCoords.Add(y);
        buildLoad.zCoords.Add(z);
    }
}
