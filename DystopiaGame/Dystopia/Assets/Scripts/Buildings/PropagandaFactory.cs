using UnityEngine;

public class PropagandaFactory : MonoBehaviour
{
    private Population pop;
    private Propaganda prop;
    [SerializeField] private Building parentBuilding;
    [SerializeField] private Workers workStation;

    [SerializeField] private int newProp;

    private void Start()
    {
        prop = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Propaganda>();
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
        prop.dailyProp += newProp;
        prop.maxWorkers += workStation.maxWorkers;
        workStation.thisClick.maxVal = workStation.maxWorkers;
        parentBuilding.justPlaced = false;
    }

    private void OnDestroy()
    {
        prop.workers -= workStation.workers;
        prop.maxWorkers -= workStation.maxWorkers;
        pop.workingPeasants -= workStation.workers;
        prop.dailyProp -= newProp;
    }
}
