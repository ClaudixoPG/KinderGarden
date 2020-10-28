using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Element : MonoBehaviour, IPointerDownHandler
{
    public ElementNeeded needed = ElementNeeded.Water;
    public bool inNeeded = true;
    public int clicks = 0;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!inNeeded)
        {
            clicks++;
            //Debug.Log(clicks);
        }
    }

}

public enum ElementNeeded
{
    Water,
    Sun ,
    Fertilizer,
    Nothing
}
