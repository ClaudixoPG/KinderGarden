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
        //Debug.Log(GetComponentInChildren<Plant>());

        if (evento != null && plant != null)
        {
            if(plant.inNeeded && plant.needed == evento.GetComponent<UIElement>().delivered)
            {
                plant.inNeeded = false;
                plant.needed = ElementNeeded.Nothing;
            }
            //GEt
            /*if(evento as Plant)
            {
                if(evento.inNeeded && evento.needed == GetComponent<UIElement>().delivered)
                {
                    evento.inNeeded = false;
                }
                
            }*/
        }

        ////////// UPDATE //////////


        /*Debug.Log("OnDrop");
        Debug.Log(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
        Debug.Log("Jump");
        Debug.Log(GetComponent<RectTransform>().anchoredPosition);
        //revisar si lo aplica a la planta que corresponde

        //revisar si lo devuelve al slot que corresponde

        //if(eventData.pointerDrag != null)
        //{
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        //}*/
    }
}
