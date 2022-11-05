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
    }

    public void OnPlace()
    {
        pop.AddHousing(rooms, isElite);
        parentBuilding.justPlaced = false;
    }
}
