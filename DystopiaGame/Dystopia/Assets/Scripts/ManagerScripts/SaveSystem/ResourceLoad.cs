using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ResourceLoad
{
    public int peasantPop;
    public int housedPeasants;
    public int workingPeasants;
    public int totalPeasantHousing;
    public int availablePeasantHousing;

    public int elitePop;
    public int housedElites;
    public int workingElites;
    public int totalEliteHousing;
    public int availableEliteHousing;

    public int food;
    public int money;
    public int propaganda;
    public int ignorance;
    public int influence;

    public List<int> peasantHungerLevels;
    public List<int> eliteHungerLevels;

    public float balance;
    public float happiness;
    public float fear;
    public float patriotism;

    public int day;
    public int month;
    public int year;
    public int hour;
    public int min;
}
