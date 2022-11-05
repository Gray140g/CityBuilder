using UnityEngine;

public class Workers : MonoBehaviour
{
    private Population pop;
    private Materials mat;
    private Food food;
    private Propaganda prop;
    private Crime crime;

    public BuildClick thisClick;

    public int workers;
    public int maxWorkers;
    public int type;

    private void Start()
    {
        pop = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Population>();
        mat = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Materials>();
        food = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Food>();
        prop = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Propaganda>();
        crime = GameObject.FindGameObjectWithTag("BalanceManager").GetComponent<Crime>();
    }

    void Update()
    {
        if (thisClick.added)
        {
            Add();
        }

        if (thisClick.subtracted)
        {
            Subtract(1, false);
        }
    }

    private void Add()
    {
        if (workers < maxWorkers)
        {
            if(type == 2)
            {
                if (pop.totalElites - pop.workingElites > 0)
                {
                    workers++;
                    thisClick.val++;
                    pop.workingElites++;
                    prop.workers++;
                }
            }
            else if(type == 3)
            {
                if (pop.totalElites - pop.workingElites > 0)
                {
                    workers++;
                    thisClick.val++;
                    pop.workingElites++;
                    crime.police++;
                }
            }
            else
            {
                if (pop.totalPeasants - pop.workingPeasants > 0)
                {
                    workers++;
                    thisClick.val++;
                    pop.workingPeasants++;
                    if(type == 0)
                    {
                        mat.workers++;
                    }
                    else
                    {
                        food.workers++;
                    }
                }
            }
        }

        thisClick.added = false;
    }

    public void Subtract(int sub, bool onKill)
    {
        if (workers > 0)
        {
            if(!onKill)
            {
                workers -= sub;
                thisClick.val -= sub;
            }

            if(type == 0)
            {
                mat.workers -= sub;
                pop.workingPeasants -= sub;
            }
            else if(type == 1)
            {
                food.workers -= sub;
                pop.workingPeasants -= sub;
            }
            else if(type == 2)
            {
                prop.workers -= sub;
                pop.workingElites -= sub;
            }
            else
            {
                crime.police -= sub;
                pop.workingElites -= sub;
            }
        }

        thisClick.subtracted = false;
    }
}
