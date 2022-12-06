using UnityEngine;

public class Building : MonoBehaviour
{
    private BuildPlacement placement;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Collider2D thisCollider;

    [SerializeField] private GameObject clickCollider;
    public GameObject outline;

    public Vector3 offSet;
    public Vector3 permanentOffSet;

    public bool beingPlaced = false;
    public bool canPlace = true;
    public bool justPlaced = false;
    public bool rotate = false;
    public bool outLineRotate = false;
    public bool colliderRotate = false;
    public bool hasRotatingCollider = false;
    public bool destroyed = false;
    public int cost;
    public int typeInt;

    private void Start()
    {
        placement = GameObject.FindGameObjectWithTag("InputManager").GetComponent<BuildPlacement>();
    }

    private void Update()
    {
        if(beingPlaced)
        {
            if (thisCollider.IsTouchingLayers(layer))
            {
                canPlace = false;
            }
            else
            {
                canPlace = true;
            }
        }

        if(placement.placingBuilding)
        {
            clickCollider.SetActive(false);
        }
        else
        {
            clickCollider.SetActive(true);
        }
    }

    public void OnPlace()
    {
        justPlaced = true;
    }

    public void EditPlace()
    {
        if(outline != null)
        {
            outline.SetActive(false);
        }
    }

    public void DestroySelf()
    {
        destroyed = true;
        Destroy(gameObject);
    }
}
