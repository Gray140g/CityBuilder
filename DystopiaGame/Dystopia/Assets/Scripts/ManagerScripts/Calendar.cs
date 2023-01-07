using System.Collections;
using UnityEngine;
using TMPro;

public class Calendar : MonoBehaviour
{
    [SerializeField] private DayCount count;
    [SerializeField] private WorkHours workTime;

    [SerializeField] private TextMeshProUGUI dateDisplay;
    [SerializeField] private TextMeshProUGUI clockDisplay;

    [SerializeField] private string[] months;
    [SerializeField] private int[] daysInMonth;

    public int currentIndex = 10;
    public int day = 7;
    public int year = 1917;

    public int hour = 6;
    public int min = 0;

    private void Start()
    {
        StartCoroutine("AddMinute");
    }

    public void AddDay()
    {
        count.UpdateChangesDay();

        day += 1;
        if(day > daysInMonth[currentIndex])
        {
            if(currentIndex == 11)
            {
                year += 1;
                currentIndex = 0;
                day = 1;
            }    
            else
            {
                currentIndex += 1;
                day = 1;
            }
        }

        dateDisplay.text = months[currentIndex] + " " + day + ", " + year;

        DisplayClock();
        StartCoroutine("AddMinute");
    }

    private void DisplayClock()
    {
        if(min < 10)
        {
            clockDisplay.text = hour + ":0" + min; 
        }
        else
        {
            clockDisplay.text = hour + ":" + min;
        }
    }

    private void AddHour()
    {
        if (hour < 24)
        {
            hour += 1;

            if(hour == workTime.workHoursStart)
            {
                workTime.StartWork();
            }
            else if(hour == workTime.workHoursEnd || hour == workTime.tempWorkEnd)
            {
                workTime.EndWork();
            }

            DisplayClock();
            count.UpdateChangesHour();
            StartCoroutine("AddMinute");
        }
        else
        {
            hour = 1;
            AddDay();
        }
    }

    private IEnumerator AddMinute()
    {
        yield return new WaitForSeconds(.25f);
        if(min < 59)
        {
            min += 1;
            DisplayClock();
            StartCoroutine("AddMinute");
        }
        else
        {
            min = 0;
            AddHour();
        }
    }

    public IEnumerator WeekCount()
    {
        yield return new WaitForSeconds(2520);
    }
}
