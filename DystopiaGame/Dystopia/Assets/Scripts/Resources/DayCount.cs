using System.Collections;
using UnityEngine;

public class DayCount : MonoBehaviour
{
    [SerializeField] private WorkHours workTime;

    [SerializeField] private Population pop;
    [SerializeField] private Food food;
    [SerializeField] private Materials mat;
    [SerializeField] private Ignorance ign;
    [SerializeField] private Influence inf;
    [SerializeField] private Propaganda prop;
    [SerializeField] private PeasantContent content;
    [SerializeField] private Crime crime;

    public void UpdateChangesDay()
    {
        UpdateChangesHour();
        food.Eat();
        prop.AddPropaganda();
        crime.GetCrime();
        content.DayChange();
    }

    public void UpdateChangesHour()
    {
        if(workTime.workHours)
        {
            food.AddFood();
            mat.AddMaterials();
            ign.AddIgnorance();
            inf.AddInfluence();
        }
    }
}
