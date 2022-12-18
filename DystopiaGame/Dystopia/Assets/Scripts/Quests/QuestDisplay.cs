using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestDisplay : MonoBehaviour
{
    private List<QuestBar> activeQuests = new List<QuestBar>();
    [SerializeField] private RectTransform[] questSlots;
    [SerializeField] private bool[] isQuestSlotActive;

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject questPrefab;

    public void ActivateQuest(QuestBar quest)
    {
        activeQuests.Add(quest);
        quest.display = this;
        quest.OnDisplay();
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
        isQuestSlotActive[firstAvailable] = true;

        TextMeshProUGUI newBarName = newBar.GetComponentInChildren<TextMeshProUGUI>(false);
        newBarName.text = questName;
        newBarName.gameObject.SetActive(false);

        TextMeshProUGUI individualStrings = newBar.GetComponentInChildren<TextMeshProUGUI>(false);
        for (int i = 0; i < items.Length; i++)
        {
            individualStrings.text += items[i] + "\n";
        }
        newBarName.gameObject.SetActive(true);
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
}
