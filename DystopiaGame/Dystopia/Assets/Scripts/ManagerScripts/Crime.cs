using UnityEngine;

public class Crime : MonoBehaviour
{
    [SerializeField] private PeasantContent content;
    [SerializeField] private Population pop;

    public float crimeRate;
    public int police;
    public int maxPolice;
    public int prisoners;
    public int prisonCells;
    [SerializeField] private float minBal;

    public void GetCrime()
    {
        if(content.balance <= minBal)
        {
            crimeRate += (-content.balance + 100) / (float) pop.totalPeasants;
        }

        if(crimeRate > 0)
        {
            if(police > 0)
            {
                crimeRate -= (float)police / crimeRate;
            }
        }
        else if(crimeRate < 0)
        {
            crimeRate = 0;
        }

        if(crimeRate != 0)
        {
            pop.KillPeasants((int)crimeRate / 4);
        }


        AddPrisoners();

    }

    public void AddPrisoners()
    {
        if(police > 0 && crimeRate > 0)
        {
            float newPrisoners = (float)(pop.totalPeasants * crimeRate / police) + (Random.Range(0, 20) / 20);
            if (prisonCells - prisoners > 0)
            {
                prisoners += (int)newPrisoners;
                pop.totalPeasants -= (int)newPrisoners;
            }
        }
    }

    public void SubtractPrisoners()
    {
        if(prisoners > prisonCells)
        {
            int dif = prisoners - prisonCells;
            prisoners = prisonCells;
            pop.totalPeasants += dif;
        }
    }
}
