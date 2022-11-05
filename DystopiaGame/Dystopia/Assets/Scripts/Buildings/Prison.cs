using UnityEngine;

public class Prison : MonoBehaviour
{
    private Crime crime;
    [SerializeField] Building parentBuilding;
    [SerializeField] private int rooms;

    private void Start()
    {
        crime = GameObject.FindGameObjectWithTag("BalanceManager").GetComponent<Crime>();
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
        crime.prisonCells += rooms;
        parentBuilding.justPlaced = false;
    }

    private void OnDestroy()
    {
        crime.prisonCells -= rooms;
        crime.SubtractPrisoners();
    }
}
