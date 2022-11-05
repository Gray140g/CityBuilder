using UnityEngine;

public class School : MonoBehaviour
{
    [SerializeField] private Building parentBuilding;
    private PeasantContent content;
    [SerializeField] private int patriotism;

    private void Start()
    {
        content = GameObject.FindGameObjectWithTag("BalanceManager").GetComponent<PeasantContent>();
    }

    private void Update()
    {
        if (parentBuilding.justPlaced)
        {
            OnPlace();
        }
    }

    public void OnPlace()
    {
        content.ChangePatriotism(patriotism);
        parentBuilding.justPlaced = false;
    }
}
