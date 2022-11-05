using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class BuildPlacement : MonoBehaviour
{
    [SerializeField] private GameObject buildingObject;
    [SerializeField] private Camera cam;
    private Building buildingScript;
    private SpriteRenderer spriteRender;

    [SerializeField] private GameObject cursor;

    [SerializeField] private ClickManager click;
    [SerializeField] private BuildGroups grouping;
    [SerializeField] private MenuOpener opener;

    [SerializeField] private GameObject buildMenu;
    [SerializeField] private GameObject[] menuObjects;

    [SerializeField] private Vector3 offSet;
    [SerializeField] private Vector3 tempPos;

    [SerializeField] private GameObject openTiles;
    [SerializeField] private Tilemap map;

    private Materials mat;

    [SerializeField] private Color red;
    [SerializeField] private Color green;
    [SerializeField] private Color normalColor;

    private int currentCost;
    public bool placingBuilding = false;
    private bool canPlace;
    private bool editing = false;


    private void Start()
    {
        mat = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Materials>();
    }

    private void Update()
    {
        if(placingBuilding)
        {
            tempPos = map.WorldToCell(cam.ScreenToWorldPoint(cursor.GetComponent<RectTransform>().position)) + offSet;
            buildingObject.transform.position = map.CellToLocalInterpolated(tempPos + buildingScript.offSet);

            canPlace = buildingScript.canPlace;

            if(canPlace)
            {
                spriteRender.color = green;
            }
            else
            {
                spriteRender.color = red;
            }
        }
    }

    public void Place(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            if (placingBuilding)
            {
                if(canPlace)
                {
                    buildingScript.OnPlace();
                    openTiles.SetActive(false);
                    placingBuilding = false;
                    buildingScript.beingPlaced = false;
                    spriteRender.sortingOrder = 0;
                    spriteRender.color = normalColor;

                    if (!editing)
                    {
                        mat.materials -= currentCost;
                    }
                    else
                    {
                        editing = false;
                    }

                    grouping.AddToList(buildingObject, buildingScript.typeInt);
                }
            }
        }
    }

    public void GetCost(int cost)
    {
        currentCost = cost;
    }

    public void StartBuild(GameObject building)
    {
        if(mat.materials >= currentCost)
        {
            CloseMenu();
            buildingObject = Instantiate(building, cam.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Quaternion.identity);
            buildingScript = buildingObject.GetComponent<Building>();
            spriteRender = buildingObject.GetComponent<SpriteRenderer>();
            placingBuilding = true;
            editing = false;
            buildingScript.beingPlaced = true;
            openTiles.SetActive(true);
            spriteRender.sortingOrder = 100;
        }
    }

    public void MoveBuild()
    {
        buildingObject = click.current.gameObject.GetComponentInParent<Building>().gameObject;
        buildingScript = buildingObject.GetComponent<Building>();
        spriteRender = buildingObject.GetComponent<SpriteRenderer>();
        placingBuilding = true;
        editing = true;
        buildingScript.beingPlaced = true;
        openTiles.SetActive(true);
        spriteRender.sortingOrder = 100;
    }

    public void DestroyBuilding()
    {
        buildingObject = click.current.gameObject.GetComponentInParent<Building>().gameObject;
        buildingScript = buildingObject.GetComponent<Building>();
        buildingScript.DestroySelf();
        mat.materials += buildingScript.cost;
        grouping.RemoveFromList(buildingObject, buildingScript.typeInt);
    }


    public void Rotate(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if(placingBuilding)
            {
                buildingScript.rotate = true;
            }
        }
    }

    public void OpenMenu()
    {
        buildMenu.SetActive(true);
        opener.buildIsOpen = true;
    }

    public void CloseMenu()
    {
        foreach (GameObject menu in menuObjects)
        {
            menu.SetActive(false);
        }

        opener.buildIsOpen = false;
    }
}
