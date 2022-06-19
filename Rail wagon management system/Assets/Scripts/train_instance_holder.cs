using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train_instance_holder : MonoBehaviour
{

    public string vehicle_type;
    public string wagon_type;
    public string series;
    public string last_event;
    public string status;
    public string line;
    public string yard_sector;
    public string vehicle_number;
    Action<string> _remove_and_destory;


    public void set_wagon(string vehicle_type_, string wagon_type_, string series_, string last_event_, string status_, string yard_sector_, string line_, string vehicle_number_)
    {
        vehicle_type = vehicle_type_;
        wagon_type = wagon_type_;
        series = series_;
        last_event = last_event_;
        status = status_;
        yard_sector = yard_sector_;
        vehicle_number = vehicle_number_;
        line = line_;
    }

    public void self_distruct(string vehicle_number) 
    {

        _remove_and_destory = (all_live_data) => {

            StartCoroutine(CreateVehicleRoutin(all_live_data));

        };



        StartCoroutine(Command.Instance.web_.Remove_wagon_from_body(vehicle_number,_remove_and_destory));


    }

    private IEnumerator CreateVehicleRoutin(string all_live_data)
    {

        if (all_live_data.Equals("modification Successful"))
        {
            Destroy(this.gameObject,1f);

        }



        yield return null; 
    }
}
