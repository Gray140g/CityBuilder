using UnityEngine;

public enum SearchType { Building, ContentMore, ContentLess, BothMore, BothLess }

[CreateAssetMenu(fileName = "QuestBar", menuName = "Quest")]
public class QuestBar : ScriptableObject
{
    [HideInInspector] public QuestDisplay display;
    [HideInInspector] public QuestManager manager;
    [HideInInspector] public BuildGroups groups;
    [HideInInspector] public PeasantContent content;

    [SerializeField] private string questName;
    [SerializeField] private string[] individualQuests;

    public SearchType type;

    [SerializeField] private string[] buildingNamesToSearch;
    [SerializeField] private bool[] individualCompleted;
    [SerializeField] private int[] indexesToIgnore;

    [SerializeField] private int balanceType;
    [SerializeField] private float neededBalance;
    private bool balanceCompleted = false;

    public void OnDisplay()
    {
        for (int i = 0; i < individualCompleted.Length; i++)
        {
            individualCompleted[i] = false;
            indexesToIgnore[i] = 100;
        }
        balanceCompleted = false;
        display.CreateABar(questName, individualQuests);
    }

    public void TryToComplete()
    {
        //This code is an abomination, please never open it
        if(type == SearchType.Building || type == SearchType.BothMore || type == SearchType.BothLess)
        {
            for (int i = 0; i < buildingNamesToSearch.Length; i++)
            {
                if(!individualCompleted[i])
                {
                    for (int j = 0; j < groups.allBuildingNames.Count; j++)
                    {
                        if(buildingNamesToSearch[i] == groups.allBuildingNames[j] && !individualCompleted[i])
                        {
                            bool canComplete = true;

                            for (int k = 0; k < indexesToIgnore.Length; k++)
                            {
                                if(j == indexesToIgnore[k])
                                {
                                    canComplete = false;
                                }
                            }

                            if(canComplete)
                            {
                                individualCompleted[i] = true;
                                indexesToIgnore[i] = j;
                            }
                        }
                    }
                }
            }
        }

        if(type == SearchType.ContentMore || type == SearchType.BothMore)
        {
            if(balanceType == 0)
            {
                if(content.balance >= neededBalance)
                {
                    balanceCompleted = true;
                }
            }
            else if(balanceType == 1)
            {
                if (content.happiness >= neededBalance)
                {
                    balanceCompleted = true;
                }
            }
            else if (balanceType == 2)
            {
                if (content.fear >= neededBalance)
                {
                    balanceCompleted = true;
                }
            }
            else if (balanceType == 3)
            {
                if (content.patriotism >= neededBalance)
                {
                    balanceCompleted = true;
                }
            }
        }

        if (type == SearchType.ContentLess || type == SearchType.BothLess)
        {
            if (balanceType == 0)
            {
                if (content.balance < neededBalance)
                {
                    balanceCompleted = true;
                }
            }
            else if (balanceType == 1)
            {
                if (content.happiness < neededBalance)
                {
                    balanceCompleted = true;
                }
            }
            else if (balanceType == 2)
            {
                if (content.fear < neededBalance)
                {
                    balanceCompleted = true;
                }
            }
            else if (balanceType == 3)
            {
                if (content.patriotism < neededBalance)
                {
                    balanceCompleted = true;
                }
            }
        }

        if (type == SearchType.BothMore || type == SearchType.BothLess)
        {
            if(balanceCompleted && CheckCompleteBuilding())
            {
                Complete();
            }
        }
        else if (type == SearchType.ContentMore || type == SearchType.ContentLess)
        {
            if(balanceCompleted)
            {
                Complete();
            }
        }
        else if (type == SearchType.Building)
        {
            if(CheckCompleteBuilding())
            {
                Complete();
            }
        }
    }

    private void Complete()
    {
        Debug.Log("Completed!");
        manager.RemoveQuest(this);
    }

    private bool CheckCompleteBuilding()
    {
        for (int i = 0; i < individualCompleted.Length; i++)
        {
            if(!individualCompleted[i])
            {
                return false;
            }
        }

        return true;
    }
}
