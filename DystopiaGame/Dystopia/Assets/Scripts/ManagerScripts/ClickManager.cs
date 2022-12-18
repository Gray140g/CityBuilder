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
    [SerializeField] private GameObject[] bottomBarObjects;
    [SerializeField] private Image[] buildingImages;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI[] descTexts;
    [SerializeField] private TextMeshProUGUI[] valTexts;
    [SerializeField] private Slider timeSlider;
    [SerializeField] private TextMeshProUGUI timeSliderText;

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

    public void OnClick(string name, string desc, Sprite image, int type)
    {
        if(!opener.buildIsOpen && !opener.inInfo)
        {
            ClearScreens(type);

            nameText.text = name;
            buildingImages[type].sprite = image;
            
            if(descTexts[type] != null)
            {
                descTexts[type].text = desc;
            }

            if (type != 2 && type != 3 && type != 5)
            {
                valTexts[type].text = current.val + "/" + current.maxVal;
                hasVals = true;
            } 
            else if (type == 5)
            {
                timeSlider.maxValue = current.maxVal;
                timeSlider.value = current.val;
                timeSliderText.text = current.val.ToString() + " seconds";
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
            for (int i = 0; i < bottomBarObjects.Length; i++)
            {
                bottomBarObjects[i].SetActive(true);
            }

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
        if(currentType != 5)
        {
            valTexts[currentType].text = current.val + "/" + current.maxVal;
        }
        else
        {
            timeSliderText.text = current.val.ToString() + " seconds";
            timeSlider.value = current.val;
        }
    }

    public void Add()
    {
        current.workers.Add();
        UpdateVals();
    }

    public void Remove()
    {
        current.workers.Subtract(1, false);
        UpdateVals();
    }

    public void Max()
    {
        current.workers.Maximize();
        UpdateVals();
    }

    public void Min()
    {
        current.workers.Minimize();
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

    public void MoveOrDestroy()
    {
        for (int i = 0; i < bottomBarObjects.Length; i++)
        {
            bottomBarObjects[i].SetActive(false);
        }
    }
}
