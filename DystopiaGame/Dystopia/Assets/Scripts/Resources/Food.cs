using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private Population pop;
    [SerializeField] LossText lossAnim;

    public int food;
    public int dailyFood;
    public float maxWorkers;
    public float workers;
    public int eat;
    private int gain;

    public void AddFood()
    {
        float gainFloat = (workers + 1) / (maxWorkers + 1) * dailyFood;
        gain = Mathf.RoundToInt(gainFloat);
        food += gain;
    }

    public void Eat()
    {
        eat = pop.totalElites * 2 + pop.totalPeasants;

        if(food >= pop.totalElites * 2)
        {
            food -= pop.totalElites * 2;
            pop.AddElites(Mathf.RoundToInt(food / 128));
            lossAnim.StartAnimation(Mathf.RoundToInt(food / 128), 0);

            if (food >= pop.totalPeasants)
            {
                food -= pop.totalPeasants;
                pop.AddPeasants(Mathf.RoundToInt(food / 64));
                lossAnim.StartAnimation(Mathf.RoundToInt(food / 64), 1);
                lossAnim.StartAnimation(gain - eat, 2);
            }
            else
            {
                int dif = pop.totalPeasants - food;
                int kill = Mathf.RoundToInt(dif * .01f);

                if (kill == 0 && pop.totalPeasants > 0)
                {
                    kill = 1;
                }

                pop.KillPeasants(kill);
                lossAnim.StartAnimation(-kill, 1);
                lossAnim.StartAnimation(-food, 2);
                food = 0;
            }
        }
        else
        {
            int dif = pop.totalElites - food / 2;
            int kill = Mathf.RoundToInt(dif * .01f);
            int peasantDif = pop.totalPeasants - food;
            int peasantKill = Mathf.RoundToInt(peasantDif * .01f);

            if(kill == 0 && pop.totalElites > 0)
            {
                kill = 1;
            }

            if(peasantKill == 0 && pop.totalPeasants > 0)
            {
                peasantKill = 1;
            }

            pop.KillElites(kill);
            pop.KillPeasants(peasantKill);
            lossAnim.StartAnimation(-kill, 0);
            lossAnim.StartAnimation(-peasantKill, 1);
            lossAnim.StartAnimation(-food, 2);
            food = 0;
        }
    }
}
