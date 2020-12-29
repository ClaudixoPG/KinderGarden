using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.EventSystems;

public class Plant : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer rend;

    public Element elementNeeded;
    public bool inNeed = true;
    public Timer timer;

    public int satisfactionNeeded;
    private int satisfactionLvl;
    [SerializeField]
    private bool upgradeable;

    public int clicksNeeded;
    private int clicks;
    public PlantState state;

    private Collider col;

    //public bool instanceNext = false;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider>();
        col.enabled = false;
        rend.sprite = sprites[0];
        clicks = 0;
        upgradeable = false;
        timer.Init();
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
            col.enabled = true;
        }
        else
        {
            timer.Restart();
        }
    }

    public void AskElement()
    {
        inNeed = true;
        elementNeeded = (Element)Random.Range(1, System.Enum.GetValues(typeof(Element)).Length-1);
    }

    private void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("ORA");
        if (!upgradeable) return;
        clicks++;
        if (clicks >= clicksNeeded)
        {
            clicks = 0;
            upgradeable = false;
            Upgrade();
        }
    }
    /*
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("ORA");
        if (!upgradeable) return;
        clicks++;
        if(clicks >= clicksNeeded)
        {
            clicks = 0;
            upgradeable = false;
            Upgrade();
        }
    }*/

    public void Upgrade()
    {
        if (state >= PlantState.FRUIT) return;
        col.enabled = false;
        state += 1;
        rend.sprite = sprites[(int)state];
        timer.Restart();
    }
    /*
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("ORA");
        if (!upgradeable) return;
        clicks++;
        if (clicks >= clicksNeeded)
        {
            clicks = 0;
            upgradeable = false;
            Upgrade();
        }
    }*/
}

public enum PlantState
{
    GERMINATION,
    GROWTH,
    BLOSSOM,
    FRUIT
}