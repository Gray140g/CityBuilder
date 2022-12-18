using UnityEngine;
using TMPro;

public class Calendar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dateDisplay;

    [SerializeField] private string[] months;
    [SerializeField] private int[] daysInMonth;

    private int currentIndex = 10;
    private int day = 7;
    private int year = 1917;

    public void AddDay()
    {
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
    }
}
