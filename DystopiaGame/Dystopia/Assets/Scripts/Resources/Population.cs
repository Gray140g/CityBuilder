using UnityEngine;

public class Population : MonoBehaviour
{
    [SerializeField] private BuildGroups grouping;

    public int totalPeasants;
    public int housedPeasants;
    public int homelessPeasants;
    public int workingPeasants;

    public int totalElites;
    public int housedElites;
    public int homelessElites;
    public int workingElites;

    [SerializeField] private int availablePeasantHousing;
    [SerializeField] private int availableEliteHousing;

    public void AddPeasants(int people)
    {
        if(people <= availablePeasantHousing)
        {
            availablePeasantHousing -= people;
            housedPeasants += people;
        }
        else
        {
            people -= availablePeasantHousing;
            homelessPeasants += people;
            housedPeasants += availablePeasantHousing;
            availablePeasantHousing = 0;
        }

        totalPeasants = housedPeasants + homelessPeasants;
    }

    public void AddElites(int people)
    {
        if (people <= availableEliteHousing)
        {
            availableEliteHousing -= people;
            housedElites += people;
        }
        else
        {
            people -= availableEliteHousing;
            homelessElites += people;
            housedElites += availableEliteHousing;
            availableEliteHousing = 0;
        }

        totalElites = housedElites + homelessElites;
    }

    public void AddHousing(int rooms, bool isElite)
    {
        if(isElite)
        {
            availableEliteHousing += rooms;
            CheckEliteAvailability();
        }
        else
        {
            availablePeasantHousing += rooms;
            CheckPeasantAvailability();
        }
    }

    private void CheckPeasantAvailability()
    {
        if (homelessPeasants > 0)
        {
            if (homelessPeasants <= availablePeasantHousing)
            {
                availablePeasantHousing -= homelessPeasants;
                housedPeasants += homelessPeasants;
                homelessPeasants = 0;
            }
            else
            {
                homelessPeasants -= availablePeasantHousing;
                housedPeasants += availablePeasantHousing;
                availablePeasantHousing = 0;
            }
        }
    }

    private void CheckEliteAvailability()
    {
        if (homelessElites > 0)
        {
            if (homelessElites <= availableEliteHousing)
            {
                availableEliteHousing -= homelessElites;
                housedElites += homelessElites;
                homelessElites = 0;
            }
            else
            {
                homelessElites -= availableEliteHousing;
                housedElites += availableEliteHousing;
                availableEliteHousing = 0;
            }
        }
    }

    #region KillRegion

    public void KillPeasants(int kill)
    {
        if(totalPeasants - workingPeasants < kill)
        {
            int need = kill;

            foreach (GameObject building in grouping.materialGatheringBuildings)
            {
                Workers workStation = building.GetComponent<Workers>();
                if (workStation.workers > 0)
                {
                    if (workStation.workers - need > 0)
                    {
                        workStation.workers -= need;
                        workStation.thisClick.val -= need;
                        workStation.Subtract(need, true);
                        need = 0;
                    }
                    else
                    {
                        workStation.Subtract(workStation.workers, true);
                        workStation.workers = 0;
                        workStation.thisClick.val = 0;
                        need -= workStation.workers;
                    }
                }
            }

            if(need > 0)
            {
                foreach (GameObject building in grouping.foodGatheringBuildings)
                {
                    Workers workStation = building.GetComponent<Workers>();
                    if (workStation.workers > 0)
                    {
                        if (workStation.workers - need > 0)
                        {
                            workStation.workers -= need;
                            workStation.thisClick.val -= need;
                            workStation.Subtract(need, true);
                            need = 0;
                        }
                        else
                        {
                            workStation.Subtract(workStation.workers, true);
                            workStation.workers = 0;
                            workStation.thisClick.val = 0;
                            need -= workStation.workers;
                        }
                    }
                }
            }
        }

        if(homelessPeasants > kill)
        {
            homelessPeasants -= kill;
        }
        else
        {
            kill -= homelessPeasants;
            homelessPeasants = 0;
            housedPeasants -= kill;
            availablePeasantHousing += kill;
        }

        totalPeasants = homelessPeasants + housedPeasants;

        if(workingPeasants >= totalPeasants)
        {
            workingPeasants = totalPeasants;
        }
    }

    public void KillElites(int kill)
    {
        if (totalElites - workingElites < kill)
        {
            int need = kill;

            foreach (GameObject building in grouping.eliteWorkBuildings)
            {
                Workers workStation = building.GetComponent<Workers>();
                if (workStation.workers > 0)
                {
                    if (workStation.workers - need > 0)
                    {
                        workStation.workers -= need;
                        workStation.thisClick.val -= need;
                        workStation.Subtract(need, true);
                        need = 0;
                    }
                    else
                    {
                        workStation.Subtract(workStation.workers, true);
                        workStation.workers = 0;
                        workStation.thisClick.val = 0;
                        need -= workStation.workers;
                    }
                }
            }
        }

        if (homelessElites > kill)
        {
            homelessElites -= kill;
        }
        else
        {
            kill -= homelessElites;
            homelessElites = 0;
            housedElites -= kill;
            availableEliteHousing += kill;
        }

        totalElites = housedElites + homelessElites;

        if (workingElites > totalElites)
        {
            workingElites = totalElites;
        }
    }

    #endregion
}
