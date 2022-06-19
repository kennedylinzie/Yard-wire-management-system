using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EasyUI.Popup;
using System;
using UnityEngine.SceneManagement;

public class enrol_wagon : MonoBehaviour
{
    //public TMP_InputField vehicle_number;
    public TMP_InputField Vehicle_Type;
    public TMP_InputField Yard_Sector;
    public TMP_InputField Vehicle;
    public TMP_InputField Series;
    public TMP_InputField Sequence;
    public TMP_InputField Wagon_type;
    public TMP_InputField Date_Hour_Last_Event;
    public TMP_InputField Status;
    Action<String> enrol_add;


    public void enroll_wagon() 
    {
        if (Wagon_type.text != string.Empty && Vehicle_Type.text != string.Empty && Yard_Sector.text
            != string.Empty && Vehicle.text != string.Empty && Series.text != string.Empty)
        {
            enrol_add = (specific_vehicle_jsonArraystring) => {

                StartCoroutine(add_wagon_to_database(specific_vehicle_jsonArraystring));

            };



            StartCoroutine(Command.Instance.web_.Enrol_wagony(Vehicle_Type.text, Yard_Sector.text, Vehicle.text, Sequence.text, Series.text, Wagon_type.text, Date_Hour_Last_Event.text, Status.text, enrol_add));

        }
        else {
            Popup.Show("Error", "The areas with an asterix should not be empty", "OK", PopupColor.Red);
        }
    
    }


    public IEnumerator add_wagon_to_database(string jsonArraystring_)
    {
        Debug.Log("that wagon thing "+jsonArraystring_);

        if (jsonArraystring_.Equals("Wagon already exists"))
        {
            Popup.Show("Error", "Wagon already exists", "OK", PopupColor.Red);
        }
        else if(jsonArraystring_.Equals("Registration Successful")) {
            Popup.Show("Successs", "Added successfully", "OK", PopupColor.Green);
        }

        yield return null;
    }

    public void go_home() 
    {

        SceneManager.LoadScene("central");

    }

}
