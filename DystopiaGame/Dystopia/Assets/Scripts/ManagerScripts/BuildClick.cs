using UnityEngine;

public class BuildClick : MonoBehaviour
{
    private ClickManager click;
    public Workers workers;
    public GameObject outline;

    [SerializeField] private Sprite buildingSprite;
    [SerializeField] private string buildingName;
    [SerializeField] private string buildingDesc;
    public int type;

    public bool added;
    public bool subtracted;
    public bool max;
    public bool min;
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
        click.OnClick(buildingName, buildingDesc, buildingSprite, type);
    }

    public void Change(int newType)
    {
        typeChange = true;
        typeForChange = newType;
        workers.TypeChange();
    }

    public void TimeChange()
    {
        val -= 1;
    }
}
