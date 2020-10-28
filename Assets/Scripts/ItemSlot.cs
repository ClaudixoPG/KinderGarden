using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //REVISA SI ES DEL TIPO QUE CORRESPONDE
        //SI ES DEL TIPO QUE CORRESPONDE, SUPLE NECESIDAD
        //SINO, RETORNA

        var evento = eventData.pointerDrag;
        var plant = GetComponentInChildren<Plant>();

        if (evento != null && plant != null)
        {
            if(plant.inNeeded && plant.needed == evento.GetComponent<UIElement>().delivered)
            {
                plant.inNeeded = false;
                plant.needed = ElementNeeded.Nothing;
            }
        }
        
    }
}
