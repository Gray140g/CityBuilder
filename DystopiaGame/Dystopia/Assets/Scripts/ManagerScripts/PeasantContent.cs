using UnityEngine;
using UnityEngine.UI;

public class PeasantContent : MonoBehaviour
{
    [SerializeField] private Crime crime;
    [SerializeField] private Population pop;
    [SerializeField] private Food food;
    [SerializeField] private PopStats stats;

    public float balance;
    [SerializeField] private float happiness = 50;
    [SerializeField] private float fear = 0;
    [SerializeField] private float patriotism = 50;

    [SerializeField] private Slider balanceSlider;
    [SerializeField] private Slider happinessSlider;
    [SerializeField] private Slider fearSlider;
    [SerializeField] private Slider patriotismSlider;

    private void Update()
    {
        DetermineBalance();
        happinessSlider.value = happiness;
        fearSlider.value = fear;
        patriotismSlider.value = patriotism;
        balanceSlider.value = balance;
    }

    #region ChangeRegion

    public void ChangeHappiness(float newHappiness)
    {
        happiness += newHappiness;
        if(happiness < 0)
        {
            happiness = 0;
        }
    }

    public void ChangeFear(float newFear)
    {
        fear += newFear;
        if(fear < 0)
        {
            fear = 0;
        }
    }

    public void ChangePatriotism(float newPatriotism)
    {
        patriotism += newPatriotism;
        if(patriotism < 0)
        {
            patriotism = 0;
        }
    }

    #endregion

    #region DetermineRegion

    private void DetermineBalance()
    {
        balance = (happiness + fear + patriotism) / 3;
    }

    public void DayChange()
    {
        Homelessness();
        Famine();
        Crime();
        PoliceForce();
    }

    private void Homelessness()
    {
        float homeless = (float) pop.homelessPeasants / pop.totalPeasants;
        float eliteHomeless = (float) pop.homelessElites / pop.totalElites;

        if(homeless > 0)
        {
            ChangeHappiness(-homeless);
        }
        else
        {
            ChangeHappiness(.1f);
        }

        if(eliteHomeless > 0)
        {
            ChangeHappiness(eliteHomeless * 2);
        }
    }

    private void Famine()
    {
        float change = stats.CalculateHungerChange();
        ChangeHappiness(change / pop.totalElites);
        if(change < 0)
        {
            change *= -1;
        }
        ChangePatriotism(change / pop.totalPeasants);
    }

    private void Crime()
    {
        if(crime.crimeRate > .05f)
        {
            ChangeHappiness(-crime.crimeRate);
            ChangeFear(-crime.crimeRate / 2);
            ChangePatriotism(-crime.crimeRate / 4);
        }
        else
        {
            ChangeHappiness(.05f);
        }
    }

    private void PoliceForce()
    {
        if(crime.police > 0)
        {
            ChangeHappiness((float)-crime.police / 40);
            ChangeFear((float)crime.police / 20);
            ChangePatriotism((float)crime.police / 40);
        }
    }

    #endregion
}
