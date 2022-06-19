using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using EasyUI.Popup;

public class SearchableDropDown : MonoBehaviour
{

    public GameObject panel_match_indicator;

    [SerializeField] private Button blockerButton;
    [SerializeField] private GameObject buttonsPrefab = null;
    [SerializeField] private int maxScrollRectSize = 180;
    [SerializeField] private List<string> avlOptions = new List<string>();


    private Button ddButton = null;
    private TMP_InputField inputField = null;
    private ScrollRect scrollRect = null;
    private Transform content = null;
    private RectTransform scrollRectTrans;
    private bool isContentHidden = true;
    private List<Button> initializedButtons = new List<Button>();

    public delegate void OnValueChangedDel(string val);
    public OnValueChangedDel OnValueChangedEvt;

    Action<String> _getvehicle_number;
    Action<String> _getvehicle_data;
    Action<String> _updatevehicle_data;
    public Image access_indicator;
   


   // public TMP_InputField transaction_id = null;
   // public TMP_InputField Relesed_from_system = null;
    public TMP_InputField Vehicle_Type = null;
    public TMP_InputField vehicle_ = null;
    public TMP_InputField Yard_Sector = null;
    public TMP_InputField Line = null;
    //public TMP_InputField No_of_wagons = null;
    public TMP_InputField Wagon_type = null;
    public TMP_InputField Series = null;
   // public TMP_InputField Last_event = null;
    public TMP_InputField Date_Hour_Last_Event = null;
    public TMP_InputField Status = null;
    //public TMP_InputField Stock = null;
    //public TMP_InputField Stock_product = null;
    //public TMP_InputField Group_product = null;
    // public TMP_InputField Product = null;
    GameObject trainHolder;
    string vehicle_number_one;


    /// <summary>
    /// match selected wagone and set appropriate indicator
    /// </summary>
    public void Check_wagon_name_match_set_indicator(string value,GameObject obj_name) 
    {

        if (Wagon_type.text != "" && value != "")
        {
            if (Wagon_type.text.Equals(value))
            {

                Debug.Log(obj_name.name);
               //bj_name.GetComponent<DragDrop>().AV_BEEN_FOUND();
                trainHolder = obj_name;

                panel_match_indicator.GetComponent<Image>().color = Color.green;
            }
            else {
                panel_match_indicator.GetComponent<Image>().color = Color.red;
            }
        }
        else {
            panel_match_indicator.GetComponent<Image>().color = Color.red;
            Popup.Show("Success","Make sure you have selected a wagon, on add train using your wagon number!!", "OK", PopupColor.Red);
        }
    
    }

    public void send_to_conduit()
    {
        if (trainHolder != null)
        {
            if (Wagon_type.text.Equals(trainHolder.tag))
            {
              
                    if (Vehicle_Type.text != "" && Wagon_type.text != "" && Series.text != "" && Date_Hour_Last_Event.text != "" && Status.text != "" && Yard_Sector.text != "" && vehicle_number_one != "")
                {
                    trainHolder.GetComponent<DragDrop>().Receive_train(Vehicle_Type.text, Wagon_type.text, Series.text, Date_Hour_Last_Event.text,
                    Status.text, Yard_Sector.text, vehicle_number_one,Line.text);
                   // Popup.Show("Success", "sent successfully", "OK", PopupColor.Purple);
                }
                else
                {
                    Popup.Show("Error", "Make sure appropriate selections have been made", "OK", PopupColor.Purple);

                }
            }
            else {
                Popup.Show("Error", "The wagon type has to match", "OK", PopupColor.Purple);
            }
        }
        else {
            Popup.Show("Error", "Make sure you have selected an appropriate wagon", "OK", PopupColor.Red);
        }
    
    
    }






  

    void Set_the_time_and_date()
    {
        DateTime aDate = DateTime.Now;
        //Debug.Log(aDate.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK"));
        Date_Hour_Last_Event.text = aDate.ToString("dddd, dd MMMM yyyy HH:mm:ss");
       
        //Debug.Log("...............................................");
    }
    public void Stop_date_coroutine()
    {   
        //StopCoroutine("Set_the_time_and_date");
        CancelInvoke("Set_the_time_and_date");
    }
    public void Start_date_coroutine()
    {
        InvokeRepeating("Set_the_time_and_date", 2.0f, 0.3f);
    }



