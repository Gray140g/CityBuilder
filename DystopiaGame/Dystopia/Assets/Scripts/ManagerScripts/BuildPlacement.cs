using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class BuildPlacement : MonoBehaviour
{
    [SerializeField] private GameObject buildingObject;
    private GameObject currentBuildingType;
    private Building buildingScript;
    private SpriteRenderer spriteRender;
    private BuildTime buildTime;

    [SerializeField] private Camera cam;
    [SerializeField] private CamMove camMove;

    [SerializeField] private GameObject cursor;

    [SerializeField] private ClickManager click;
    [SerializeField] private BuildGroups grouping;
    [SerializeField] private MenuOpener opener;

    [SerializeField] private GameObject buildMenu;
    [SerializeField] private GameObject[] menuObjects;

    [SerializeField] private Vector3 offSet;
    [SerializeField] private Vector3 tempPos;

    private Vector3 originalPos;

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

            if(spriteRender != null)
            {
                if (canPlace)
                {
                    spriteRender.color = green;
                }
                else
                {
                    spriteRender.color = red;
                }
            }
        }
    }

    #region Input

    public void Place(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            if (placingBuilding)
            {
                if(canPlace)
                {
                    openTiles.SetActive(false);
                    placingBuilding = false;
                    buildingScript.beingPlaced = false;

                    if (spriteRender != null)
                    {
                        spriteRender.sortingOrder = 0;
                        spriteRender.color = normalColor;
                        spriteRender = null;
                    }

                    grouping.AddToList(buildingObject, buildingScript.typeInt);
                    camMove.MoveToBuilding(buildingObject.transform.position);

                    if (!editing)
                    {
                        buildTime.OnPlace();
                        mat.materials -= currentCost;
                        StartBuild(currentBuildingType);
                    }
                    else
                    {
                        buildingScript.EditPlace();
                        editing = false;
                    }
                }
            }
        }
    }

    public void EndBuilding(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            if(!editing)
            {
                Destroy(buildingObject);
                openTiles.SetActive(false);
                placingBuilding = false;
            }
            else
            {
                buildingObject.transform.position = originalPos;
                spriteRender.sortingOrder = 0;
                spriteRender.color = normalColor;
                openTiles.SetActive(false);
                placingBuilding = false;
                editing = false;
            }
        }
    }

    public void Rotate(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (placingBuilding)
            {
                buildingScript.rotate = true;
                buildingScript.outLineRotate = true;
            }
        }
    }

    #endregion

    #region MoveBuilding
    public void GetCost(int cost)
    {
        currentCost = cost;
    }

    public void StartBuild(GameObject building)
    {
        if(mat.materials >= currentCost)
        {
            CloseMenu();
            currentBuildingType = building;
            buildingObject = Instantiate(building, cam.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Quaternion.identity);
            buildingScript = buildingObject.GetComponent<Building>();
            buildTime = buildingObject.GetComponent<BuildTime>();
            if (buildTime.outline != null)
            {
                spriteRender = buildTime.outline;
                spriteRender.sortingOrder = 100;
            }
            placingBuilding = true;
            editing = false;
            buildingScript.beingPlaced = true;
            openTiles.SetActive(true);
        }
    }

    public void MoveBuild()
    {
        buildingObject = click.current.gameObject.GetComponentInParent<Building>().gameObject;
        buildingScript = buildingObject.GetComponent<Building>();
        if(buildingScript.outline != null)
        {
            spriteRender = buildingScript.outline.GetComponent<SpriteRenderer>();
            spriteRender.sortingOrder = 100;
        }
        placingBuilding = true;
        originalPos = buildingObject.transform.position;
        editing = true;
        buildingScript.beingPlaced = true;
        openTiles.SetActive(true);
    }

    public void DestroyBuilding()
    {
        buildingObject = click.current.gameObject.GetComponentInParent<Building>().gameObject;
        buildingScript = buildingObject.GetComponent<Building>();
        buildingScript.DestroySelf();
        mat.materials += buildingScript.cost;
        grouping.RemoveFromList(buildingObject, buildingScript.typeInt);
    }

    #endregion

    #region Menu
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

    #endregion
}
