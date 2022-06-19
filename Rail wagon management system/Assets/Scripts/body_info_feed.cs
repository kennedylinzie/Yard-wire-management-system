using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class body_info_feed : MonoBehaviour
{
    public Text vehicle_type;
    public Text wagon_type;
    public Text series;
    public Text last_event;
    public Text status;
    public Text yard_sector;
    public Text line;
    public Text vehicle_number;
   // public Text number_of_wagons;
    //  public Text stock;
    // public Text product;


    // Start is called before the first frame update
    void Start()
    {
        vehicle_type.text = Command.Instance.train_Model.Vehicle_Type_;
        wagon_type.text = Command.Instance.train_Model.Wagon_type_;
        series.text = Command.Instance.train_Model.Series_;
        last_event.text = Command.Instance.train_Model.Line_;
        status.text =  Command.Instance.train_Model.Status_;
        yard_sector.text = Command.Instance.train_Model.Yard_Sector_;
        line.text = Command.Instance.train_Model.Line_;
        vehicle_number.text = Command.Instance.train_Model.vehicle_number_;
       // number_of_wagons.text = Command.Instance.train_Model.No_of_wagons_;
        // stock.text = "Stock : " + Command.Instance.train_Model.Stock_;
        // product.text = "Product : " + Command.Instance.train_Model.Product_;
    }

   
}
