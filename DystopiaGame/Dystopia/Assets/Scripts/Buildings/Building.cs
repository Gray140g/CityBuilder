using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Collider2D thisCollider;
    [SerializeField] private LayerMask layer;
    private BuildPlacement placement;

    [SerializeField] private GameObject clickCollider;

    public Vector3 offSet;

    public bool beingPlaced = false;
    public bool canPlace = true;
    public bool justPlaced = false;
    public bool rotate = false;
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

    public void DestroySelf()
    {
        destroyed = true;
        Destroy(gameObject);
    }
}
