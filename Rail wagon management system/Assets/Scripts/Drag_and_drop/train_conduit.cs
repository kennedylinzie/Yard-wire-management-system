using EasyUI.Popup;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class train_conduit : MonoBehaviour
{

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject prefab_holder;
    public GameObject[] shadows;
    public GameObject[] train_parts;
    public Text dropDown_text;
    public GameObject receiver;


    public float x_inc_for_shadow_value;

    public float x_value_for_shadow;
    public float y_value_for_shadow;

    public float y_inc_for_parts;
    public float y_inc_for_shadow;

    public float x_value_for_parts;
    public float y_value_for_parts;
    public float count_before_turn = 0;
    public float count_before_turn_for_parts = 0;

    Action<String> _getvehicle_data;
    Action<String> _train_received;
    Action<String> _get_object_data;


    // 0 head
    // 1 tank
    // 2 passenger
    // 3 hopper 
    // 4 gondola
    // 5 flat wagon
    // 6 covered



    void Start()
    {
        reset_location_data();

        Invoke("CallMeWithWait", 2f);


        
    }
   public void Reload_the_yard() 
    {
        clear_field();
        Invoke("CallMeWithWait", 2f);

    }

    void CallMeWithWait()
    {
        _get_object_data = (all_live_data) => {

            StartCoroutine(get_object_persist_data(all_live_data));

        };



        StartCoroutine(Command.Instance.web_.Get_all_persist_object_data(_get_object_data));
    }

    public IEnumerator get_object_persist_data(string jsonArraystring_)
    {
        //Parsing json array
        JSONArray jsonArray_vehicles = JSON.Parse(jsonArraystring_) as JSONArray;

        for (int i = 0; i < jsonArray_vehicles.Count; i++)
        {
           
            String object_id = jsonArray_vehicles[i].AsObject["object_id"];
            String name = jsonArray_vehicles[i].AsObject["name"];
            float posx = float.Parse(jsonArray_vehicles[i].AsObject["posx"]);
            float posy = float.Parse(jsonArray_vehicles[i].AsObject["posy"]);
            String obj_tag = jsonArray_vehicles[i].AsObject["obj_tag"];

            Engine_reoover_state(object_id,name,posx,posy,obj_tag);

        }

        yield return null;
    }


    public void reload_data()
    {
  
        reset_location_data();
      

    }

 


    public void reset_location_data()
    {
        x_inc_for_shadow_value = 110;
        x_value_for_shadow = -268.781f;
        x_value_for_parts = -268.781f;

        y_inc_for_parts = 0;//100
        y_inc_for_shadow = 0;//100
        y_value_for_shadow = 314.4597f;
        y_value_for_parts = 314.4597f;
    }



    public void clear_field()
    {
        foreach (Transform child in prefab_holder.transform)
        {
            GameObject.Destroy(child.gameObject);
           // reset_location_data();
            Popup.Show("Success", "Station Refreshed", "OK", PopupColor.Green);
        }
    }


    /// <summary>
    /// RECOVERS all data 
    /// </summary>
    public void Engine_reoover_state(String object_id, String name, float posx, float posy, String obj_tag)
    { 


  


        foreach (Transform child in prefab_holder.transform)
        {
            //GameObject.Destroy(child.gameObject);
            //reset_location_data();
            if (child.Find("extra_view") != null)
            {
                child.Find("extra_view").gameObject.SetActive(false);
            }

        }
       




        // float posx = float.Parse(px);
        // float posy = float.Parse(py);

        // string groupproduct = Command.Instance.train_Model.Group_product_;
        // string product = Command.Instance.train_Model.Product_;
        // 0 head
        // 1 pasenger
        // 2 empty
        // 3 covered 
        // 4 coal
        // 5 tank



        string wagon_to_spawn = obj_tag;
        int temp = 6;



        if (wagon_to_spawn.Equals("FLAT WAGON"))
        {
            temp = 5;
        }
        if (wagon_to_spawn.Equals("COVERED"))
        {
            temp = 6;
        }
        if (wagon_to_spawn.Equals("PASSENGER CAR"))
        {
            temp = 2;
        }
        if (wagon_to_spawn.Equals("TANK"))
        {
            temp = 1;
        }
        if (wagon_to_spawn.Equals("HOPPER"))
        {
            temp = 3;
        }
        if (wagon_to_spawn.Equals("GONDOLA"))
        {
            temp = 4;
        }


        int[] layout = { temp };



        for (int parts = 0; parts < layout.Length; parts++)
        {

            GameObject motherBox1 = Instantiate(train_parts[layout[parts]], transform.position, transform.rotation) as GameObject;
            if (count_before_turn_for_parts > 19)
            {
                x_value_for_parts = -268.781f;
                count_before_turn_for_parts = 0;
                y_inc_for_parts += 30;
            }
            motherBox1.GetComponent<RectTransform>().anchoredPosition = new Vector2(x_value_for_parts, y_value_for_parts - y_inc_for_parts);
            motherBox1.transform.SetParent(GameObject.FindGameObjectWithTag("motherbox").transform, false);
            // motherBox1.tag = wagon_to_spawn;
            motherBox1.transform.localPosition = new Vector2(posx, posy);

            // motherBox1.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = numberofWagons;
            // motherBox1.transform.GetChild(1).gameObject.GetComponentInChildren<Text>().text = "......";
            // motherBox1.transform.GetChild(2).gameObject.GetComponentInChildren<Button>().onClick.AddListener(() => {
            //Debug.Log("my tag is : "+motherBox1.tag);
            //Command.Instance.s_drop.Check_wagon_name_match_set_indicator(motherBox1.tag);
            //  motherBox1.GetComponent<SearchableDropDown>().Check_wagon_name_match_set_indicator(motherBox1.tag);


            // });
            motherBox1.gameObject.name = name;


            x_value_for_parts = x_value_for_parts + x_inc_for_shadow_value;
            count_before_turn_for_parts++;
        }

    }





    /// <summary>
    /// norrrrrmallllllllllllllllllllll
    /// </summary>
    public void Engine_start()
    {

        foreach (Transform child in prefab_holder.transform)
        {
            //GameObject.Destroy(child.gameObject);
            //reset_location_data();
            if (child.Find("extra_view") != null)
            {
                child.Find("extra_view").gameObject.SetActive(false);
            }

        }


     
        

        // float posx = float.Parse(px);
        // float posy = float.Parse(py);

        // string groupproduct = Command.Instance.train_Model.Group_product_;
        // string product = Command.Instance.train_Model.Product_;
        // 0 head
        // 1 pasenger
        // 2 empty
        // 3 covered 
        // 4 coal
        // 5 tank



        string wagon_to_spawn = dropDown_text.text; 
        int temp = 6;



        if (wagon_to_spawn.Equals("FLAT WAGON"))
        {
            temp = 5;
        }
        if (wagon_to_spawn.Equals("COVERED"))
        {
            temp = 6;
        }
        if (wagon_to_spawn.Equals("PASSENGER CAR"))
        {
            temp = 2;
        }
        if (wagon_to_spawn.Equals("TANK"))
        {
            temp = 1;
        }
        if (wagon_to_spawn.Equals("HOPPER"))
        {
            temp = 3;
        }
        if (wagon_to_spawn.Equals("GONDOLA"))
        {
            temp = 4;
        }


        int[] layout = { temp };


     
        for (int parts = 0; parts < layout.Length; parts++)
        {

            GameObject motherBox1 = Instantiate(train_parts[layout[parts]], transform.position, transform.rotation) as GameObject;
            if (count_before_turn_for_parts > 19)
            {
                x_value_for_parts = -268.781f;
                count_before_turn_for_parts = 0;
                y_inc_for_parts += 30;
            }
            motherBox1.GetComponent<RectTransform>().anchoredPosition = new Vector2(x_value_for_parts, y_value_for_parts - y_inc_for_parts);
            motherBox1.transform.SetParent(GameObject.FindGameObjectWithTag("motherbox").transform, false);
           // motherBox1.tag = wagon_to_spawn;
            motherBox1.transform.localPosition = new Vector2(0, 0);


            DateTime aDate = DateTime.Now;
            //Debug.Log
            // Format Datetime in different formats and display them  
          
           string special_name = motherBox1.tag + aDate.ToString("MM/dd/yyyy hh:mm tt");


            // motherBox1.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = numberofWagons;
            // motherBox1.transform.GetChild(1).gameObject.GetComponentInChildren<Text>().text = vehicle_number;
            // motherBox1.transform.GetChild(2).gameObject.GetComponentInChildren<Button>().onClick.AddListener(() => {
            //Debug.Log("my tag is : "+motherBox1.tag);
            //Command.Instance.s_drop.Check_wagon_name_match_set_indicator(motherBox1.tag);
            //  motherBox1.GetComponent<SearchableDropDown>().Check_wagon_name_match_set_indicator(motherBox1.tag);


            // });
            motherBox1.gameObject.name = special_name;


            x_value_for_parts = x_value_for_parts + x_inc_for_shadow_value;
            count_before_turn_for_parts++;
        }

    }


  

}
