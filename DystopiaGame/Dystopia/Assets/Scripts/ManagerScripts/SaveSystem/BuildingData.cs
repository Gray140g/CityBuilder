using UnityEngine;

public class BuildingData : MonoBehaviour
{
    public int prefabID;
    public Vector3 pos;

    public int index = -1;

    public void OnPlace()
    {
        pos = gameObject.transform.position;

        SaveData.current.buildings.placedBuildingIDs.Add(prefabID);
        SaveData.current.buildings.coords.Add(pos);

        for (int i = 0; i < SaveData.current.buildings.coords.Count; i++)
        {
            if(index < 0)
            {
                if (SaveData.current.buildings.coords[i] == pos)
                {
                    index = i;
                }
            }
        }
    }

    public void OnDestroy()
    {
        SaveData.current.buildings.placedBuildingIDs.RemoveAt(index);
        SaveData.current.buildings.coords.RemoveAt(index);
    }

    public void OnMove()
    {
        pos = gameObject.transform.position;

        SaveData.current.buildings.coords[index] = pos;
    }
}
