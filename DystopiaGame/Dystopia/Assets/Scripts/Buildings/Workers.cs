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

    //0 = money, 1 = food, 2 = propaganda, 3 = police
    public int type;

    private void Start()
    {
        pop = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Population>();
        mat = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Materials>();
        food = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Food>();
        prop = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Propaganda>();
        crime = GameObject.FindGameObjectWithTag("BalanceManager").GetComponent<Crime>();
    }

    public void Add()
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

    public void Maximize()
    {
        if(type == 2 || type == 3)
        {
            if((pop.totalElites - pop.workingElites) > (maxWorkers - workers))
            {
                int dif = maxWorkers - workers;
                pop.workingElites += dif;
                workers = maxWorkers;
                thisClick.val = maxWorkers;

                if (type == 2)
                {
                    prop.workers += dif;
                }
                else
                {
                    crime.police += dif;
                }
            }
            else
            {
                int unemployed = pop.totalElites - pop.workingElites;
                pop.workingElites = pop.totalElites;
                workers += unemployed;
                thisClick.val += unemployed;

                if (type == 2)
                {
                    prop.workers += unemployed;
                }
                else
                {
                    crime.police += unemployed;
                }
            }
        }
        else
        {
            if ((pop.totalPeasants - pop.workingPeasants) > (maxWorkers - workers))
            {
                int dif = maxWorkers - workers;
                pop.workingPeasants += dif;
                workers = maxWorkers;
                thisClick.val = maxWorkers;

                if (type == 0)
                {
                    mat.workers += dif;
                }
                else
                {
                    food.workers += dif;
                }
            }
            else
            {
                int unemployed = pop.totalPeasants - pop.workingPeasants;
                pop.workingPeasants = pop.totalPeasants;
                workers += unemployed;
                thisClick.val += unemployed;

                if (type == 0)
                {
                    mat.workers += unemployed;
                }
                else
                {
                    food.workers += unemployed;
                }
            }
        }

        thisClick.max = false;
    }

    public void Minimize()
    {
        if(type == 0)
        {
            mat.workers -= workers;
            pop.workingPeasants -= workers;
        }
        else if(type == 1)
        {
            food.workers -= workers;
            pop.workingPeasants -= workers;
        }
        else if(type == 2)
        {
            prop.workers -= workers;
            pop.workingElites -= workers;
        }
        else if(type == 3)
        {
            crime.police -= workers;
            pop.workingElites -= workers;
        }

        thisClick.val = 0;
        workers = 0;

        thisClick.min = false;
    }

    public void TypeChange()
    {
        if (thisClick.typeForChange != type)
        {
            type = thisClick.typeForChange;
        }
    }
}
