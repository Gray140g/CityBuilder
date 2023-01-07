using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private QuestDisplay display;
    private List<QuestBar> activeQuests = new List<QuestBar>();

    [SerializeField] private QuestBar firstQuest;

    private void Start()
    {
        display.ActivateQuest(firstQuest);
    }

    public void TryToComplete()
    {
        for (int i = 0; i < activeQuests.Count; i++)
        {
            activeQuests[i].TryToComplete();
        }
    }

    public void AddQuest(QuestBar quest)
    {
        activeQuests.Add(quest);
    }

    public void RemoveQuest(QuestBar quest)
    {
        activeQuests.Remove(quest);
        display.RemoveQuest(quest);
    }
}
