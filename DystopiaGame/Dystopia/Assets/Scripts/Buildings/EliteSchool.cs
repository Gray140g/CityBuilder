using UnityEngine;

public class EliteSchool : MonoBehaviour
{
    private Population pop;
    private Influence inf;
    [SerializeField] private Building parentBuilding;
    [SerializeField] private Workers workStation;

    [SerializeField] private int newInfluence;

    private void Start()
    {
        inf = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Influence>();
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
        inf.hourlyInfluence += newInfluence;
        inf.maxWorkers += workStation.maxWorkers;
        workStation.thisClick.maxVal = workStation.maxWorkers;
        parentBuilding.justPlaced = false;
    }

    private void OnDestroy()
    {
        if (!parentBuilding.beingPlaced)
        {
            inf.workers -= workStation.workers;
            inf.maxWorkers -= workStation.maxWorkers;
            pop.workingPeasants -= workStation.workers;
            inf.hourlyInfluence -= newInfluence;
        }
    }
}