    void Start()
    {
        panel_match_indicator.GetComponent<Image>().color = Color.gray;

        InvokeRepeating("Set_the_time_and_date", 2.0f, 0.3f);

        _getvehicle_number = (jsonArraystring) => {

            StartCoroutine(CreateVehicleRoutin(jsonArraystring));

        };

          _getvehicle_data = (specific_vehicle_jsonArraystring) => {

            StartCoroutine(CreateVehicle_data_Routin(specific_vehicle_jsonArraystring));

        };

        StartCoroutine(Command.Instance.web_.Get_vehecle_number(_getvehicle_number));
        Command.Instance.get_references();
       
    }
   
  

    public IEnumerator CreateVehicleRoutin(string jsonArraystring_)
    {
        //Parsing json array
        JSONArray jsonArray_vehicles = JSON.Parse(jsonArraystring_) as JSONArray;

        for (int i = 0; i < jsonArray_vehicles.Count; i++)
        {
            bool isDone = false;
            String vehicle_number = jsonArray_vehicles[i].AsObject["Vehicle"];
            //Debug.Log(""+vehicle_number);
            avlOptions.Add(vehicle_number.Trim());
            accountant(i, jsonArray_vehicles.Count);
            //continue to the next item
          
        }
    
        yield return null;
    }


    public void accountant(int runner,int line) 
    {
            
            //Debug.Log((runner+3) +"...."+line);
        if (runner+2 > line)
        {
            //Debug.Log("end of line");
            Init();
        }
        

    }


    /// <summary>
    /// Initilize all the Fields
    /// </summary>
    private void Init()
    {
        ddButton = this.GetComponentInChildren<Button>();
        scrollRect = this.GetComponentInChildren<ScrollRect>();
        inputField = this.GetComponentInChildren<TMP_InputField>();
        scrollRectTrans = scrollRect.GetComponent<RectTransform>();
        content = scrollRect.content;

        //blocker is a button added and scaled it to screen size so that we can close the dd on clicking outside
        blockerButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        blockerButton.gameObject.SetActive(false);
        blockerButton.transform.SetParent(this.GetComponentInParent<Canvas>().transform);

        blockerButton.onClick.AddListener(OnBlockerButtClick);
        ddButton.onClick.AddListener(OnDDButtonClick);
        scrollRect.onValueChanged.AddListener(OnScrollRectvalueChange);
        inputField.onValueChanged.AddListener(OnInputvalueChange);
        inputField.onEndEdit.AddListener(OnEndEditing);

        AddItemToScrollRect(avlOptions);

    }

    /// <summary>
    /// public method to get the selected value
    /// </summary>
    /// <returns></returns>
    public string GetValue()
    {
        return inputField.text;
    }

    public void ResetDropDown()
    {
        inputField.text = string.Empty;
        
    }

    //call this to Add items to Drop down
    public void AddItemToScrollRect(List<string> options)
    {
        foreach (var option in options)
        {
            var buttObj = Instantiate(buttonsPrefab, content);
            buttObj.GetComponentInChildren<TMP_Text>().text = option;
            buttObj.name = option;
            buttObj.SetActive(true);
            var butt = buttObj.GetComponent<Button>();
            butt.onClick.AddListener(delegate { OnItemSelected(buttObj); });
            initializedButtons.Add(butt);
        }
        ResizeScrollRect();
        scrollRect.gameObject.SetActive(false);
    }


    /// <summary>
    /// listner To Input Field End Editing
    /// </summary>
    /// <param name="arg"></param>
    private void OnEndEditing(string arg)
    {
        if (string.IsNullOrEmpty(arg))
        {
            Debug.Log("no value entered ");
            return;
        }
        StartCoroutine(CheckIfValidInput(arg));
    }

