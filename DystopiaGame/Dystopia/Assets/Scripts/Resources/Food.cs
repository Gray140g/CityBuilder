using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private Population pop;
    [SerializeField] private PopStats stats;
    [SerializeField] private LossText lossAnim;

    public int food;
    public int hourlyFood;
    public float maxWorkers;
    public float workers;
    public int eat;
    private int gain;

    public void AddFood()
    {
        float gainFloat = (workers + 1) / (maxWorkers + 1) * hourlyFood;
        gain = Mathf.RoundToInt(gainFloat);
        food += gain;
    }

    public void Eat()
    {
        eat = pop.totalElites * 2 + pop.totalPeasants;

        stats.EliteEat(food);
    }
}
