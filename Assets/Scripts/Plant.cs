using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.EventSystems;

public class Plant : MonoBehaviour, IPointerDownHandler
{
    public Sprite[] sprites;
    public SpriteRenderer renderer;

    public Element needed = Element.Water;
    public bool inNeed = true;
    public Timer timer;

    public int clicks = 0;
    public PlantState state = PlantState.Germination;

    public bool instanceNext = false;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[0];
    }

    private void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!inNeed)
        {
            clicks++;
        }
    }

}

public enum PlantState
{
    Germination,
    Growth,
    Blossom,
    Fruit
}