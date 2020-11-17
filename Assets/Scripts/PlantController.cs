using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlantController : MonoBehaviour
{
    //public List<Plant> plants;
    public GameObject []pots;
    public float targetTime = 10.0f;
    public GameObject[] plantPref;
    public List<Plant> plants = new List<Plant>();


    public GameObject GetPlantPrefab()
    {
        return plantPref[Random.Range(0, plantPref.Length)];
    }

    private void Awake()
    {
        //var aux = new Plant();
        var aux = Instantiate(plantPref[0], pots[0].GetComponent<RectTransform>());
        aux.transform.SetParent(pots[0].transform);
        plants.Add(aux.GetComponent<Plant>());
    }
    /*
    void Update()
    {
        targetTime -= Time.deltaTime;

        foreach (Plant p in plants.ToList())
        {
            //tiempo para actualizar necesidad
            if (!p.inNeed && targetTime <= 0.0f)
            {
                var aux = Random.Range(0, 4);

                if ((Element)aux != Element.Nothing)
                {
                    p.inNeed = true;
                    p.needed = (Element)aux;
                }

                targetTime = 10.0f;
            }
            var plant_img = p.gameObject.GetComponent<Image>();//.sprite;
            //Debug.Log(p.gameObject.GetComponent<Image>().sprite);

            switch (p.clicks)
            {
                //aqui debiera cambiar la imagen
                
                case 0: p.state = PlantState.Germination;
                    plant_img.sprite = p.sprites[0];
                    break;
                case 150: p.state = PlantState.Growth;
                    plant_img.sprite = p.sprites[1];
                    break;
                case 300: p.state = PlantState.Blossom;
                    plant_img.sprite = p.sprites[2];
                    break;
                case 450: p.state = PlantState.Fruit;
                    plant_img.sprite = p.sprites[3];
                    if (plants.Count < pots.Length && !p.instanceNext)
                    {
                        var aux = Random.Range(0, plantPref.Length);

                        //var newPlant = new Plant();//aqui debiera ser el prefab 
                        var newPlant = Instantiate(plantPref[aux], pots[plants.Count].GetComponent<RectTransform>()); 

                        plants.Add(newPlant.GetComponent<Plant>());
                        p.instanceNext = true;
                        //newPlant.GetComponent<RectTransform>().anchoredPosition = pots[plants.Count].GetComponent<RectTransform>().anchoredPosition;
                        //instantiate prefab in pot pos
                    }
                    else
                    {
                        //go to win
                    }
                    break;
            }
        }
    }*/

}
