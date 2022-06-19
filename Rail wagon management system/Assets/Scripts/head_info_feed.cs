using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class head_info_feed : MonoBehaviour
{
    public Text vehicle_type;
    public Text yard_name;
    public Text yard_sector;
    public Text line;
    public Text vehicle_number;
   


    // Start is called before the first frame update
    void Start()
    {
        vehicle_type.text = "Vehicle type :" + Command.Instance.train_Model.Vehicle_Type_;
       // yard_name.text = " Yard name :" + Command.Instance.train_Model.Yard_name_;
        yard_sector.text = "Yard sector :" + Command.Instance.train_Model.Yard_Sector_;
        line.text = "Line" + Command.Instance.train_Model.Line_;
        vehicle_number.text = "Vehicle no :" + Command.Instance.train_Model.vehicle_number_;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