    /// <summary>
    /// Need to wait as end inputField and On option button  Contradicted and message was poped after selection of button
    /// </summary>
    /// <param name="arg"></param>
    /// <returns></returns>
    IEnumerator CheckIfValidInput(string arg)
    {
        yield return new WaitForSeconds(1);
        if (!avlOptions.Contains(arg))
        {
           // Message msg = new Message("Invalid Input!", "Please choose from dropdown",
           //                 this.gameObject, Message.ButtonType.OK);
           //
           //             if (MessageBox.instance)
           //                 MessageBox.instance.ShowMessage(msg); 

            inputField.text = String.Empty;
        }
        //else
        //    Debug.Log("good job " );
        OnValueChangedEvt?.Invoke(inputField.text);
    }
    /// <summary>
    /// Called ever time on Drop down value is changed to resize it
    /// </summary>
    private void ResizeScrollRect()
    {
        //TODO Dont Remove this until checked on Mobile Deveice
        //var count = content.transform.Cast<Transform>().Count(child => child.gameObject.activeSelf);
        //var length = buttonsPrefab.GetComponent<RectTransform>().sizeDelta.y * count;

        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)content.transform);
        var length = content.GetComponent<RectTransform>().sizeDelta.y;

        scrollRectTrans.sizeDelta = length > maxScrollRectSize ? new Vector2(scrollRectTrans.sizeDelta.x,
            maxScrollRectSize) : new Vector2(scrollRectTrans.sizeDelta.x, length + 5);
    }

    /// <summary>
    /// listner to the InputField
    /// </summary>
    /// <param name="arg0"></param>
    private void OnInputvalueChange(string arg0)
    {
        if (!avlOptions.Contains(arg0))
        {
            FilterDropdown(arg0);
        }
    }

    /// <summary>
    /// remove the elements from the dropdown based on Filters
    /// </summary>
    /// <param name="input"></param>
    public void FilterDropdown(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            foreach (var button in initializedButtons)
                button.gameObject.SetActive(true);
            ResizeScrollRect();
            scrollRect.gameObject.SetActive(false);
            return;
        }

        var count = 0;
        foreach (var button in initializedButtons)
        {
            if (!button.name.ToLower().Contains(input.ToLower()))
            {
                button.gameObject.SetActive(false);
            }
            else
            {
                button.gameObject.SetActive(true);
                count++;
            }
        }

        SetScrollActive(count > 0);
        ResizeScrollRect();
    }

    /// <summary>
    /// Listner to Scroll rect
    /// </summary>
    /// <param name="arg0"></param>
    private void OnScrollRectvalueChange(Vector2 arg0)
    {
        //Debug.Log("scroll ");
    }

    /// <summary>
    /// Listner to option Buttons
    /// </summary>
    /// <param name="obj"></param>
    private void OnItemSelected(GameObject obj)
    {
        inputField.text = obj.name;
        foreach (var button in initializedButtons)
            button.gameObject.SetActive(true);
        isContentHidden = false;
        OnDDButtonClick();
        //OnEndEditing(obj.name);

        ////////////////////////////////////////////////////////////////..................................
        ///call the couroutin to fetch vehcile specific data
        Debug.Log(obj.name);

        StopAllCoroutines();
        StartCoroutine(CheckIfValidInput(obj.name));
      
        StartCoroutine(Command.Instance.web_.Get_vehecle_data(obj.name, _getvehicle_data));
        trainHolder = null;
        panel_match_indicator.GetComponent<Image>().color = Color.gray;
    }

    public IEnumerator CreateVehicle_data_Routin(string specific_vehicle_jsonArraystring_)
    {
        //Parsing json array
        JSONArray jsonArray_data_vehicles = JSON.Parse(specific_vehicle_jsonArraystring_) as JSONArray;

        for (int i = 0; i < jsonArray_data_vehicles.Count; i++)
        {
            string transaction_id = jsonArray_data_vehicles[i].AsObject["transaction_id"];
            string Relesed_from_system  = jsonArray_data_vehicles[i].AsObject["Relesed_from_system"];
             Vehicle_Type.text = jsonArray_data_vehicles[i].AsObject["Vehicle_Type"];
            // Yard_name.text = jsonArray_data_vehicles[i].AsObject["Yard name"];
             vehicle_number_one = jsonArray_data_vehicles[i].AsObject["Vehicle"];
             Yard_Sector.text = jsonArray_data_vehicles[i].AsObject["Yard_Sector"];
             Line.text = jsonArray_data_vehicles[i].AsObject["Line"];
            // No_of_wagons.text = jsonArray_data_vehicles[i].AsObject["No_of_wagons"];
             Wagon_type.text = jsonArray_data_vehicles[i].AsObject["Wagon_type"];
             Series.text = jsonArray_data_vehicles[i].AsObject["Series"];
            // Last_event.text = jsonArray_data_vehicles [i].AsObject["Last event"];
             Date_Hour_Last_Event.text = jsonArray_data_vehicles[i].AsObject["Date_Hour_Last_Event"];
             Status.text = jsonArray_data_vehicles[i].AsObject["Status"];
            // Stock_product.text = jsonArray_data_vehicles[i].AsObject["Stock product"];
            // Stock.text = jsonArray_data_vehicles[i].AsObject["Stock"];
            // Group_product.text = jsonArray_data_vehicles[i].AsObject["Group product"];
            // Product.text = jsonArray_data_vehicles[i].AsObject["Product"];

            

            Command.Instance.train_Model.set_model_data(transaction_id, Relesed_from_system,
                jsonArray_data_vehicles[i].AsObject["Vehicle_Type"],
                jsonArray_data_vehicles[i].AsObject["Vehicle"],
              
               // jsonArray_data_vehicles[i].AsObject["Yard name"],
                jsonArray_data_vehicles[i].AsObject["Yard_Sector"],
                jsonArray_data_vehicles[i].AsObject["Line"],
               // jsonArray_data_vehicles[i].AsObject["No_of_wagons"],
                jsonArray_data_vehicles[i].AsObject["Wagon_type"],
                jsonArray_data_vehicles[i].AsObject["Series"],
                jsonArray_data_vehicles[i].AsObject["Date_Hour_Last_Event"],
                jsonArray_data_vehicles[i].AsObject["Status"],
                jsonArray_data_vehicles[i].AsObject["posX"],
                jsonArray_data_vehicles[i].AsObject["posY"]
               // jsonArray_data_vehicles[i].AsObject["Group product"],
               // jsonArray_data_vehicles[i].AsObject["Product"]
                );
            // access_indicator.enabled = true;
           

            //GameObject.Find("transaction_id").GetComponent<TMP_InputField>().text = transaction_id;
            // GameObject.Find("Relesed_from_system").GetComponent<TMP_InputField>().text = Relesed_from_system;
            // GameObject.Find("Vehicle Type").GetComponent<TMP_InputField>().text = Vehicle_Type;
            // GameObject.Find("Yard name").GetComponent<TMP_InputField>().text = Yard_name;
            // GameObject.Find("Yard Sector").GetComponent<TMP_InputField>().text = Yard_Sector;
            // GameObject.Find("Line").GetComponent<TMP_InputField>().text = Line;
            // GameObject.Find("No of wagons").GetComponent<TMP_InputField>().text = No_of_wagons;
            // GameObject.Find("Wagon type").GetComponent<TMP_InputField>().text = Wagon_type;
            // GameObject.Find("Series").GetComponent<TMP_InputField>().text = Series;
            // GameObject.Find("Last event").GetComponent<TMP_InputField>().text = Last_event;
            // GameObject.Find("Date/Hour Last Event").GetComponent<TMP_InputField>().text = Date_Hour_Last_Event;
            // GameObject.Find("Status").GetComponent<TMP_InputField>().text = Status;
            //GameObject.Find("Stock product").GetComponent<TMP_InputField>().text = Stock_product;
            //GameObject.Find("Stock").GetComponent<TMP_InputField>().text = Stock;
            // GameObject.Find("Group product").GetComponent<TMP_InputField>().text = Group_product;
            // GameObject.Find("Product").GetComponent<TMP_InputField>().text = Product;

        }
        yield return null;
    }
    string ve_num_;
    public void Update_vehicle_records()
    {
    
        string line_ =   Line.text;
       // string number_of_wagons_ = No_of_wagons.text;
        string hour_ = Date_Hour_Last_Event.text;
        string status_ = Status.text;
        ve_num_ = vehicle_.text;


        if (line_.Equals("") || hour_.Equals("") || status_.Equals("") || ve_num_.Equals("")) 
        {
            Popup.Show("Error","Make sure all records are not empty", "OK", PopupColor.Red);
            return;
        }


        _updatevehicle_data = (update_record_response) => {

            StartCoroutine(UpdateVehicle_data_Routin(update_record_response));

        };

        StartCoroutine(Command.Instance.web_.Update_vehecle_data(ve_num_,line_,hour_,status_, _updatevehicle_data));
    }

    public IEnumerator UpdateVehicle_data_Routin(string update_record_response)
    {
        StartCoroutine(Command.Instance.web_.Get_vehecle_data(ve_num_, _getvehicle_data));
        Popup.Show("Success", update_record_response, "OK", PopupColor.Green);
        yield return null;
    }




    /// <summary>
    /// listner to arrow button on input field
    /// </summary>
    private void OnDDButtonClick()
    {
        if(GetActiveButtons()<=0)
            return;
        ResizeScrollRect();
        SetScrollActive(isContentHidden);
    }
    private void OnBlockerButtClick()
    {
        SetScrollActive(false);
    }

    /// <summary>
    /// respondisble to enable and disable scroll rect component 
    /// </summary>
    /// <param name="status"></param>
    private void SetScrollActive(bool status)
    {
        scrollRect.gameObject.SetActive(status);
        blockerButton.gameObject.SetActive(status);
        isContentHidden = !status;
        ddButton.transform.localScale = status ? new Vector3(1, -1, 1) : new Vector3(1, 1, 1);
    }

    /// <summary>
    /// Return numbers of active buttons in the dropdown
    /// </summary>
    /// <returns></returns>
    private float GetActiveButtons()
    {
        var count = content.transform.Cast<Transform>().Count(child => child.gameObject.activeSelf);
        var length = buttonsPrefab.GetComponent<RectTransform>().sizeDelta.y * count;
        return length;
    }

   
}
