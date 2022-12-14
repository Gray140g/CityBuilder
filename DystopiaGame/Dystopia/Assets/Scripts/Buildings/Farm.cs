using UnityEngine;

public class Farm : MonoBehaviour
{
    private Population pop;
    private Food food;
    [SerializeField] private Building parentBuilding;
    [SerializeField] private Workers workStation;

    [SerializeField] private int newFood;

    private void Start()
    {
        food = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Food>();
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
        food.dailyFood += newFood;
        food.maxWorkers += workStation.maxWorkers;
        workStation.thisClick.maxVal = workStation.maxWorkers;
        parentBuilding.justPlaced = false;
    }

    private void OnDestroy()
    {
        if(!parentBuilding.beingPlaced)
        {
            food.workers -= workStation.workers;
            food.maxWorkers -= workStation.maxWorkers;
            pop.workingPeasants -= workStation.workers;
            food.dailyFood -= newFood;
        }
    }
}
