using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using EasyUI.Popup;


public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler, IPointerClickHandler
{
    private const double x_left_limit = -940.189;
    private const double x_right_limit = 938.2852;
    private const double y_bottom_limit = -456.624;
    private const double y_top_limit = 480.476;
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;

    private CanvasGroup canvasGroup;
    private Image danger_color;
    // public GameObject double_click_menu;





    public string Line_global;
    public Text train_name;
    private Vector2 temp_pos;



    public string positionx;
    public string positiony;


    Action<String> _getvehicle_data;
    Action<String> _updateposition_data;
    Action<String> _train_received;
    Action<String> _train_enrol;
    Action<String> _train_update;
    Action<String> _recover_memory;
    Action<String> _self_distrct;
    Action<String> _clear_before_self_distrct;
    Action<String> _clear_before_self_clean_up;
    GameObject wagon_number;


    public SearchableDropDown seachDrop;



    //public Text wag_amount;

    [System.Serializable]
    public class Wagon
    {

        public Wagon(string vehicle_type_, string wagon_type_, string series_, string last_event_, string status_
            , string yard_sector_, string vehicle_number_,string line_)
        {
            vehicle_type = vehicle_type_;
            wagon_type = wagon_type_;
            series = series_;
            last_event = last_event_;
            status = status_;
            yard_sector = yard_sector_;
            vehicle_number = vehicle_number_;
            _line = line_;
        }

        public string vehicle_type;
        public string wagon_type;
        public string series;
        public string last_event;
        public string status;
        public string yard_sector;
        public string vehicle_number;
        public string _line;

    }
    [System.Serializable]
    public class WagonList
    {

        // public  Wagon[] wagony;
        public List<Wagon> wagony = new List<Wagon>();

    }

    public WagonList mywagonList = new WagonList();


    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        seachDrop = GetComponent<SearchableDropDown>();
     
        Command.Instance.get_references();
     

        _getvehicle_data = (specific_vehicle_jsonArraystring) => {

            StartCoroutine(CreateVehicle_data_Routin(specific_vehicle_jsonArraystring));

        };
        StartCoroutine(Command.Instance.web_.Get_vehecle_data(this.gameObject.name, _getvehicle_data));


        this.gameObject.transform.GetChild(2).gameObject.GetComponentInChildren<Button>().onClick.AddListener(() =>
        {
            Command.Instance.get_references();
            //Debug.Log("my tag is : "+motherBox1.tag);
            Command.Instance.s_drop.Check_wagon_name_match_set_indicator(this.gameObject.tag, this.gameObject);
         

        });


        _recover_memory = (all_live_data) => {

            StartCoroutine(memory_regression(all_live_data));

        };

        StartCoroutine(Command.Instance.web_.Get_object_data_contents(this.gameObject.name, _recover_memory));

      


    }



    public void Prepare_for_delete() 
    {
       
        if (mywagonList.wagony.Count.Equals(0))
        {

            _self_distrct = (specific_vehicle_jsonArraystring) => {

                StartCoroutine(destroy_body_when_zero(specific_vehicle_jsonArraystring));

            };
            StartCoroutine(Command.Instance.web_.Remove_wagon_body(this.gameObject.name, _self_distrct));


        } 
        else if (mywagonList.wagony.Count > 0) 
        {
            _clear_before_self_distrct = (specific_vehicle_jsonArraystring) => {

                StartCoroutine(before_i_self_distruct(specific_vehicle_jsonArraystring));

            };


            for (int i = 0; i < mywagonList.wagony.Count; i++)
            {
                StartCoroutine(Command.Instance.web_.Remove_wagon_from_body(mywagonList.wagony[i].vehicle_number, _clear_before_self_distrct));

                Command.Instance.web_.Remove_wagon_body_no_wait(this.gameObject.name);


            }


        }
    
    }


    int runner = 0;
    public IEnumerator before_i_self_distruct(string jsonArraystring_)
    {
       
        if (jsonArraystring_.Equals("modification Successful"))
        {
            if (runner+2 > mywagonList.wagony.Count)
            {


                _clear_before_self_clean_up = (specific_vehicle_jsonArraystring) => {

                    StartCoroutine(destroy_body_cleaner(specific_vehicle_jsonArraystring));

                };
                StartCoroutine(Command.Instance.web_.Remove_wagon_body(this.gameObject.name, _clear_before_self_clean_up));


            }
           
        }
        runner++;
        yield return null;
    }


    public IEnumerator destroy_body_cleaner(string jsonArraystring_)
    {

        if (jsonArraystring_.Equals("modification Successful"))
        {
            Debug.Log("...................we found the animal.............");
            Destroy(this.gameObject, 1f);
        }

        yield return null;
    }







    public IEnumerator destroy_body_when_zero(string jsonArraystring_)
    {
        
        if (jsonArraystring_.Equals("modification Successful")) 
        {
            Command.Instance.web_.Remove_wagon_body_no_wait(this.gameObject.name);
            Destroy(this.gameObject,1f);
        }

        yield return null;
    }


    public IEnumerator memory_regression(string jsonArraystring_)
    {
        //Parsing json array
        JSONArray jsonArray_vehicles = JSON.Parse(jsonArraystring_) as JSONArray;

        for (int i = 0; i < jsonArray_vehicles.Count; i++)
        {
         
            String Vehicle_Type = jsonArray_vehicles[i].AsObject["Vehicle_Type"];
            String Yard_Sector = jsonArray_vehicles[i].AsObject["Yard_Sector"];
            String Line = jsonArray_vehicles[i].AsObject["Line"];
            String Vehicle = jsonArray_vehicles[i].AsObject["Vehicle"];
            String Wagon_type = jsonArray_vehicles[i].AsObject["Wagon_type"];
            String Series = jsonArray_vehicles[i].AsObject["Series"];
            String Date_Hour_Last_Event = jsonArray_vehicles[i].AsObject["Date_Hour_Last_Event"];
            String Status = jsonArray_vehicles[i].AsObject["Status"];
            Line_global = Line;
            Recover_self_data(Vehicle_Type,Wagon_type,Series,Date_Hour_Last_Event,Status,Yard_Sector,Vehicle,Line);

            positionx = jsonArray_vehicles[i].AsObject["posX"];
            positiony = jsonArray_vehicles[i].AsObject["posY"];
        }

        yield return null;
    }




    public void Receive_train(string vehicle_type,string wagon_type, string series, string last_event, string status, string yard_sector, string vehicle_number,string line)
    {

            for (int i = 0; i < mywagonList.wagony.Count; i++)
            {
                if (mywagonList.wagony[i].vehicle_number.Equals(vehicle_number))
                {
               

                Popup.Show("Error", "this item already exists", "OK", PopupColor.Red);
                    return;
                }
                
            }
           mywagonList.wagony.Add(new Wagon(vehicle_type, wagon_type, series, last_event, status, yard_sector, vehicle_number,line));

        /////////////////

        _updateposition_data = (update_record_response) => {

            StartCoroutine(_update_position_data(update_record_response));

        };
        if (positionx!="" && positiony!="")
        {
            StartCoroutine(Command.Instance.web_.Update_position_and_line(vehicle_number, Line_global, positionx, positiony, _updateposition_data));

        }


        ///////////////

        _train_received = (all_live_data) => {

                        StartCoroutine(setup_train(all_live_data));

                    };

                    StartCoroutine(Command.Instance.web_.Train_added_to_platform(vehicle_number,this.gameObject.name,_train_received));

                    Show_wagon_number(mywagonList.wagony.Count + "");

    }


    public void Recover_self_data(string vehicle_type, string wagon_type, string series, string last_event, string status, string yard_sector, string vehicle_number,string line)
    {

        for (int i = 0; i < mywagonList.wagony.Count; i++)
        {
            if (mywagonList.wagony[i].vehicle_number.Equals(vehicle_number))
            {


                Popup.Show("Error", "this item already exists", "OK", PopupColor.Red);
                return;
            }

        }
        mywagonList.wagony.Add(new Wagon(vehicle_type, wagon_type, series, last_event, status, yard_sector, vehicle_number,line));
        Show_wagon_number(mywagonList.wagony.Count + "");

        /*
                _train_received = (all_live_data) => {

                    StartCoroutine(setup_train(all_live_data));

                };

                StartCoroutine(Command.Instance.web_.Train_added_to_platform(vehicle_number, this.gameObject.name, _train_received));
        */


    }


    public void Show_wagon_number(string number) 
    {

        this.gameObject.transform.GetChild(1).gameObject.GetComponentInChildren<Text>().text = number;

    }



    public IEnumerator setup_train(string jsonArraystring_)
    {

        Debug.Log(jsonArraystring_);
        ///Popup.Show("Success", "Ship Added successfully.", "OK", PopupColor.Green);

        yield return null;
    }



    string posx;
    string posy;

    public void set_modify_line(string line_,Vector2 pos) 
    {
        posx = pos.x + "";
        posy = pos.y + "";
        Line_global = line_;
        positionx = posx;
        positiony = posy;
        
        //inser the train to the object persistence database
        _train_enrol = (all_live_data) => {

            StartCoroutine(setup_enrol(all_live_data));

        };
        /// the couroutine to insert the data
        StartCoroutine(Command.Instance.web_.Train_object_insert(this.gameObject.name,posx,posy,this.gameObject.tag, _train_enrol));



        _updateposition_data = (update_record_response) => {

            StartCoroutine(_update_position_data(update_record_response));

        };
        if (mywagonList.wagony != null)
        {
            for (int i = 0; i < mywagonList.wagony.Count; i++)
            {
                StartCoroutine(Command.Instance.web_.Update_position_and_line(mywagonList.wagony[i].vehicle_number, line_, positionx, positiony, _updateposition_data));

            }
        }


        
    }

    /// <summary>
    /// the the callback to get a result
    /// </summary>
    /// <param name="jsonArraystring_"></param>
    /// <returns></returns>
    /// 

    public IEnumerator setup_enrol(string jsonArraystring_)
    {

        if (jsonArraystring_.Equals("1"))
        {
            //Popup.Show("Success", jsonArraystring_, "OK", PopupColor.Green);
            //inser the train to the object persistence database
            _train_update = (all_live_data) => {

                StartCoroutine(setup_enrol_update(all_live_data));

            };
            /// the couroutine to insert the data
            StartCoroutine(Command.Instance.web_.Train_object_update(this.gameObject.name, posx, posy, _train_update));


        } else if (jsonArraystring_.Equals("Train received")) 
        {
           // Popup.Show("Success", jsonArraystring_, "OK", PopupColor.Green);
        }
        

        yield return null;
    }
    public IEnumerator setup_enrol_update(string jsonArraystring_)
    {

        yield return null;
    }


    public IEnumerator _update_position_data(string update_record_response)
    {
       // Popup.Show("Success", "location updated", "OK", PopupColor.Green);
        yield return null;
    }


    private void Awake()
    {

       
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        danger_color = GetComponent<Image>();

        //wag_amount = GetComponent<Text>();
        // train_name = GameObject.Find("title") as Text;
        // double_click_menu.SetActive(false);

        //rectTransform.anchoredPosition = new Vector2(209,40);
    }



    public IEnumerator CreateVehicle_data_Routin(string specific_vehicle_jsonArraystring_)
{
    //Parsing json array
    JSONArray jsonArray_data_vehicles = JSON.Parse(specific_vehicle_jsonArraystring_) as JSONArray;

    for (int i = 0; i < jsonArray_data_vehicles.Count; i++)
    {

        string transaction_id = jsonArray_data_vehicles[i].AsObject["transaction_id"];
        string Relesed_from_system = jsonArray_data_vehicles[i].AsObject["Relesed_from_system"];
     

    }
    yield return null;
}



    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBegindrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        temp_pos = rectTransform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("i drag");
        //rectTransform.anchoredPosition += eventData.delta;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        if (rectTransform.anchoredPosition.x < x_left_limit)
        {
            Debug.Log("--------------------------------");
            danger_color.color = Color.red;


        }
       else if (rectTransform.anchoredPosition.x > x_right_limit)
        {
            Debug.Log("+++++++++++++++++++++++++++++++++");
            danger_color.color = Color.red;
        }
       else if (rectTransform.anchoredPosition.y < y_bottom_limit)
        {
            Debug.Log("--------------------------------");
            danger_color.color = Color.red;
        }
       else if (rectTransform.anchoredPosition.y > y_top_limit)
        {
            Debug.Log("+++++++++++++++++++++++++++++++++");
            danger_color.color = Color.red;
        }
        else
        {
            danger_color.color = Color.white;
        }

        // rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEnddrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (rectTransform.anchoredPosition.x < x_left_limit)
        {
            Debug.Log("--------------------------------");
            rectTransform.position = temp_pos;
        }
        else if (rectTransform.anchoredPosition.x > x_right_limit)
        {
            Debug.Log("+++++++++++++++++++++++++++++++++");
            rectTransform.position = temp_pos;
        }
       else if (rectTransform.anchoredPosition.y < y_bottom_limit)
        {
            Debug.Log("--------------------------------");
            rectTransform.position = temp_pos;
        }
       else if (rectTransform.anchoredPosition.y > y_top_limit)
        {
            Debug.Log("+++++++++++++++++++++++++++++++++");
            rectTransform.position = temp_pos;
        }
     
            danger_color.color = Color.white;
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("I DROPPED IT");
    }

    
    float lastClick = 0f;
    float interval = 0.4f;
   
    public void OnPointerClick(PointerEventData eventData)
    {
   
        if ((lastClick + interval) > Time.time)
        {
            /*
    vehicle_type;
    wagon_type;
    series;
    last_event;
     status;
   yard_sector;
     line;
    vehicle_number;
    number_of_wagons;
            */

    Debug.Log("Double CLICKED");
            Command.Instance.updown_anim_objectlist.ShowHideMenu();
            if (mywagonList.wagony != null)
            {
                Command.Instance.updown_anim_objectlist.clear_field();
                for (int i = 0; i < mywagonList.wagony.Count; i++)
                {
                    //StartCoroutine(Command.Instance.web_.Update_position_and_line(mywagonList.wagony[i].vehicle_number, line_, positionx, positiony, _updateposition_data));
                    Command.Instance.updown_anim_objectlist.fill_the_list(mywagonList.wagony[i].vehicle_type, mywagonList.wagony[i].wagon_type, mywagonList.wagony[i].series, mywagonList.wagony[i].last_event,
                        mywagonList.wagony[i].status, mywagonList.wagony[i].yard_sector,Line_global, mywagonList.wagony[i].vehicle_number);
                }
            }
            //Command.Instance.updown_anim.set_train_info(vehicle_type, wagon_type, series, last_event, status, yard_sector, line, vehicle_number, number_of_wagons);
        }
        else {
            Debug.Log("SINGLE CLICKED");
        }
        lastClick = Time.time;
            
    }
    

    public void the_wagon_search_man(string number) 
    {
        Debug.Log("We received your number "+ number);
        if (mywagonList.wagony != null)
        {
            for (int i = 0; i < mywagonList.wagony.Count; i++)
            {
                if (mywagonList.wagony[i].vehicle_number.Equals(number))
                {
                    Popup.Show("Found", "The wagon is on line : " + mywagonList.wagony[i]._line + "\n" + "It is a : " + mywagonList.wagony[i].wagon_type, "OK", PopupColor.Green);

                }
           
            }
        }
    }


   


}
