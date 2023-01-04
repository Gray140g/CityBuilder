using UnityEngine;
using UnityEngine.UI;

public class PeasantContent : MonoBehaviour
{
    [SerializeField] private Crime crime;
    [SerializeField] private Population pop;
    [SerializeField] private Food food;
    [SerializeField] private PopStats stats;

    [SerializeField] private MenuOpener opener;
    [SerializeField] private QuestManager quests;

    public float balance;
    public float happiness = 50;
    public float fear = 0;
    public float patriotism = 50;

    [SerializeField] private Slider balanceSlider;
    [SerializeField] private Slider happinessSlider;
    [SerializeField] private Slider fearSlider;
    [SerializeField] private Slider patriotismSlider;

    [SerializeField] private Slider balanceBackgroundSlider;
    [SerializeField] private Slider happinessBackgroundSlider;
    [SerializeField] private Slider fearBackgroundSlider;
    [SerializeField] private Slider patriotismBackgroundSlider;

    public int[] balanceBarsNeedsToLerp = new int[4];
    [SerializeField] private float barSpeed;
    [SerializeField] private float closeVal = .01f;

    private void Start()
    {
        DetermineBalance();
        LoadBarValues();
    }

    private void Update()
    {
        if(!opener.buildIsOpen && !opener.editIsOpen)
        {
            if (balanceBarsNeedsToLerp[0] != 0)
            {
                if (balanceBarsNeedsToLerp[0] == 1)
                {
                    float absolute = Mathf.Abs(balance - balanceSlider.value);

                    if (absolute >= closeVal)
                    {
                        balanceBackgroundSlider.value = balance;
                        balanceSlider.value = Mathf.Lerp(balanceSlider.value, balance, barSpeed);
                    }
                    else
                    {
                        balanceBarsNeedsToLerp[0] = 0;
                        balanceSlider.value = balance;
                    }
                }
                else if (balanceBarsNeedsToLerp[0] == 2)
                {
                    float absolute = Mathf.Abs(balanceBackgroundSlider.value - balance);

                    if (absolute >= closeVal)
                    {
                        balanceSlider.value = balance;
                        balanceBackgroundSlider.value = Mathf.Lerp(balanceBackgroundSlider.value, balance, barSpeed);
                    }
                    else
                    {
                        balanceBarsNeedsToLerp[0] = 0;
                        balanceBackgroundSlider.value = balance;
                    }
                }
            }

            if (balanceBarsNeedsToLerp[1] != 0)
            {
                if (balanceBarsNeedsToLerp[1] == 1)
                {
                    float absolute = Mathf.Abs(happiness - happinessSlider.value);

                    if (absolute >= closeVal)
                    {
                        happinessBackgroundSlider.value = happiness;
                        happinessSlider.value = Mathf.Lerp(happinessSlider.value, happiness, barSpeed);
                    }
                    else
                    {
                        balanceBarsNeedsToLerp[1] = 0;
                        happinessSlider.value = happiness;
                    }
                }
                else if (balanceBarsNeedsToLerp[1] == 2)
                {
                    float absolute = Mathf.Abs(happinessBackgroundSlider.value - happiness);

                    if (absolute >= closeVal)
                    {
                        happinessSlider.value = happiness;
                        happinessBackgroundSlider.value = Mathf.Lerp(happinessBackgroundSlider.value, happiness, barSpeed);
                    }
                    else
                    {
                        balanceBarsNeedsToLerp[1] = 0;
                        happinessBackgroundSlider.value = happiness;
                    }
                }
            }

            if (balanceBarsNeedsToLerp[2] != 0)
            {
                if (balanceBarsNeedsToLerp[2] == 1)
                {
                    float absolute = Mathf.Abs(fear - fearSlider.value);

                    if (absolute >= closeVal)
                    {
                        fearBackgroundSlider.value = fear;
                        fearSlider.value = Mathf.Lerp(fearSlider.value, fear, barSpeed);
                    }
                    else
                    {
                        balanceBarsNeedsToLerp[2] = 0;
                        fearSlider.value = fear;
                    }
                }
                else if (balanceBarsNeedsToLerp[2] == 2)
                {
                    float absolute = Mathf.Abs(fearBackgroundSlider.value - fear);

                    if (absolute >= closeVal)
                    {
                        fearSlider.value = fear;
                        fearBackgroundSlider.value = Mathf.Lerp(fearBackgroundSlider.value, fear, barSpeed);
                    }
                    else
                    {
                        balanceBarsNeedsToLerp[2] = 0;
                        fearBackgroundSlider.value = fear;
                    }
                }
            }

            if (balanceBarsNeedsToLerp[3] != 0)
            {
                if (balanceBarsNeedsToLerp[3] == 1)
                {
                    float absolute = Mathf.Abs(patriotism - patriotismSlider.value);

                    if (absolute >= closeVal)
                    {
                        patriotismBackgroundSlider.value = patriotism;
                        patriotismSlider.value = Mathf.Lerp(patriotismSlider.value, patriotism, barSpeed);
                    }
                    else
                    {
                        balanceBarsNeedsToLerp[3] = 0;
                        patriotismSlider.value = patriotism;
                    }
                }
                else if (balanceBarsNeedsToLerp[3] == 2)
                {
                    float absolute = Mathf.Abs(patriotismBackgroundSlider.value - patriotism);

                    if (absolute >= closeVal)
                    {
                        patriotismSlider.value = patriotism;
                        patriotismBackgroundSlider.value = Mathf.Lerp(patriotismBackgroundSlider.value, patriotism, barSpeed);
                    }
                    else
                    {
                        balanceBarsNeedsToLerp[3] = 0;
                        patriotismBackgroundSlider.value = patriotism;
                    }
                }
            }
        }
    }

    public void LoadBarValues()
    {
        balanceSlider.value = balance;
        balanceBackgroundSlider.value = balance;
        happinessSlider.value = happiness;
        happinessBackgroundSlider.value = happiness;
        fearSlider.value = fear;
        fearBackgroundSlider.value = fear;
        patriotismSlider.value = patriotism;
        patriotismBackgroundSlider.value = patriotism;
    }

    #region ChangeRegion

    public void ChangeHappiness(float newHappiness)
    {
        happiness += newHappiness;
        if(happiness < 0)
        {
            happiness = 0;
        }
        else if(happiness > 100)
        {
            happiness = 100;
        }

        DetermineBalance();
        quests.TryToComplete();
        BarLerp(1, newHappiness);
    }

    public void ChangeFear(float newFear)
    {
        fear += newFear;
        if(fear < 0)
        {
            fear = 0;
        }
        else if (fear > 100)
        {
            fear = 100;
        }

        DetermineBalance();
        quests.TryToComplete();
        BarLerp(2, newFear);
    }

    public void ChangePatriotism(float newPatriotism)
    {
        patriotism += newPatriotism;
        if(patriotism < 0)
        {
            patriotism = 0;
        }
        else if (patriotism > 100)
        {
            patriotism = 100;
        }

        DetermineBalance();
        quests.TryToComplete();
        BarLerp(3, newPatriotism);
    }

    #endregion

    #region DetermineRegion

    private void DetermineBalance()
    {
        float newBalance = (happiness + fear + patriotism) / 3;
        BarLerp(0, newBalance - balance);
        balance = newBalance;
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

    private void BarLerp(int type, float add)
    {
        bool addBool = true;

        if(add >= 0)
        {
            addBool = true;
        }
        else
        {
            addBool = false;
        }

        if(addBool)
        {
            balanceBarsNeedsToLerp[type] = 1;
        }
        else
        {
            balanceBarsNeedsToLerp[type] = 2;
        }
    }
}
