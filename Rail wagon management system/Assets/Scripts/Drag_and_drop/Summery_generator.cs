using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summery_generator : MonoBehaviour
{
    public float time;
    public float repeat_rate;

    public GameObject PanelMenu;
    public GameObject itemli;
    public GameObject _1;
    public GameObject _2;
    public GameObject _3;
    public GameObject _4;
    public GameObject _5;
    public GameObject _6;
    public GameObject _7;
    public GameObject _8;
    public GameObject _10;
    public GameObject _11;
    public GameObject _12;
    public GameObject _13;
 

    Action<string> _get_persistent_data_;
    Action<string> _get_persistent_data_for_summary;
   public GameObject[] houses_to_clean;




    public void clear_field()
    {
        for (int i = 0; i < houses_to_clean.Length; i++)
        {
            GameObject pawn = houses_to_clean[i];
            foreach (Transform child in pawn.transform)
            {
                GameObject.Destroy(child.gameObject);

                // Popup.Show("Success", "Station Refreshed", "OK", PopupColor.Green);
            }
        }
        
      
        
    }

    private void Start()
    {




        //Loads_summary();


        Start_timing();
    }


    void start_timer()
    {
        clear_field();
        Loads_summary();
    }
    public void Stop_date_coroutine()
    {
        //StopCoroutine("Set_the_time_and_date");
        CancelInvoke("start_timer");
    }
    public void Start_timing()
    {
        InvokeRepeating("start_timer", time, repeat_rate);
    }


    public void Loads_summary() 
    {

        _get_persistent_data_ = (all_live_data) => {

            StartCoroutine(memory_regression(all_live_data));

        };

        StartCoroutine(Command.Instance.web_.Get_all_persist_object_data(_get_persistent_data_));

        _get_persistent_data_for_summary = (all_live_data) => {

            StartCoroutine(summery_loader(all_live_data));

        };
    }


    public IEnumerator memory_regression(string jsonArraystring_)
    {
        //Parsing json array
        JSONArray jsonArray_vehicles = JSON.Parse(jsonArraystring_) as JSONArray;

        for (int i = 0; i < jsonArray_vehicles.Count; i++)
        {

            //String Vehicle_Type = jsonArray_vehicles[i].AsObject["object_id"];
            String name = jsonArray_vehicles[i].AsObject["name"];
             Debug.Log("............."+name);
            StartCoroutine(Command.Instance.web_.Get_object_data_for_summary(name,_get_persistent_data_for_summary));
          

        }

        yield return null;
    }


    public IEnumerator summery_loader(string jsonArraystring_)
    {
        
        //Parsing json array
        JSONArray jsonArray_vehicles = JSON.Parse(jsonArraystring_) as JSONArray;

        for (int i = 0; i < jsonArray_vehicles.Count; i++)
        {

            //String Vehicle_Type = jsonArray_vehicles[i].AsObject["object_id"];
            String Line = jsonArray_vehicles[i].AsObject["Line"];
            String Wagon_type = jsonArray_vehicles[i].AsObject["Wagon_type"];
            String Vehicle = jsonArray_vehicles[i].AsObject["Vehicle"];


            fill_the_list_train_summary(Line,Wagon_type,Vehicle);

        }

        yield return null;
    }




    public void fill_the_list_train_summary(string line_number, string wagon_type_, string vehicle_number_)
    {
        if (line_number.Equals(""))
        {
            return;
        }

        GameObject item = Instantiate(itemli);


        int data = int.Parse(line_number);

        Debug.Log("the data log is "+data);


        switch (data)
        {
            case 1:
                item.transform.SetParent(_1.transform);
                break;
            case 2:
                item.transform.SetParent(_2.transform);
                break;
            case 3:
                item.transform.SetParent(_3.transform);
                break;
            case 4:
                item.transform.SetParent(_4.transform);
                break;
            case 5:
                item.transform.SetParent(_5.transform);
                break;
            case 6:
                item.transform.SetParent(_6.transform);
                break;
            case 7:
                item.transform.SetParent(_7.transform);
                break;
            case 8:
                item.transform.SetParent(_8.transform);
                break;
            case 10:
                item.transform.SetParent(_10.transform);
                break;
            case 11:
                item.transform.SetParent(_11.transform);
                break;
            case 12:
                item.transform.SetParent(_12.transform);
                break;
            case 13:
                item.transform.SetParent(_13.transform);
                break;
           
        }


        
        //item.transform.localScale = Vector3.zero;
        //item.transform.localPosition = Vector3.zero;
       
            //fill information
            item.transform.Find("wagon_number").GetComponent<Text>().text = vehicle_number_;
            item.transform.Find("series").GetComponent<Text>().text = wagon_type_;
            item.transform.localScale = new Vector3(0.81463f, 0.81463f, 0.81463f);
        // item.transform.Find("Series").GetComponent<Text>().text = series_;
        //item.transform.Find("status").GetComponent<Text>().text = status_;





    }
}
