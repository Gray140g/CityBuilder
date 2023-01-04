using UnityEngine;

public class Ignorance : MonoBehaviour
{
    [SerializeField] private Population pop;
    [SerializeField] private TechTree tree;

    public int ignorance;
    public int hourlyIgnorance;
    public float maxWorkers;
    public float workers;

    public void AddIgnorance()
    {
        float gainFloat = (workers + 1) / (maxWorkers + 1) * hourlyIgnorance;
        int gain = Mathf.RoundToInt(gainFloat);
        ignorance += gain;
        tree.CheckLowestAvailableCost();
    }
}
