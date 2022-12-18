using UnityEngine;

[CreateAssetMenu(fileName = "QuestBar", menuName = "Quest")]
public class QuestBar : ScriptableObject
{
    public QuestDisplay display;

    [SerializeField] private string questName;
    [SerializeField] private string[] individualQuests;

    private bool isActive = false;
    private bool completed = false;

    public void OnDisplay()
    {
        if(!isActive && !completed)
        {
            display.CreateABar(questName, individualQuests);
        }
    }
}
