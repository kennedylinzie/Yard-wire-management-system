using EasyUI.Popup;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Perfomance_code_night : MonoBehaviour
{

    public GameObject itemli;
    public GameObject spawn_parent;
    Action<String> _download_notes_night;
    Action<String> _upload_notes_night;

    [System.Serializable]
    public class Note
    {
        public Note(string planned_activities_, string active_loco_, string wagon_plan_, string achieved_activities_
            , string loco_, string wagon_, string time_plan_, string time_real_in_, string time_out_finish_, string status_
            , string comments_, string pos_)
        {
            planned_activities = planned_activities_;
            active_loco = active_loco_;
            wagon_plan = wagon_plan_;
            achieved_activities = achieved_activities_;
            loco = loco_;
            wagon = wagon_;
            time_plan = time_plan_;
            time_real_in = time_real_in_;
            time_out_finish = time_out_finish_;
            status = status_;
            comments = comments_;
            pos = pos_;
        }
        public string planned_activities;
        public string active_loco;
        public string wagon_plan;
        public string achieved_activities;
        public string loco;
        public string wagon;
        public string time_plan;
        public string time_real_in;
        public string time_out_finish;
        public string status;
        public string comments;
        public string pos;
    }

    [System.Serializable]
    public class noteList
    {
        public List<Note> noty = new List<Note>();
    }
    public noteList mynoteList = new noteList();
    public void add_list()
    {
        //mynoteList.noty.Add(new Note("kennedy", "50"));
        //mynoteList.noty.Add(new Note("james", "12"));
        //mynoteList.noty.Add(new Note("sally", "16"));
        // mynoteList.noty.Add(new Note("mike", "35"));
    }

    public void modify_home(string planned_activities_, string active_loco_, string wagon_plan_, string achieved_activities_
            , string loco_, string wagon_, string time_plan_, string time_real_in_, string time_out_finish_, string status_
            , string comments_, string pos_)
    {

        for (int i = 0; i < mynoteList.noty.Count; i++)
        {
            if (mynoteList.noty[i].pos.Equals(pos_))
            {
                mynoteList.noty[i].planned_activities = planned_activities_;
                mynoteList.noty[i].active_loco = active_loco_;
                mynoteList.noty[i].wagon_plan = wagon_plan_;
                mynoteList.noty[i].achieved_activities = achieved_activities_;
                mynoteList.noty[i].loco = loco_;
                mynoteList.noty[i].wagon = wagon_;
                mynoteList.noty[i].time_plan = time_plan_;
                mynoteList.noty[i].time_real_in = time_real_in_;
                mynoteList.noty[i].time_out_finish = time_out_finish_;
                mynoteList.noty[i].status = status_;
                mynoteList.noty[i].comments = comments_;
                save_list();
            }
        }


    }

    public void Delete_note(string pos_)
    {

        for (int i = 0; i < mynoteList.noty.Count; i++)
        {
            if (mynoteList.noty[i].pos.Equals(pos_))
            {
                mynoteList.noty.RemoveAt(i);
                save_list();
                clear_field();
                get_list();
            }
        }


    }



    public void save_list()
    {
        PlayerPrefsExtra.SetObject("notes_night", mynoteList);
        PlayerPrefs.Save();

    }



    public void save_data_to_server()
    {
        PlayerPrefsExtra.SetObject("notes_night", mynoteList);
        PlayerPrefs.Save();
        string json = JsonUtility.ToJson(mynoteList);
        //Debug.Log(json);
        notesUploader(json);
    }

    public void notesUploader(string note_object)
    {
        _upload_notes_night = (specific_vehicle_jsonArraystring) => {

            StartCoroutine(note_upload_messenger(specific_vehicle_jsonArraystring));

        };
        StartCoroutine(Command.Instance.web_.Upload_night_notes(note_object, _upload_notes_night));

    }
    public IEnumerator note_upload_messenger(string jsonArraystring_)
    {

        if (jsonArraystring_.Equals("upload Successful"))
        {
            Popup.Show("Success", jsonArraystring_, "OK", PopupColor.Green);
        }
        else
        {
            Popup.Show("Success", jsonArraystring_, "OK", PopupColor.Green);

        }
        yield return null;
    }

    public void notesDownloader()
    {
        _download_notes_night = (specific_vehicle_jsonArraystring) => {

            StartCoroutine(note_downloader_messenger(specific_vehicle_jsonArraystring));

        };
        StartCoroutine(Command.Instance.web_.Download_night_notes(_download_notes_night));

    }

    public IEnumerator note_downloader_messenger(string jsonArraystring_)
    {

        // Debug.Log("........THIS IS YOUR JSON...................."+jsonArraystring_);
        if (jsonArraystring_ != "")
        {
            clear_field();
            noteList mynoteList_ = JsonUtility.FromJson<noteList>(jsonArraystring_);
            Debug.Log(mynoteList_ + "" + jsonArraystring_);
            Popup.Show("Success", "Download Successfull", "OK", PopupColor.Green);
            PlayerPrefsExtra.SetObject("notes_night", mynoteList_);
            //PlayerPrefs.Save();

            get_list();
        }



        yield return null;
    }




    public void get_list()
    {
        mynoteList = PlayerPrefsExtra.GetObject<noteList>("notes_night", new noteList());

        for (int i = 0; i < mynoteList.noty.Count; i++)
        {

            string planned_activities = mynoteList.noty[i].planned_activities;
            string active_loco = mynoteList.noty[i].active_loco;
            string wagon_plan = mynoteList.noty[i].wagon_plan;
            string achieved_activities = mynoteList.noty[i].achieved_activities;
            string loco = mynoteList.noty[i].loco;
            string wagon = mynoteList.noty[i].wagon;
            string time_plan = mynoteList.noty[i].time_plan;
            string time_real_in = mynoteList.noty[i].time_real_in;
            string time_out_finish = mynoteList.noty[i].time_out_finish;
            string status = mynoteList.noty[i].status;
            string comments = mynoteList.noty[i].comments;
            string pos = mynoteList.noty[i].pos;


            fill_the_list_RECOVERY(planned_activities, active_loco, wagon_plan, achieved_activities
            , loco, wagon, time_plan, time_real_in, time_out_finish, status
            , comments, pos);


        }

    }

    public void clear_field()
    {
        foreach (Transform child in spawn_parent.transform)
        {
            GameObject.Destroy(child.gameObject);

            // Popup.Show("Success", "Station Refreshed", "OK", PopupColor.Green);
        }
    }

    private void Start()
    {

        Command.Instance.get_references();
        get_list();
        Debug.Log("start actually run");
    }


    /// <summary>
    /// recover the saved list
    /// </summary>

    public void fill_the_list_RECOVERY(string planned_activities_, string active_loco_, string wagon_plan_, string achieved_activities_
            , string loco_, string wagon_, string time_plan_, string time_real_in_, string time_out_finish_, string status_
            , string comments_, string pos_)
    {



        GameObject item = Instantiate(itemli);
        item.transform.SetParent(spawn_parent.transform);
        //item.transform.localScale = Vector3.zero;
        //item.transform.localPosition = Vector3.zero;
        item.gameObject.name = pos_;


        item.transform.gameObject.GetComponent<note_item_class_night>().set_Note(planned_activities_, active_loco_, wagon_plan_, achieved_activities_
            , loco_, wagon_, time_plan_, time_real_in_, time_out_finish_, status_
            , comments_, pos_);
        item.transform.localScale = new Vector3(0.946401f, 0.946401f, 0.946401f);

    }



    /// <summary>
    /// insert a new thing
    /// </summary>

    public void fill_the_list()
    {

        mynoteList.noty.Add(new Note("", "", "", "", "", "", "", "", "", "", "", "" + (mynoteList.noty.Count + 1)));

        GameObject item = Instantiate(itemli);
        item.transform.SetParent(spawn_parent.transform);
        
        item.gameObject.name = mynoteList.noty.Count + "";

        item.transform.localScale = new Vector3(0.946401f, 0.946401f, 0.946401f);
    }



    public void WriteCSV()
    {
        save_list();
        DateTime aDate = DateTime.Now;
        string special_name = aDate.ToString("dddd, dd MMMM yyyy");
        string filename = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/" + special_name + " NIGHT PLAN.CSV";

        //Debug.Log
        // Format Datetime in different formats and display them  
        Popup.Show("Success", "Export Successful Look for the file on your desktop", "OK", PopupColor.Green);

        Command.Instance.pull_DATA();
        string name_ = Command.Instance.user_name__;
        string surname_ = Command.Instance.surname__;
        string userid_ = Command.Instance.user_id__;
        string isSuper_ = Command.Instance.isSuperUser__;

        TextWriter tw = new StreamWriter(filename, false);
        tw.WriteLine(name_ + " "+ surname_);
        tw.WriteLine("PLANNED ACTIVITIES, PLANNED ACTIVITIES > LOCO, WAGON(PLAN), ACHIEVED ACTIVITIES, LOCO,WAGON(REAL),TIME(PLAN), TIME(REAL IN),TIME(OUT/FINISH),STATUS,COMMENT");

        tw.Close();

        tw = new StreamWriter(filename, true);


        mynoteList = null;
        mynoteList = PlayerPrefsExtra.GetObject<noteList>("notes_night", new noteList());

        for (int i = 0; i < mynoteList.noty.Count; i++)
        {

            string planned_activities = mynoteList.noty[i].planned_activities;
            string active_loco = mynoteList.noty[i].active_loco;
            string wagon_plan = mynoteList.noty[i].wagon_plan;
            string achieved_activities = mynoteList.noty[i].achieved_activities;
            string loco = mynoteList.noty[i].loco;
            string wagon = mynoteList.noty[i].wagon;
            string time_plan = mynoteList.noty[i].time_plan;
            string time_real_in = mynoteList.noty[i].time_real_in;
            string time_out_finish = mynoteList.noty[i].time_out_finish;
            string status = mynoteList.noty[i].status;
            string comments = mynoteList.noty[i].comments;
            string pos = mynoteList.noty[i].pos;


            tw.WriteLine(planned_activities + "     " + "," + active_loco + "," +
                wagon_plan + "," + achieved_activities + "," + loco
                + "," + wagon + "," + time_plan + "," + time_real_in
                + "," + time_out_finish + "," + status + "," + comments);





        }
        tw.Close();

    }

}
