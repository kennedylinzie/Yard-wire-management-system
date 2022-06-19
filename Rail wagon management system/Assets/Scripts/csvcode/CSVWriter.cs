using AnotherFileBrowser.Windows;
using EasyUI.Popup;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CSVWriter : MonoBehaviour
{

    string filename = "";
    Action<string> _get_data_of_existing_wagons;
    Action<string> _get_object_for_csv;
    public List<string> acountant = new List<string>();

    public List<string> one = new List<string>();
    public List<string> two = new List<string>();
    public List<string> three = new List<string>();
    public List<string> four = new List<string>();
    public List<string> five = new List<string>();
    public List<string> six = new List<string>();
    public List<string> seven = new List<string>();
    public List<string> eight = new List<string>();
    public List<string> ten = new List<string>();
    public List<string> eleven = new List<string>();
    public List<string> twelve = new List<string>();
    public List<string> thirteen = new List<string>();

    public float TIME;
    public float REPEAT_RATE;
    public Text file_path;
    




    // Start is called before the first frame update
    void Start()
    {


        // filename = Application.dataPath + "/test.csv";
      
        

    }

  



    void start_timer()
    {
        _get_object_for_csv = (all_live_data) => {

            StartCoroutine(memory_regression(all_live_data));

        };

        StartCoroutine(Command.Instance.web_.Get_all_persist_object_data(_get_object_for_csv));
        acountant.Clear(); 

        one.Clear();
        two.Clear();
        three.Clear();
        four.Clear();
        five.Clear();
        six.Clear();
        seven.Clear();
        eight.Clear();
        ten.Clear();
        eleven.Clear();
        twelve.Clear();
        thirteen.Clear();
    }
    public void Stop_timing()
    {
        //StopCoroutine("Set_the_time_and_date");
        CancelInvoke("start_timer");
    }
    public void Start_timing()
    {
        InvokeRepeating("start_timer", TIME, REPEAT_RATE);
    }






    public IEnumerator memory_regression(string jsonArraystring_)
    {
        //Parsing json array
        JSONArray jsonArray_vehicles = JSON.Parse(jsonArraystring_) as JSONArray;

        for (int i = 0; i < jsonArray_vehicles.Count; i++)
        {

            //String Vehicle_Type = jsonArray_vehicles[i].AsObject["object_id"];
            String name = jsonArray_vehicles[i].AsObject["name"];
            Debug.Log("............." + name);
            run_the_processor(name);


        }

        yield return null;
    }






    public void run_the_processor(string name) 
    {
        


        _get_data_of_existing_wagons = (all_live_data) => {

            StartCoroutine(summery_loader(all_live_data));

        };

        StartCoroutine(Command.Instance.web_.Get_object_data_for_summary(name, _get_data_of_existing_wagons));

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

            acountant.Add(Vehicle);

            int data = int.Parse(Line);
            switch (data)
            {
                
                case 1:
                    one.Add(Vehicle);
                    break;
                case 2:
                    two.Add(Vehicle);
                    break;
                case 3:
                    three.Add(Vehicle);
                    break;
                case 4:
                    four.Add(Vehicle);
                    break;
                case 5:
                    five.Add(Vehicle);
                    break;
                case 6:
                    six.Add(Vehicle);
                    break;
                case 7:
                    seven.Add(Vehicle);
                    break;
                case 8:
                    eight.Add(Vehicle);
                    break;
                case 10:
                    ten.Add(Vehicle);
                    break;
                case 11:
                    eleven.Add(Vehicle);
                    break;
                case 12:
                    twelve.Add(Vehicle);
                    break;
                case 13:
                    thirteen.Add(Vehicle);
                    break;
            }

           
           


        }

        yield return null;
    }


    // Update is called once per frame
    void Update()
    {
       
    }

    public void TEST_EXPORT() 
    {

        Start_export();

    }

    int runne = 0;
    void start_EXPORT()
    {
        WriteCSV();
       // Stop_timing();
        if (runne > 1)
        {
            runne = 0;
            Popup.Show("Success", "Export Successful Look for the file on your desktop", "OK", PopupColor.Green);
            Stop_export();
            
        }
        Debug.Log("............................................................");
        runne++;
    }
    public void Stop_export()
    {
        //StopCoroutine("Set_the_time_and_date");
        start_timer();
        CancelInvoke("start_EXPORT");
    }
    public void Start_export()
    {
        InvokeRepeating("start_EXPORT",0f,.12f);
    }




    public void WriteCSV() 
    {
        DateTime aDate = DateTime.Now;
        string special_name = aDate.ToString("dddd, dd MMMM yyyy");
        filename = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop)+ "/"+special_name+" YIRE WIRE.CSV";
       
        //Debug.Log
        // Format Datetime in different formats and display them  

       

      

        if (acountant.Count > 0) 
        {

            TextWriter tw = new StreamWriter(filename,false);
            
            tw.WriteLine("PLATFORM LINE, LINE 2, LINE 3, LINE 4, LINE 5, LINE 6,ASILIKALI, GOODS SHED,TOTAL,TERMINAL 1, TERMINAL 2, WORKSHOP LINE");
            tw.Close();


            tw = new StreamWriter(filename,true);

       



            for (int i = 0; i < acountant.Count; i++)
            {
                string one_;
                string two_;
                string three_;
                string four_;
                string five_;
                string six_;
                string seven_;
                string eight_;
                string ten_;
                string eleven_;
                string twelve_;
                string thirteen_;

                if (i < one.Count)
                {
                    one_ = one[i];
                }
                else {
                    one_ = "";
                }
                /////////////////// 
                if (i < two.Count)
                {
                    two_ = two[i];
                }
                else
                {
                    two_ = "";
                }
                ////////
                if (i < three.Count)
                {
                    three_ = three[i];
                }
                else
                {
                    three_ = "";
                }
                //////////////
                if (i < four.Count)
                {
                    four_ = four[i];
                }
                else
                {
                    four_ = "";
                }
                //////
                if (i < five.Count)
                {
                    five_ = five[i];
                }
                else
                {
                    five_ = "";
                }
                /////
                if (i < six.Count)
                {
                    six_ = six[i];
                }
                else
                {
                    six_ = "";
                }
                ////
                if (i < seven.Count)
                {
                    seven_ = seven[i];
                }
                else
                {
                   seven_ = "";
                }
                ////////
                if (i < eight.Count)
                {
                    eight_ = eight[i];
                }
                else
                {
                    eight_ = "";
                }
                /////
                if (i < ten.Count)
                {
                    ten_ = ten[i];
                }
                else
                {
                    ten_ = "";
                }
                /////
                if (i < eleven.Count)
                {
                    eleven_ = eleven[i];
                }
                else
                {
                    eleven_ = "";
                }
                //////
                if (i < twelve.Count)
                {
                    twelve_ = twelve[i];
                }
                else
                {
                    twelve_ = "";
                }
                /////
                if (i < thirteen.Count)
                {
                    thirteen_ = thirteen[i];
                }
                else
                {
                    thirteen_ = "";
                }


              
                tw.WriteLine(one_ + "," + two_ + "," +
                    three_ + "," + four_ + "," + five_
                    + "," + six_ + "," + seven_ + "," + eight_
                    + "," + ten_ + "," + eleven_ + "," + twelve_
                    + "," + thirteen_);
                
            }
             tw.Close();




          

            

        }
    
    
    
    }







}
