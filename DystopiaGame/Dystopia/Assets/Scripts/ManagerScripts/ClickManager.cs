using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private BuildPlacement placement;
    [SerializeField] private MenuOpener opener;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject clicker;
    [SerializeField] private GameObject cursor;
    [SerializeField] private PlayerInput inp;
    [SerializeField] private Vector3 offSet;

    public BuildClick current;
    public List<BuildClick> collisions = new List<BuildClick>();

    [SerializeField] private GameObject[] screens;
    [SerializeField] private Image[] buildingImages;
    [SerializeField] private TextMeshProUGUI[] nameTexts;
    [SerializeField] private TextMeshProUGUI[] valTexts;
    private bool hasVals;
    private int currentType;

    private void Update()
    {
        clicker.transform.position = cam.ScreenToWorldPoint(cursor.GetComponent<RectTransform>().position) + offSet;

        if (current != null)
        {
            if(hasVals)
            {
                UpdateVals();
            }
        }
    }

    public void Click(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            if(!placement.placingBuilding)
            {
                if (collisions.Count >= 1)
                {
                    if(current != null)
                    {
                        if(current.outline != null)
                        {
                            current.outline.SetActive(false);
                        }
                    }

                    current = collisions[0];

                    for (int i = 1; i < collisions.Count; i++)
                    {
                        if (collisions[i] != null)
                        {
                            if (collisions[i].transform.position.y < collisions[i - 1].transform.position.y)
                            {
                                current = collisions[i];
                            }
                        }
                    }

                    current.Click();
                }
            }
        }
    }

    public void OnClick(string name, Sprite image, int type)
    {
        if(!opener.buildIsOpen)
        {
            ClearScreens(type);

            nameTexts[type].text = name;
            buildingImages[type].sprite = image;

            if (type != 2 && type != 3)
            {
                valTexts[type].text = current.val + "/" + current.maxVal;
                hasVals = true;
            }
            else
            {
                hasVals = false;
            }

            currentType = type;
            opener.editIsOpen = true;

            if(current.outline != null)
            {
                current.outline.SetActive(true);
            }
        }
    }

    public void ClearScreens(int type)
    {
        if(!opener.buildIsOpen)
        {
            for (int i = 0; i < screens.Length; i++)
            {
                if (i != type)
                {
                    screens[i].SetActive(false);
                }
                else
                {
                    screens[i].SetActive(true);
                }
            }
        }
    }

    private void UpdateVals()
    {
        valTexts[currentType].text = current.val + "/" + current.maxVal;
    }

    public void Add()
    {
        current.Add();
        UpdateVals();
    }

    public void Remove()
    {
        current.Remove();
        UpdateVals();
    }

    public void ChangeType(int newType)
    {
        current.Change(newType);
    }

    public void Exit()
    {
        if (current.outline != null)
        {
            current.outline.SetActive(false);
        }
    }
}
