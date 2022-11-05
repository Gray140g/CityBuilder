using UnityEngine;

public class PoliceStation : MonoBehaviour
{
    private Population pop;
    private Crime crime;
    [SerializeField] private Building parentBuilding;
    [SerializeField] private Workers workStation;

    private void Start()
    {
        crime = GameObject.FindGameObjectWithTag("BalanceManager").GetComponent<Crime>();
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
        crime.maxPolice += workStation.maxWorkers;
        workStation.thisClick.maxVal = workStation.maxWorkers;
        parentBuilding.justPlaced = false;
    }

    private void OnDestroy()
    {
        crime.police -= workStation.workers;
        crime.maxPolice -= workStation.maxWorkers;
        pop.workingElites -= workStation.workers;
    }
}
