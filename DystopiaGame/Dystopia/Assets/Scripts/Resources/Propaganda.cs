using UnityEngine;

public class Propaganda : MonoBehaviour
{
    [SerializeField] private PeasantContent content;

    public int propType;
    public int propAmount;
    public int dailyProp;
    public float maxWorkers;
    public float workers;

    private float totalGain;

    public void AddPropaganda()
    {
        float gainFloat = (workers + 1) / (maxWorkers + 1) * dailyProp;
        int gain = Mathf.RoundToInt(gainFloat);
        propAmount += gain;
        totalGain += gainFloat;

        if(propType == 0)
        {
            content.ChangeHappiness(gainFloat);
        }
        else if(propType == 1)
        {
            content.ChangeFear(gainFloat);
        }
        else
        {
            content.ChangePatriotism(gainFloat);
        }
    }

    public void ChangeType(int newType)
    {
        if(newType != propType)
        {
            propAmount = 0;

            if (propType == 0)
            {
                content.ChangeHappiness(-(totalGain / 2));
            }
            else if (propType == 1)
            {
                content.ChangeFear(-(totalGain / 2));
            }
            else
            {
                content.ChangePatriotism(-(totalGain / 2));
            }

            propType = newType;
            totalGain = 0;
        }
    }
}
