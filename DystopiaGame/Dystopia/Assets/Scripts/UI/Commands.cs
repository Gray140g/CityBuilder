using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Commands : MonoBehaviour
{
    [SerializeField] MenuOpener opener;

    [SerializeField] private GameObject bar;
    [SerializeField] private TMP_InputField text;

    public void Use(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            if(!opener.commandIsOpen)
            {
                bar.SetActive(true);
            }
        }
    }

    public void Select(string str)
    {
        opener.commandIsOpen = true;
    }

    public void Deselect(string str)
    {
        opener.commandIsOpen = false;
        text.text = "";
    }

    public void Input(string input)
    {
        if(input.ToLower() == "/pluselites")
        {
            AddPop(0);
        }
        else if(input.ToLower() == "/pluspeasants")
        {
            AddPop(1);
        }
        else if(input.ToLower() == "/plusfood")
        {
            AddFood();
        }
        else if(input.ToLower() == "/plusmoney")
        {
            AddMoney();
        }
        else if(input.ToLower() == "/unlockbuildings")
        {
            UnlockBuildings();
        }
        else if(input.ToLower() == "/reset")
        {
            TimeManager time = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TimeManager>();
            time.Reload();
        }
        else if(input.ToLower() == "/quit")
        {
            Application.Quit();
        }

        Deselect("hi");
        bar.SetActive(false);
    }

    #region DoCommands

    private void AddPop(int index)
    {
        Population pop = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Population>();

        if(index == 0)
        {
            pop.AddElites(10000);
        }
        else
        {
            pop.AddPeasants(10000);
        }
    }

    private void AddFood()
    {
        Food food = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Food>();
        food.food += 10000;
    }

    private void AddMoney()
    {
        Materials mat = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Materials>();
        mat.materials += 10000;
    }

    private void UnlockBuildings()
    {
        TechTree tree = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<TechTree>();

        for (int i = 0; i < tree.isUnlocked.Length; i++)
        {
            tree.isUnlocked[i] = true;
        }

        tree.CheckUnlocks();
    }

    #endregion
}
