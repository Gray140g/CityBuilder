using System.Collections;
using UnityEngine;

public class DayCount : MonoBehaviour
{
    [SerializeField] private Population pop;
    [SerializeField] private Food food;
    [SerializeField] private Materials mat;
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
        food.AddFood();
        mat.AddMaterials();
    }
}
