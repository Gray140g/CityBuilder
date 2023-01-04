using UnityEngine;

public class Housing : MonoBehaviour
{
    [SerializeField] private Building parentBuilding;
    private Population pop;
    [SerializeField] private bool isElite = false;
    [SerializeField] private int rooms;

    private void Start()
    {
        pop = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Population>();
    }

    private void Update()
    {
        if(parentBuilding.justPlaced)
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
        pop.AddHousing(rooms, isElite);
        parentBuilding.justPlaced = false;
    }

    private void OnDestroy()
    {
        if(!parentBuilding.beingPlaced)
        {
            if (isElite)
            {
                pop.RemoveEliteHousing(rooms);
            }
            else
            {
                pop.RemovePeasantHousing(rooms);
            }
        }
    }
}
