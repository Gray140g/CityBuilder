using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private Population pop;

    public int food;
    public int dailyFood;
    public float maxWorkers;
    public float workers;
    public int eat;

    public void AddFood()
    {
        float gainFloat = (workers + 1) / (maxWorkers + 1) * dailyFood;
        int gain = Mathf.RoundToInt(gainFloat);
        food += gain;
    }

    public void Eat()
    {
        eat = pop.totalElites * 2 + pop.totalPeasants;

        if(food >= pop.totalElites * 2)
        {
            food -= pop.totalElites * 2;
        }
        else
        {
            int dif = pop.totalElites - food / 2;
            int kill = Mathf.RoundToInt(dif * .01f);
            int peasantDif = pop.totalPeasants - food;
            int peasantKill = Mathf.RoundToInt(peasantDif * .01f);

            if(kill == 0)
            {
                kill = 1;
            }

            if(peasantKill == 0)
            {
                peasantKill = 1;
            }

            pop.KillElites(kill);
            pop.KillPeasants(peasantKill);
            food = 0;
        }

        if(food >= pop.totalPeasants)
        {
            food -= pop.totalPeasants;
        }
        else
        {
            int dif = pop.totalPeasants - food;
            int kill = Mathf.RoundToInt(dif * .01f);

            if (kill == 0)
            {
                kill = 1;
            }

            pop.KillPeasants(kill);
            food = 0;
        }
    }
}
