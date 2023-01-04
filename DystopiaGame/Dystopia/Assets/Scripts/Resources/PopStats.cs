using System.Collections.Generic;
using UnityEngine;

public class PopStats : MonoBehaviour
{
    [SerializeField] private Population pop;
    [SerializeField] private Food food;

    //famished, starving, hungry, content, full, satisfied, stuffed
    private List<int> peasantHungerLevels = new List<int>();
    private List<int> eliteHungerLevels = new List<int>();

    private void Start()
    {
        CheckLists();
    }

    private void CheckLists()
    {
        if (peasantHungerLevels.Count < pop.totalPeasants)
        {
            for (int i = 0; i < pop.totalPeasants; i++)
            {
                peasantHungerLevels.Add(3);
            }
        }

        if(eliteHungerLevels.Count < pop.totalElites)
        {
            for (int i = 0; i < pop.totalElites; i++)
            {
                eliteHungerLevels.Add(3);
            }

        }
    }

    #region EatRegion

    public void EliteEat(int foodAmount)
    {
        int newFoodAmount = (int) (foodAmount / 2 + .5f);

        if (newFoodAmount > eliteHungerLevels.Count * 2)
        {
            for (int i = 0; i < eliteHungerLevels.Count; i++)
            {
                eliteHungerLevels[i] += 1;
                food.food -= 2;
            }
        }
        else
        {
            for (int i = 0; i <= newFoodAmount; i++)
            {
                eliteHungerLevels[i] += 1;
                food.food -= 1;
            }

            for (int i = newFoodAmount; i < eliteHungerLevels.Count; i++)
            {
                eliteHungerLevels[i] -= 1;
            }
        }

        if(food.food == -1)
        {
            food.food = 0;
        }

        PeasantEat(food.food);
    }

    private void PeasantEat(int foodAmount)
    {
        if(foodAmount > peasantHungerLevels.Count)
        {
            for (int i = 0; i < peasantHungerLevels.Count; i++)
            {
                peasantHungerLevels[i] += 1;
                food.food -= 1;
            }
        }
        else
        {
            for (int i = 0; i <= foodAmount; i++)
            {
                peasantHungerLevels[i] += 1;
                food.food -= 1;
            }

            for (int i = foodAmount; i < peasantHungerLevels.Count; i++)
            {
                peasantHungerLevels[i] -= 1;
            }
        }

        if (food.food == -1)
        {
            food.food = 0;
        }

        PopChange();
    }

    private void PopChange()
    {
        int eliteOverlyFedCount = 0;
        int peasantOverlyFedCount = 0;

        int eliteKillCount = 0;
        int peasantKillCount = 0;

        for (int i = 0; i < eliteHungerLevels.Count; i++)
        {
            if(eliteHungerLevels[i] > 6)
            {
                eliteOverlyFedCount += 1;
                eliteHungerLevels[i] = 3;
                eliteHungerLevels.Add(3);
            }
            else if(eliteHungerLevels[i] < 0)
            {
                eliteKillCount += 1;
                eliteHungerLevels.RemoveAt(i);
            }
        }

        for (int i = 0; i < peasantHungerLevels.Count; i++)
        {
            if (peasantHungerLevels[i] > 6)
            {
                peasantOverlyFedCount += 1;
                peasantHungerLevels[i] = 3;
                peasantHungerLevels.Add(3);
            }
            else if (peasantHungerLevels[i] < 0)
            {
                peasantKillCount += 1;
                peasantHungerLevels.RemoveAt(i);
            }
        }

        float elitePop = (float)eliteOverlyFedCount / 2 + .5f;
        int elitePopInt = Mathf.RoundToInt(elitePop);
        float peasantPop = (float)peasantOverlyFedCount / 2 + .5f;
        int peasantPopInt = Mathf.RoundToInt(peasantPop);

        pop.AddElites(elitePopInt);
        pop.KillElites(eliteKillCount);
        pop.AddPeasants(peasantPopInt);
        pop.KillPeasants(peasantKillCount);

        SortEliteFoodList();
        SortPeasantFoodList();
    }

    public float CalculateHungerChange()
    {
        float stuffed = 0;
        float satiated = 0;
        float starving = 0;
        float famished = 0;

        for (int i = 0; i < peasantHungerLevels.Count; i++)
        {
            if(peasantHungerLevels[i] == 6)
            {
                stuffed += 1;
            }
            else if (peasantHungerLevels[i] == 5)
            {
                satiated += 1;
            }
            else if (peasantHungerLevels[i] == 1)
            {
                starving += 1;
            }
            else if (peasantHungerLevels[i] == 0)
            {
                famished += 1;
            }
        }

        for (int i = 0; i < eliteHungerLevels.Count; i++)
        {
            if (eliteHungerLevels[i] == 6)
            {
                stuffed -= 2;
            }
            else if (eliteHungerLevels[i] == 5)
            {
                satiated -= 2;
            }
            else if (eliteHungerLevels[i] == 1)
            {
                starving -= 2;
            }
            else if (eliteHungerLevels[i] == 0)
            {
                famished -= 2;
            }
        }

        return (2 * stuffed + satiated) - (2 * famished + starving);
    }

