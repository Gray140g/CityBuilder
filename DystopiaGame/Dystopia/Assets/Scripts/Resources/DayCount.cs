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

    public float time;

    private void Start()
    {
        StartCoroutine(DayChange());
    }

    private void UpdateChanges()
    {
        food.AddFood();
        food.Eat();
        mat.AddMaterials();
        prop.AddPropaganda();
        crime.GetCrime();
        content.DayChange();
    }

    private IEnumerator DayChange()
    {
        yield return new WaitForSeconds(time);
        UpdateChanges();
        StartCoroutine(DayChange());
    }

    public IEnumerator WeekCount()
    {
        yield return new WaitForSeconds(time * 7);
    }
}
