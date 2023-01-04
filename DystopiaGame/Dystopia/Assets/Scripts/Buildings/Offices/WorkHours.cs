using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WorkHours : MonoBehaviour
{
    [SerializeField] private Calendar cal;
    [SerializeField] private PeasantContent content;

    public int workHoursStart = 6;
    public int workHoursEnd = 20;
    public int tempWorkEnd = 0;
    public bool workHours = true;
    private bool shiftEndCooldown = false;
    private bool shiftStartCooldown = false;

    [SerializeField] private Button workButton;
    [SerializeField] private Button homeButton;

    public void StartWork()
    {
        workHours = true;
        workButton.interactable = false;
        homeButton.interactable = true;
    }

    public void EndWork()
    {
        workHours = false;
        homeButton.interactable = false;
        workButton.interactable = true;
    }

    public void EarlyShift()
    {
        if(!shiftStartCooldown)
        {
            tempWorkEnd = cal.hour + 6;

            if (tempWorkEnd > 24)
            {
                tempWorkEnd -= 24;
            }

            if (tempWorkEnd > workHoursStart)
            {
                tempWorkEnd = 0;
            }

            content.ChangeHappiness(-20);
            StartWork();
            StartCoroutine(ShiftStartCooldown());
        }
    }

    public void EndShift()
    {
        if(!shiftEndCooldown)
        {
            content.ChangeHappiness((float)(workHoursEnd - cal.hour) / 4);
            EndWork();
            StartCoroutine(ShiftEndCooldown());
        }
    }

    private IEnumerator ShiftEndCooldown()
    {
        shiftEndCooldown = true;
        yield return new WaitForSeconds(2160);
        shiftEndCooldown = false;
    }

    private IEnumerator ShiftStartCooldown()
    {
        shiftStartCooldown = true;
        yield return new WaitForSeconds(2160);
        shiftStartCooldown = false;
    }
}
