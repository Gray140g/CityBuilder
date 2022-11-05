using System.Collections;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private PeasantContent content;
    private DayCount day;

    public bool canUse = true;
    [SerializeField] private int value;

    private void Start()
    {
        content =  GameObject.FindGameObjectWithTag("BalanceManager").GetComponent<PeasantContent>();
        day = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<DayCount>();
    }

    public void Use(int type)
    {
        if(canUse)
        {
            if (type == 0)
            {
                content.ChangeHappiness(value);
            }
            else if (type == 1)
            {
                content.ChangeFear(value);
            }
            else if (type == 2)
            {
                content.ChangePatriotism(value);
            }
            else if (type == 3)
            {
                content.ChangeHappiness(-value);
            }
            else if (type == 4)
            {
                content.ChangeFear(-value);
            }
            else
            {
                content.ChangePatriotism(-value);
            }

            StartCoroutine("UseLock");
        }
    }

    private IEnumerator UseLock()
    {
        canUse = false;
        yield return new WaitForSeconds(day.time * 7);
        canUse = true;
    }
}
