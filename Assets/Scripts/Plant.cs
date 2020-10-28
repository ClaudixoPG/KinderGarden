using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Plant : Element
{
    public PlantState state = PlantState.Germination;
    public Sprite[] imgs; 
    public bool instanceNext = false;
}

public enum PlantState
{
    Germination,
    Growth,
    Blossom,
    Fruit
}