using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class active_train_motherbox : MonoBehaviour
{
    Action<String> _createItemsCallback;
    public GameObject itemli;




    // Start is called before the first frame update
    void Start()
    {


        _createItemsCallback = (jsonArraystring) => {

            StartCoroutine(CreateItemsRoutin(jsonArraystring));

        };
        Create_items();

        Debug.Log("............LOADED..............");
    }

    public void starter_refresh_starter()
    {

        Invoke("Create_items", .5f);
    }

   

    public void Create_items()
    {
        _createItemsCallback = (jsonArraystring) => {

            StartCoroutine(CreateItemsRoutin(jsonArraystring));

        };
        StartCoroutine(Command.Instance.web_.Get_all_unreleased_vehicles(_createItemsCallback));
        clear_field();

    }

    public void clear_field()
    {
        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
         
        }
    }



    IEnumerator CreateItemsRoutin(string jsonArraystring)
    {
        //Parsing json array
        JSONArray jsonArray = JSON.Parse(jsonArraystring) as JSONArray;

        for (int i = 0; i < jsonArray.Count; i++)
        {
          
           // String itemId = jsonArray[i].AsObject["itemID"];

            //JSONObject itemInfor = new JSONObject();

          
         
            //Instantiate GameObject (itemslot prefabs)
            //Resources.Load("enemy", typeof(GameObject))) as GameObject;
            GameObject item = Instantiate(itemli);
            item.transform.SetParent(this.transform);
            //item.transform.localScale = Vector3.zero;
            //item.transform.localPosition = Vector3.zero;

            //fill information
            item.transform.Find("Vehicle_Type").GetComponent<Text>().text = jsonArray[i].AsObject["Vehicle_Type"];
            item.transform.Find("Yard_Sector").GetComponent<Text>().text = jsonArray[i].AsObject["Yard_Sector"];
            item.transform.Find("Line").GetComponent<Text>().text = jsonArray[i].AsObject["Line"];
            item.transform.Find("Vehicle").GetComponent<Text>().text = jsonArray[i].AsObject["Vehicle"];
            item.transform.Find("No_of_wagons").GetComponent<Text>().text = jsonArray[i].AsObject["No_of_wagons"];
            item.transform.Find("Wagon_type").GetComponent<Text>().text = jsonArray[i].AsObject["Wagon_type"];
            item.transform.Find("Series").GetComponent<Text>().text = jsonArray[i].AsObject["Series"];
            item.transform.Find("Date_Hour_Last_Event").GetComponent<Text>().text = jsonArray[i].AsObject["Date_Hour_Last_Event"];
            item.transform.Find("Status").GetComponent<Text>().text = jsonArray[i].AsObject["Status"];

            //continue to the next item
            yield return null;
        }


    }

 
}
