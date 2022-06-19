using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.Popup;
using System;
using SimpleJSON;

public class Manager : MonoBehaviour
{
   

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject prefab_holder;
    public GameObject[] shadows;
    public GameObject[] train_parts;
   

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


        //Invoke("CallMeWithWait", 2f);

        
      
    }

    void CallMeWithWait()
    {
        _getvehicle_data = (all_live_data) => {

            StartCoroutine(CreateVehicleRoutin(all_live_data));

        };



        StartCoroutine(Command.Instance.web_.Get_all_unreleased_vehicles(_getvehicle_data));
    }

   public void reload_data()
    {
        clear_field();
        reset_location_data();
        _getvehicle_data = (all_live_data) => {

            StartCoroutine(CreateVehicleRoutin(all_live_data));

        };

        StartCoroutine(Command.Instance.web_.Get_all_unreleased_vehicles(_getvehicle_data));
    }

    public IEnumerator CreateVehicleRoutin(string jsonArraystring_)
    {
        //Parsing json array
        //Debug.Log(jsonArraystring_);
       
        JSONArray jsonArray_vehicles = JSON.Parse(jsonArraystring_) as JSONArray;

        

        if (jsonArraystring_.Equals(""))
        {

        }
        else { 

        for (int i = 0; i < jsonArray_vehicles.Count; i++)
        {
            bool isDone = false;
            string vehicle_number = jsonArray_vehicles[i].AsObject["Vehicle"];

            string transaction_id = jsonArray_vehicles[i].AsObject["transaction_id"];
            string Relesed_from_system = jsonArray_vehicles[i].AsObject["Relesed_from_system"];
            string Vehicle_Type = jsonArray_vehicles[i].AsObject["Vehicle_Type"];
            string Yard_Sector = jsonArray_vehicles[i].AsObject["Yard_Sector"];
            string Line = jsonArray_vehicles[i].AsObject["Line"];
           // string No_of_wagons = jsonArray_vehicles[i].AsObject["No_of_wagons"];
            string Wagon_type = jsonArray_vehicles[i].AsObject["Wagon_type"];
            string Series = jsonArray_vehicles[i].AsObject["Series"];
            string Date_Hour_Last_Event = jsonArray_vehicles[i].AsObject["Date_Hour_Last_Event"];
            string Status = jsonArray_vehicles[i].AsObject["Status"];

            float posx = float.Parse(jsonArray_vehicles[i].AsObject["posX"]);
            float posy = float.Parse(jsonArray_vehicles[i].AsObject["posY"]);

 recover_engine_state_Engine_start(transaction_id,Relesed_from_system,Vehicle_Type,vehicle_number,Yard_Sector,Line,Wagon_type,Series,Date_Hour_Last_Event,Status, posx,posy);

        }
        }
        yield return null;
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
            reset_location_data();
            Popup.Show("Success", "Station Refreshed", "OK", PopupColor.Green);
        }
    }







    public IEnumerator setup_train(string jsonArraystring_)
    {

        Debug.Log(jsonArraystring_);
        ///Popup.Show("Success", "Ship Added successfully.", "OK", PopupColor.Green);

        yield return null;
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

       
        /*
        if (Command.Instance.dd_ != null) 
        {
            Command.Instance.dd_.clean_POPUPS();
        }
        */

     

       
         string transactionid = Command.Instance.train_Model.transaction_id_;
         string releasedfromsystem = Command.Instance.train_Model.Relesed_from_system_;
         string vehicletype = Command.Instance.train_Model.Vehicle_Type_;
         string vehicle_number = Command.Instance.train_Model.vehicle_number_;
         string yardsector = Command.Instance.train_Model.Yard_Sector_;
         string line = Command.Instance.train_Model.Line_;
       //  string numberofWagons = Command.Instance.train_Model.No_of_wagons_;
         string wagontype = Command.Instance.train_Model.Wagon_type_;
         string series = Command.Instance.train_Model.Series_;
       // string lastevent = Command.Instance.train_Model.Last_event_;
         string dayhourlastevent = Command.Instance.train_Model.Date_Hour_Last_Event_;
         string status = Command.Instance.train_Model.Status_;

        string px = Command.Instance.train_Model.posx;
        string py = Command.Instance.train_Model.posx;

        if (px.Equals("") || py.Equals(""))
        {
            px = "0";
            py = "0";
        }
       

        float posx = float.Parse(px);
         float posy = float.Parse(py);
        // string groupproduct = Command.Instance.train_Model.Group_product_;
        // string product = Command.Instance.train_Model.Product_;
        // 0 head
        // 1 pasenger
        // 2 empty
        // 3 covered 
        // 4 coal
        // 5 tank
      



        if (transactionid.Equals("") || releasedfromsystem.Equals("") || vehicletype.Equals("") || yardsector.Equals("") || line.Equals("") 
            || wagontype.Equals("") || series.Equals("") || dayhourlastevent.Equals("") || status.Equals("") || px.Equals("") || py.Equals(""))
        {
           // Debug.Log("all fields need to be filled");
           
                Popup.Show("Error", "All fields need to be filled!", "OK", PopupColor.Red);
            
            return;
        }
        /*
        _train_received = (all_live_data) => {

            StartCoroutine(setup_train(all_live_data));

        };

        StartCoroutine(Command.Instance.web_.Train_added_to_platform(vehicle_number, _train_received));
        */


        foreach (Transform child in prefab_holder.transform)
        {
           
            if (child.gameObject.name == vehicle_number)
            {
                Popup.Show("Error", "There is already a train with that name,Choose another","OK", PopupColor.Red);
                return;
            }

        }

        int temp = 6;



        if (wagontype.Equals("FLAT WAGON"))
        {
            temp = 5;
        }
        if (wagontype.Equals("COVERED")) 
        {
            temp = 6;
        }
        if (wagontype.Equals("PASSENGER CAR"))
        {
            temp = 2;
        }
        if (wagontype.Equals("TANK"))
        {
            temp = 1;
        }
        if (wagontype.Equals("HOPPER"))
        {
            temp = 3;
        }
        if (wagontype.Equals("GONDOLA"))
        {
            temp = 4;
        }


        int[] layout = {temp };
      

        /*
        for (int i = 0; i < layout.Length; i++)
        {
            GameObject motherBox = Instantiate(shadows[layout[i]], transform.position, transform.rotation) as GameObject;

            if (count_before_turn > 19)
            {
                x_value_for_shadow = -268.781f;
                count_before_turn = 0;
                y_inc_for_shadow += 30;
            }
            motherBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(x_value_for_shadow, y_value_for_shadow - y_inc_for_shadow);
            //motherBox.name = gameObject.name;
            motherBox.transform.SetParent(GameObject.FindGameObjectWithTag("motherbox").transform, false);
            x_value_for_shadow = x_value_for_shadow + x_inc_for_shadow_value;
            count_before_turn++;
        }
        */
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

            motherBox1.transform.localPosition = new Vector2(posx,posy);
           // motherBox1.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = numberofWagons;
            motherBox1.transform.GetChild(1).gameObject.GetComponentInChildren<Text>().text = vehicle_number;
            motherBox1.gameObject.name = vehicle_number;


            x_value_for_parts = x_value_for_parts + x_inc_for_shadow_value;
            count_before_turn_for_parts++;
        }

    }


    public void recover_engine_state_Engine_start(string transactionid, string releasedfromsystem, string vehicletype, string vehicle_number,
       string yardsector, string line, string wagontype, string series, string dayhourlastevent,
       string status, float posx, float posy)
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

        

        // 0 head
        // 1 pasenger
        // 2 empty
        // 3 covered 
        // 4 coal
        // 5 tank

        if (transactionid.Equals("") || releasedfromsystem.Equals("") || vehicletype.Equals("") || yardsector.Equals("") || line.Equals("")
            || wagontype.Equals("") || series.Equals("") || dayhourlastevent.Equals("") || status.Equals(""))
        {
            // Debug.Log("all fields need to be filled");

            Popup.Show("Error", "All fields need to be filled!", "OK", PopupColor.Red);

            return;
        }


        



        foreach (Transform child in prefab_holder.transform)
        {

            if (child.gameObject.name == vehicle_number)
            {
                Popup.Show("Error", "There is already a train with that name,Choose another", "OK", PopupColor.Red);
                return;
            }

        }

        int temp = 6;



        if (wagontype.Equals("FLAT WAGON"))
        {
            temp = 5;
        }
        if (wagontype.Equals("COVERED"))
        {
            temp = 6;
        }
        if (wagontype.Equals("PASSENGER CAR"))
        {
            temp = 2;
        }
        if (wagontype.Equals("TANK"))
        {
            temp = 1;
        }
        if (wagontype.Equals("HOPPER"))
        {
            temp = 3;
        }
        if (wagontype.Equals("GONDOLA"))
        {
            temp = 4;
        }


        int[] layout = { temp };


        /*
        for (int i = 0; i < layout.Length; i++)
        {
            GameObject motherBox = Instantiate(shadows[layout[i]], transform.position, transform.rotation) as GameObject;

            if (count_before_turn > 19)
            {
                x_value_for_shadow = -268.781f;
                count_before_turn = 0;
                y_inc_for_shadow += 30;
            }
            motherBox.GetComponent<RectTransform>().anchoredPosition = new Vector2(x_value_for_shadow, y_value_for_shadow - y_inc_for_shadow);
            //motherBox.name = gameObject.name;
            motherBox.transform.SetParent(GameObject.FindGameObjectWithTag("motherbox").transform, false);
            x_value_for_shadow = x_value_for_shadow + x_inc_for_shadow_value;
            count_before_turn++;
        }
        */
        for (int parts = 0; parts < layout.Length; parts++)
        {
            // Get current DateTime. It can be any DateTime object in your code.  
           
            GameObject motherBox1 = Instantiate(train_parts[layout[parts]], transform.position, transform.rotation) as GameObject;
            if (count_before_turn_for_parts > 19)
            {
                x_value_for_parts = -268.781f;
                count_before_turn_for_parts = 0;
                y_inc_for_parts += 30;
            }
            motherBox1.GetComponent<RectTransform>().anchoredPosition = new Vector2(x_value_for_parts, y_value_for_parts - y_inc_for_parts);
            motherBox1.transform.SetParent(GameObject.FindGameObjectWithTag("motherbox").transform, false);

            motherBox1.transform.localPosition = new Vector2(posx, posy);
           // motherBox1.transform.GetChild(0).gameObject.GetComponentInChildren<Text>().text = numberofWagons;
            motherBox1.transform.GetChild(1).gameObject.GetComponentInChildren<Text>().text = vehicle_number;
            motherBox1.gameObject.name = vehicle_number;


            x_value_for_parts = x_value_for_parts + x_inc_for_shadow_value;
            count_before_turn_for_parts++;
        }

    }



}
