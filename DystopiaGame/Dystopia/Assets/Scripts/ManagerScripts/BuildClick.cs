using UnityEngine;

public class BuildClick : MonoBehaviour
{
    private ClickManager click;
    public GameObject outline;

    [SerializeField] private Sprite buildingSprite;
    [SerializeField] private string buildingName;
    public int type;

    public bool added;
    public bool subtracted;
    public bool typeChange;
    public int typeForChange;

    public int val;
    public int maxVal;

    private void Start()
    {
        click = GameObject.FindGameObjectWithTag("InputManager").GetComponent<ClickManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Clicker"))
        {
            click.collisions.Add(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Clicker"))
        {
            click.collisions.Remove(this);
        }
    }

    public void Click()
    {
        click.OnClick(buildingName, buildingSprite, type);
    }

    public void Add()
    {
        added = true;
    }

    public void Remove()
    {
        subtracted = true;
    }

    public void Change(int newType)
    {
        typeChange = true;
        typeForChange = newType;
    }

    public void TimeChange()
    {
        val -= 1;
    }
}
