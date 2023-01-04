using UnityEngine;

public enum PosEnum { AddHappiness, AddFear, AddPatriotism }
public enum NegEnum { SubHappiness, SubFear, SubPatriotism }

[CreateAssetMenu(fileName = "LawObject", menuName = "Law")]
public class LawScriptableObject : ScriptableObject
{
    public PeasantContent content;
    [SerializeField] private PosEnum posType;
    [SerializeField] private NegEnum negType;

    public string lawName;
    public string desc;
    public Sprite icon;

    public bool unlocked;

    [SerializeField] private int addAmount;
    [SerializeField] private int subAmount;

    public void onUnlock()
    {
        if(posType == PosEnum.AddHappiness)
        {
            content.ChangeHappiness(addAmount);
        }
        else if (posType == PosEnum.AddFear)
        {
            content.ChangeFear(addAmount);
        }
        else if (posType == PosEnum.AddPatriotism)
        {
            content.ChangePatriotism(addAmount);
        }

        if(negType == NegEnum.SubHappiness)
        {
            content.ChangeHappiness(subAmount);
        }
        else if (negType == NegEnum.SubFear)
        {
            content.ChangeFear(subAmount);
        }
        else if (negType == NegEnum.SubPatriotism)
        {
            content.ChangePatriotism(subAmount);
        }

        unlocked = true;
    }
}
