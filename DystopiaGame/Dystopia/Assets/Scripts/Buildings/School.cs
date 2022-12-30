using UnityEngine;

public class School : MonoBehaviour
{
    private Population pop;
    private Ignorance ign;
    [SerializeField] private Building parentBuilding;
    [SerializeField] private Workers workStation;

    [SerializeField] private int newIgnorance;

    private void Start()
    {
        ign = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Ignorance>();
        pop = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Population>();
    }

    private void Update()
    {
        if (parentBuilding.justPlaced)
        {
            OnPlace();
        }

        if (parentBuilding.destroyed)
        {
            OnDestroy();
        }
    }

    public void OnPlace()
    {
        ign.hourlyIgnorance += newIgnorance;
        ign.maxWorkers += workStation.maxWorkers;
        workStation.thisClick.maxVal = workStation.maxWorkers;
        parentBuilding.justPlaced = false;
    }

    private void OnDestroy()
    {
        if (!parentBuilding.beingPlaced)
        {
            ign.workers -= workStation.workers;
            ign.maxWorkers -= workStation.maxWorkers;
            pop.workingPeasants -= workStation.workers;
            ign.hourlyIgnorance -= newIgnorance;
        }
    }
}