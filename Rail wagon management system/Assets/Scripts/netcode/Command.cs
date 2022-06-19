using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Command : MonoBehaviour
{
    public static Command Instance;
    public Web web_;
    public Train_model train_Model;
    public SearchableDropDown s_drop;
    public DragDrop dd_;
    public slide_updown_anim updown_anim;
    public slide_objectlist_updown_anim updown_anim_objectlist;
    public Manager manage;
    public active_train_motherbox train_list;
    public TabButtonUI tab_but_ui;
    public train_conduit t_conduit;
    public train_instance_holder train_instance;
    public Summery_generator sam_generator;
    public CSVWriter csv;
    public note_item_Class note_item;
    public note_item_class_night note_item_night;
    public player_prefs prefs;
    Action<String> _conn;
    public Perfomance_code perf_code;
    public Perfomance_code_night perf_code_night;
    public Update_man update_user;
    public enrol_wagon enrol_wagy;
    public list_to_verify listValify;
    public searchWagon search_man;

    public GameObject online;
    public GameObject offline;

    public GameObject blocker;
    public GameObject blocker1;
    public GameObject blocker2;

    public string user_id__ { set; get; }
    public string user_name__ { set; get; }
    public string surname__ { set; get; }
    public string isSuperUser__ { set; get; }


    public void saved_DATA(string user_id, string user_name, string surname, string isSuperUser)
    {
        PlayerPrefs.SetString("user_id_data", user_id);
        PlayerPrefs.SetString("user_name_data", user_name);
        PlayerPrefs.SetString("surname_data", surname);
        PlayerPrefs.SetString("isSuperUser_data", isSuperUser);
        PlayerPrefs.Save();
    }

    public void pull_DATA()
    {
        this.user_id__ = PlayerPrefs.GetString("user_id_data");
        this.user_name__ = PlayerPrefs.GetString("user_name_data");
        this.surname__ = PlayerPrefs.GetString("surname_data");
        this.isSuperUser__ = PlayerPrefs.GetString("isSuperUser_data");

    }

    public void wipe_prefs() 
    {
        PlayerPrefs.DeleteKey("user_id_data");
        PlayerPrefs.DeleteKey("user_name_data");
        PlayerPrefs.DeleteKey("surname_data");
        PlayerPrefs.DeleteKey("isSuperUser_data");
        PlayerPrefs.Save();
        SceneManager.LoadScene("realnetworktests");

    }

    public void account() 
    {
        SceneManager.LoadScene("ACCOUNT");
    }

    public void enrole_wagon()
    {
        SceneManager.LoadScene("enrol_wagon");
    }

    public void go_home()
    {
        SceneManager.LoadScene("ACCOUNT");
    }

    private void Awake()
    {
        check_eligibility();
    }

    private void Start()
    {
        Instance = this;

        web_ = GetComponent<Web>();
        train_Model = GetComponent<Train_model>();
        s_drop = GetComponent<SearchableDropDown>();
        dd_ = GetComponent<DragDrop>();
        updown_anim = FindObjectOfType<slide_updown_anim>();
        updown_anim_objectlist = FindObjectOfType<slide_objectlist_updown_anim>();
        manage = GetComponent<Manager>();
        train_list = GetComponent<active_train_motherbox>();
        tab_but_ui = GetComponent<TabButtonUI>();
        t_conduit = GetComponent<train_conduit>();
        sam_generator = GetComponent<Summery_generator>();
        train_instance = GetComponent<train_instance_holder>();
        csv = GetComponent<CSVWriter>();
        perf_code = GetComponent<Perfomance_code>();
        perf_code_night = GetComponent<Perfomance_code_night>();
        note_item = GetComponent<note_item_Class>();
        note_item_night = GetComponent<note_item_class_night>();
        prefs = GetComponent<player_prefs>();
        update_user = GetComponent<Update_man>();
        listValify = GetComponent<list_to_verify>();
        enrol_wagy = GetComponent<enrol_wagon>();
        search_man = GetComponent<searchWagon>();
        offline.SetActive(false);
        Start_date_coroutine();


       

    }
    public void check_eligibility()
    {
        this.user_id__ = PlayerPrefs.GetString("user_id_data");
        this.user_name__ = PlayerPrefs.GetString("user_name_data");
        this.surname__ = PlayerPrefs.GetString("surname_data");
        this.isSuperUser__ = PlayerPrefs.GetString("isSuperUser_data");

       
            pull_DATA();
            string isSuper = isSuperUser__;
            Debug.Log(isSuper);
            if (isSuper.Equals("yes"))
            {
                Debug.Log("YOU ARE WORTHY");
                if (blocker != null && blocker1 != null && blocker2 != null)
                {
                    blocker.SetActive(false);
                    blocker1.SetActive(true);
                    blocker2.SetActive(true);
                }

            }
            else if (isSuper.Equals("no"))
            {
                Debug.Log("YOU ARE NOT WORTHY");
                if (blocker != null && blocker1 != null && blocker2 != null)
                {
                    blocker.SetActive(true);
                    blocker1.SetActive(false);
                    blocker2.SetActive(false);
                }

            }
        
    
    }

    public void get_references()
    {
        

        //Debug.Log("...............CALLED.............");
        s_drop = FindObjectOfType<SearchableDropDown>();
        dd_ = FindObjectOfType<DragDrop>();
        updown_anim_objectlist = FindObjectOfType<slide_objectlist_updown_anim>();
        t_conduit = FindObjectOfType<train_conduit>();
        train_instance = FindObjectOfType<train_instance_holder>();
        csv = FindObjectOfType<CSVWriter>();
        perf_code = FindObjectOfType<Perfomance_code>();
        perf_code_night = FindObjectOfType<Perfomance_code_night>();
        note_item = FindObjectOfType<note_item_Class>();
        note_item_night = FindObjectOfType<note_item_class_night>();
        prefs = FindObjectOfType<player_prefs>();
        update_user = FindObjectOfType<Update_man>();
        listValify = FindObjectOfType<list_to_verify>();
        enrol_wagy = FindObjectOfType<enrol_wagon>();
        search_man = FindObjectOfType<searchWagon>();


    }


    



    public void check_user_stat() 
    {
        check_eligibility();
        pull_DATA();
        string name_ = Command.Instance.user_name__;
        string surname_ = Command.Instance.surname__;
        string userid_ = Command.Instance.user_id__;
        string isSuper_ = Command.Instance.isSuperUser__;

        if (name_.Equals("") || surname_.Equals("") || userid_.Equals("") || isSuper_.Equals(""))
        {
            Debug.Log("you need to go");
            wipe_prefs();
        }
        else {
            Debug.Log("you are ok");
        }

    }

    void check_connection_status()
    {
        check_user_stat();
        connection();
     
    }
    public void Stop_date_coroutine()
    {
  
        CancelInvoke("check_connection_status");
    }
    public void Start_date_coroutine()
    {
        InvokeRepeating("check_connection_status", 2.0f, 1f);
    }




    public void connection()
    {

        _conn = (connect) =>
        {

            StartCoroutine(make_connection(connect));

        };

        StartCoroutine(Instance.web_.Test_connection(_conn));

    }
    public IEnumerator make_connection(string jsonArraystring_)
    {

       // Debug.Log(jsonArraystring_);

        if (jsonArraystring_.Equals("Cannot connect to destination host"))
        {
            if (online != null) 
            {
                online.SetActive(false);
            }
            if (offline != null)
            {
                offline.SetActive(true);
            }
          
        } else if (jsonArraystring_.Equals("root@localhost")) 
        {

            if (online != null)
            {
                online.SetActive(true);
            }
              
            if (offline != null)
            {
                offline.SetActive(false);
            }
               
        }


            yield return null;
        

    }
}
