using UnityEngine;

public class Influence : MonoBehaviour
{
    [SerializeField] private Population pop;

    public int influence;
    public int hourlyInfluence;
    public float maxWorkers;
    public float workers;

    public void AddInfluence()
    {
        float gainFloat = (workers + 1) / (maxWorkers + 1) * hourlyInfluence;
        int gain = Mathf.RoundToInt(gainFloat);
        influence += gain;
    }
}
