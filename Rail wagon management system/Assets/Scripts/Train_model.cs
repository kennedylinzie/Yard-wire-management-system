using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train_model : MonoBehaviour
{


    public string transaction_id_;
    public string Relesed_from_system_;
    public string Vehicle_Type_;
    public string vehicle_number_;
   // public string Yard_name_;
    public string Yard_Sector_;
    public string Line_;
   // public string No_of_wagons_;
    public string Wagon_type_;
    public string Series_;
    //public string Last_event_;
    public string Date_Hour_Last_Event_;
    public string Status_;
    public string posx;
    public string posy;
   // public string Group_product_;
   // public string Product_;

    public void set_model_data(string transaction_id, string Relesed_from_system, string Vehicle_Type, string vehicle_number, string Yard_Sector,
    string Line,string Wagon_type, string Series, string Date_Hour_Last_Event,
    string Status,string posX,string posY) 
    {

            transaction_id_= transaction_id;
            Relesed_from_system_= Relesed_from_system;
            Vehicle_Type_= Vehicle_Type;
            vehicle_number_ = vehicle_number;
            Yard_Sector_= Yard_Sector;
            Line_= Line;
           // No_of_wagons_= No_of_wagons;
            Wagon_type_= Wagon_type;
            Series_= Series;
            Date_Hour_Last_Event_= Date_Hour_Last_Event;
            Status_= Status;
            posx = posX;
            posy = posY;


    }
}
