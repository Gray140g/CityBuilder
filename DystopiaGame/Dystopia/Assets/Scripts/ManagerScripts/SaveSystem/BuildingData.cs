using UnityEngine;

public class BuildingData : MonoBehaviour
{
    private BuildGroups groups;

    public Workers workers;
    [SerializeField] private Rotation outlineRotation;
    [SerializeField] private ColliderRotate colliderRotate;

    public int prefabID;
    public Vector3 pos;

    public bool hasWorkers;
    public int currentWorkers = 0;

    public int rotateIndex;
    public bool hasColliderRotate;

    public int index = -1;
    [HideInInspector] public float indexFloat = -1;

    private void Start()
    {
        groups = GameObject.FindGameObjectWithTag("BuildingManager").GetComponent<BuildGroups>();
    }

    public void OnPlace()
    {
        pos = gameObject.transform.position;

        rotateIndex = gameObject.GetComponent<Rotation>().i;

        SaveData.current.buildings.placedBuildingIDs.Add(prefabID);
        SaveData.current.buildings.coords.Add(pos);
        SaveData.current.buildings.buildingHasWorkers.Add(hasWorkers);
        SaveData.current.buildings.currentWorkers.Add(currentWorkers);
        SaveData.current.buildings.rotateIndex.Add(rotateIndex);
        SaveData.current.buildings.hasColliderRotate.Add(hasColliderRotate);

        for (int i = 0; i < SaveData.current.buildings.coords.Count; i++)
        {
            if(pos == SaveData.current.buildings.coords[i])
            {
                index = i;
                indexFloat = index;
            }
        }
    }

    public void OnDestroy()
    {
        if(index >= 0)
        {
            SaveData.current.buildings.placedBuildingIDs.Remove(prefabID);
            SaveData.current.buildings.coords.RemoveAt(index);
            SaveData.current.buildings.buildingHasWorkers.RemoveAt(index);
            SaveData.current.buildings.currentWorkers.RemoveAt(index);
            SaveData.current.buildings.rotateIndex.RemoveAt(index);
            SaveData.current.buildings.hasColliderRotate.RemoveAt(index);

            for (int i = index; i < groups.allBuildings.Count; i++)
            {
                BuildingData data = groups.allBuildings[i].GetComponent<BuildingData>();
                data.CheckIndex(index);
            }

            Destroy(gameObject);
        }
    }

    public void OnMove()
    {
        pos = gameObject.transform.position;

        rotateIndex = gameObject.GetComponent<Rotation>().i;

        SaveData.current.buildings.coords[index] = pos;
        SaveData.current.buildings.rotateIndex[index] = rotateIndex;
    }

    public void WorkerChange()
    {
        currentWorkers = workers.workers;
        SaveData.current.buildings.currentWorkers[index] = currentWorkers;
    }

    public void LoadRotations()
    {
        Rotation rotate = gameObject.GetComponent<Rotation>();
        rotate.i = rotateIndex;
        rotate.ShowSprite();

        outlineRotation.i = rotateIndex;
        outlineRotation.ShowSprite();

        if(hasColliderRotate)
        {
            colliderRotate.ShowCollider();
        }
    }

    public void CheckIndex(int start)
    {
        if(index > start)
        {
            indexFloat -= .5f;
            index = (int)indexFloat;
        }
    }
}
