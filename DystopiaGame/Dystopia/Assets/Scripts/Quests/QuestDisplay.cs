using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestDisplay : MonoBehaviour
{
    [SerializeField] private QuestManager manager;

    private List<QuestBar> activeQuests = new List<QuestBar>();
    private List<GameObject> bars = new List<GameObject>();
    [SerializeField] private RectTransform[] questSlots;
    [SerializeField] private bool[] isQuestSlotActive = { false, false, false };

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject questPrefab;

    public void ActivateQuest(QuestBar quest)
    {
        quest.display = this;
        quest.OnDisplay();
        activeQuests.Add(quest);
        quest.manager = manager;
        quest.content = GameObject.FindGameObjectWithTag("BalanceManager").GetComponent<PeasantContent>();
        quest.groups = GameObject.FindGameObjectWithTag("BuildingManager").GetComponent<BuildGroups>();
        manager.AddQuest(quest);
    }

    public void CreateABar(string questName, string[] items)
    {
        int firstAvailable = returnAvailability();

        if(firstAvailable == 100)
        {
            Debug.Log("No Available Quest Slot");
            return;
        }

        GameObject newBar = Instantiate(questPrefab, questSlots[firstAvailable].position, Quaternion.identity, questSlots[firstAvailable]);

        TextMeshProUGUI newBarName = newBar.GetComponentInChildren<TextMeshProUGUI>(false);
        newBarName.text = questName;
        newBarName.gameObject.SetActive(false);

        TextMeshProUGUI individualStrings = newBar.GetComponentInChildren<TextMeshProUGUI>(false);
        for (int i = 0; i < items.Length; i++)
        {
            individualStrings.text += items[i] + "\n";
        }
        newBarName.gameObject.SetActive(true);

        manager.TryToComplete();

        bars.Add(newBar);
        isQuestSlotActive[firstAvailable] = true;
    }

    private int returnAvailability()
    {
        for (int i = 0; i < isQuestSlotActive.Length; i++)
        {
            if(!isQuestSlotActive[i])
            {
                return i;
            }
        }

        return 100;
    }

    public void RemoveQuest(QuestBar quest)
    {
        int index = 100;
        bool foundIndex = false;

        for (int i = 0; i < activeQuests.Count; i++)
        {
            if(activeQuests[i] == quest && !foundIndex)
            {
                index = i;
                foundIndex = true;
            }
        }

        activeQuests.Remove(quest);
        GameObject bar = bars[index];
        bars.Remove(bar);
        Destroy(bar);
        isQuestSlotActive[index] = false;
    }
}
