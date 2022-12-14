using UnityEngine;

public class Factory : MonoBehaviour
{
    private Population pop;
    private Materials mat;
    private Food food;
    private BuildGroups grouping;

    [SerializeField] private Building parentBuilding;
    [SerializeField] private Workers workStation;
    [SerializeField] private BuildClick click;

    [SerializeField] private int newMaterials;
    [SerializeField] private int newFood;
    private int type;

    private void Start()
    {
        mat = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Materials>();
        food  = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Food>();
        pop = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Population>();
        grouping = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<BuildGroups>();
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

        if(click.typeChange)
        {
            ChangeType(click.typeForChange);
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
            pop.workingPeasants -= workStation.workers;

            if(type == 0)
            {
                mat.hourlyMaterials -= newMaterials;
                mat.workers -= workStation.workers;
                mat.maxWorkers -= workStation.maxWorkers;
            }
            else
            {
                food.hourlyFood -= newFood;
                food.workers -= workStation.workers;
                food.maxWorkers -= workStation.maxWorkers;
            }
        }
    }

    public void ChangeType(int newType)
    {
        if(newType != type)
        {
            type = newType;

            if(type == 0)
            {
                workStation.type = 0;

                food.workers -= workStation.workers;
                food.maxWorkers -= workStation.maxWorkers;
                food.hourlyFood -= newFood;

                mat.hourlyMaterials += newMaterials;
                mat.maxWorkers += workStation.maxWorkers;
                mat.workers += workStation.workers;

                grouping.RemoveFromList(gameObject, 4);
                grouping.AddToList(gameObject, 3);
            }
            else
            {
                mat.workers -= workStation.workers;
                mat.maxWorkers -= workStation.maxWorkers;
                mat.hourlyMaterials -= newMaterials;

                food.hourlyFood += newFood;
                food.maxWorkers += workStation.maxWorkers;
                food.workers += workStation.workers;

                grouping.RemoveFromList(gameObject, 3);
                grouping.AddToList(gameObject, 4);
            }
        }

        click.typeChange = false;
    }
}
