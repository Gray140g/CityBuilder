using UnityEngine;

public class Mine : MonoBehaviour
{
    private Population pop;
    private Materials mat;
    [SerializeField] private Building parentBuilding;
    [SerializeField] private Workers workStation;

    [SerializeField] private int newMaterials;

    private void Start()
    {
        mat = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Materials>();
        pop = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Population>();
    }

    private void Update()
    {
        if (parentBuilding.justPlaced)
        {
            OnPlace();
        }

        if(parentBuilding.destroyed)
        {
            OnDestroy();
        }
    }

    public void OnPlace()
    {
        mat.hourlyMaterials += newMaterials;
        mat.maxWorkers += workStation.maxWorkers;
        workStation.thisClick.maxVal = workStation.maxWorkers;
        parentBuilding.justPlaced = false;
    }

    private void OnDestroy()
    {
        if(!parentBuilding.beingPlaced)
        {
            mat.workers -= workStation.workers;
            mat.maxWorkers -= workStation.maxWorkers;
            pop.workingPeasants -= workStation.workers;
            mat.hourlyMaterials -= newMaterials;
        }
    }
}
