using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.EventSystems;

public class Plant : MonoBehaviour, IPointerDownHandler
{
    public Sprite[] sprites;
    private SpriteRenderer rend;

    public Element elementNeeded;
    public bool inNeed = true;
    public Timer timer;

    public int satisfactionNeeded;
    private int satisfactionLvl;
    private bool upgradeable;

    public int clicksNeeded;
    private int clicks;
    public PlantState state;

    public bool instanceNext = false;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = sprites[0];
        clicks = 0;
        upgradeable = false;
    }

    public void ReceiveElement(Element e)
    {
        if (!inNeed) return;
        if (!elementNeeded.Equals(e)) return;
        inNeed = false;
        elementNeeded = Element.NONE;
        satisfactionLvl++;
        if(satisfactionLvl >= satisfactionNeeded)
        {
            upgradeable = true;
        }
        else
        {
            timer.Restart();
        }
    }

    public void AskElement()
    {
        inNeed = true;
        elementNeeded = (Element)Random.Range(0, System.Enum.GetValues(typeof(Element)).Length);
    }

    private void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!upgradeable) return;

        clicks++;
        if(clicks >= clicksNeeded)
        {
            clicks = 0;
            upgradeable = false;
            Upgrade();
        }
    }

    public void Upgrade()
    {
        if (state >= PlantState.FRUIT) return;
        state += 1;
        rend.sprite = sprites[(int)state];
        timer.Restart();
    }

}

public enum PlantState
{
    GERMINATION,
    GROWTH,
    BLOSSOM,
    FRUIT
}