    #endregion

    #region SortRegion

    private void SortEliteFoodList()
    {
        List<int> stuffedList = new List<int>();
        List<int> satiatedList = new List<int>();
        List<int> fullList = new List<int>();
        List<int> contentList = new List<int>();
        List<int> hungryList = new List<int>();
        List<int> starvingList = new List<int>();
        List<int> famishedList = new List<int>();

        for (int i = 0; i < eliteHungerLevels.Count; i++)
        {
            if (eliteHungerLevels[i] == 6)
            {
                stuffedList.Add(6);
            }
            else if (eliteHungerLevels[i] == 5)
            {
                satiatedList.Add(5);
            }
            else if (eliteHungerLevels[i] == 4)
            {
                fullList.Add(4);
            }
            else if (eliteHungerLevels[i] == 3)
            {
                contentList.Add(3);
            }
            else if (eliteHungerLevels[i] == 2)
            {
                hungryList.Add(2);
            }
            else if (eliteHungerLevels[i] == 1)
            {
                starvingList.Add(1);
            }
            else if (eliteHungerLevels[i] == 0)
            {
                famishedList.Add(0);
            }
        }

        eliteHungerLevels.Clear();

        for (int i = 0; i < famishedList.Count; i++)
        {
            eliteHungerLevels.Add(famishedList[i]);
        }
        for (int i = 0; i < starvingList.Count; i++)
        {
            eliteHungerLevels.Add(starvingList[i]);
        }
        for (int i = 0; i < hungryList.Count; i++)
        {
            eliteHungerLevels.Add(hungryList[i]);
        }
        for (int i = 0; i < contentList.Count; i++)
        {
            eliteHungerLevels.Add(contentList[i]);
        }
        for (int i = 0; i < fullList.Count; i++)
        {
            eliteHungerLevels.Add(fullList[i]);
        }
        for (int i = 0; i < satiatedList.Count; i++)
        {
            eliteHungerLevels.Add(satiatedList[i]);
        }
        for (int i = 0; i < stuffedList.Count; i++)
        {
            eliteHungerLevels.Add(stuffedList[i]);
        }
    }

    private void SortPeasantFoodList()
    {
        List<int> stuffedList = new List<int>();
        List<int> satiatedList = new List<int>();
        List<int> fullList = new List<int>();
        List<int> contentList = new List<int>();
        List<int> hungryList = new List<int>();
        List<int> starvingList = new List<int>();
        List<int> famishedList = new List<int>();

        for (int i = 0; i < peasantHungerLevels.Count; i++)
        {
            if (peasantHungerLevels[i] == 6)
            {
                stuffedList.Add(6);
            }
            else if (peasantHungerLevels[i] == 5)
            {
                satiatedList.Add(5);
            }
            else if (peasantHungerLevels[i] == 4)
            {
                fullList.Add(4);
            }
            else if (peasantHungerLevels[i] == 3)
            {
                contentList.Add(3);
            }
            else if (peasantHungerLevels[i] == 2)
            {
                hungryList.Add(2);
            }
            else if (peasantHungerLevels[i] == 1)
            {
                starvingList.Add(1);
            }
            else if (peasantHungerLevels[i] == 0)
            {
                famishedList.Add(0);
            }
        }

        peasantHungerLevels.Clear();

        for (int i = 0; i < famishedList.Count; i++)
        {
            peasantHungerLevels.Add(famishedList[i]);
        }
        for (int i = 0; i < starvingList.Count; i++)
        {
            peasantHungerLevels.Add(starvingList[i]);
        }
        for (int i = 0; i < hungryList.Count; i++)
        {
            peasantHungerLevels.Add(hungryList[i]);
        }
        for (int i = 0; i < contentList.Count; i++)
        {
            peasantHungerLevels.Add(contentList[i]);
        }
        for (int i = 0; i < fullList.Count; i++)
        {
            peasantHungerLevels.Add(fullList[i]);
        }
        for (int i = 0; i < satiatedList.Count; i++)
        {
            peasantHungerLevels.Add(satiatedList[i]);
        }
        for (int i = 0; i < stuffedList.Count; i++)
        {
            peasantHungerLevels.Add(stuffedList[i]);
        }
    }

    #endregion
}
