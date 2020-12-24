using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pot : MonoBehaviour, IDropHandler
{
    Plant plant;

    public void OnDrop(PointerEventData eventData)
    {
        var evento = eventData.pointerDrag;
        if (evento == null) return;

        if (plant != null)
        {
            //REVISA SI ES DEL TIPO QUE CORRESPONDE
            //SI ES DEL TIPO QUE CORRESPONDE, SUPLE NECESIDAD
            //SINO, RETORNA
            plant.ReceiveElement(evento.GetComponent<UIElement>().delivered);
        }
        else if(evento.GetComponent<UIElement>().delivered == Element.SEED)
        {
            PlantController p = FindObjectOfType<PlantController>();
            plant = Instantiate(p.GetPlantPrefab(), transform).GetComponent<Plant>();
        }
    }
}
