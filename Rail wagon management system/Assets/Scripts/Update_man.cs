using EasyUI.Popup;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Update_man : MonoBehaviour
{
    public InputField user_NAME_Input;
    public InputField surname_Input;
    public InputField USER_id_Input;
    public InputField PasswordInput;
    public InputField oldPasswordInput;
    public Button     LoginButton;

    public Text nam_e;
    public Text surnam_e;
    public Text user_id;
    private string oldPassword__from_db;

    Action<String> pulluser_data;
    Action<String> delete_my_account;
    Action<String> update_my_account;

    public GameObject accesgiver;

    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        Command.Instance.get_references();
        Invoke("get_data", 0f);
       
    }


    public void get_data() {

        Command.Instance.pull_DATA();
        string name_ = Command.Instance.user_name__;
        string surname_ = Command.Instance.surname__;
        string userid_ = Command.Instance.user_id__;
        string isSuper_ = Command.Instance.isSuperUser__;

        if (isSuper_.Equals("yes"))
        {
            Debug.Log("you have access");
            if (accesgiver != null) {
                accesgiver.SetActive(true);
            }
        } else if (isSuper_.Equals("no")) 
        {
            Debug.Log("you dont have access");
            if (accesgiver != null)
            {
                accesgiver.SetActive(false);
            }
        }

        if (name_ == "" || surname_ == "" || userid_ == "" || isSuper_ == "")
        {
            SceneManager.LoadScene("realnetworktests");
        }

        nam_e.text = name_;
         surnam_e.text = surname_;
         user_id.text = userid_;

       Debug.Log("........"+userid_);

        pulluser_data = (specific_vehicle_jsonArraystring) => {

            StartCoroutine(pull_user(specific_vehicle_jsonArraystring));

        };

        StartCoroutine(Command.Instance.web_.Get_user_data(userid_, pulluser_data));
    }
    public void go_home() 
    {

        SceneManager.LoadScene("central");

    }


    public IEnumerator pull_user(string jsonArraystring_)
    {
        //Parsing json array
        //Debug.Log(jsonArraystring_);
      
        JSONArray jsonArray_vehicles = JSON.Parse(jsonArraystring_) as JSONArray;

        for (int i = 0; i < jsonArray_vehicles.Count; i++)
        {

            String user_id = jsonArray_vehicles[i].AsObject["U_userid"];
            String username = jsonArray_vehicles[i].AsObject["U_surname"];
            String name = jsonArray_vehicles[i].AsObject["U_name"];
            String pass = jsonArray_vehicles[i].AsObject["U_Password"];

            set_data(user_id, username, name, pass);
            
        }
     

       
        yield return null;
    }

    public void set_data(String user_id, String username, String name, String password) 
    {
         user_NAME_Input.text = name;
         surname_Input.text = username;
         USER_id_Input.text = user_id;
         PasswordInput.text = "";
        oldPassword__from_db = password;



    }



    public void delete_account() 
    {
        Command.Instance.pull_DATA();
        string name_ = Command.Instance.user_name__;
        string surname_ = Command.Instance.surname__;
        string userid_ = Command.Instance.user_id__;
        string isSuper_ = Command.Instance.isSuperUser__;

        delete_my_account = (specific_vehicle_jsonArraystring) => {

            StartCoroutine(clean_account(specific_vehicle_jsonArraystring));

        };

        StartCoroutine(Command.Instance.web_.Delete_user_account(userid_, delete_my_account));
    }

    public IEnumerator clean_account(string jsonArraystring_)
    {
        //Parsing json array
        Debug.Log("deletion result "+jsonArraystring_);
        if (jsonArraystring_.Equals("modification Successful")) 
        {
            Command.Instance.wipe_prefs();
        }
        

        yield return null;
    }


    public void updateData() 
    {
        Encryptor enky = new Encryptor();

        Command.Instance.pull_DATA();
        string name_ = Command.Instance.user_name__;
        string surname_ = Command.Instance.surname__;
        string userid_ = Command.Instance.user_id__;
        string isSuper_ = Command.Instance.isSuperUser__;

        String user_id = userid_;
        String user_name = user_NAME_Input.text;
        String surname = surname_Input.text;
        String password = PasswordInput.text;
        String old_password = oldPasswordInput.text;

        string hash = enky.MD5Hash(old_password);
       
        

        if (user_id != "" || user_name != "" || surname != "" )
        {
            if (oldPasswordInput.text.Equals("") || password.Equals(""))
            {
                password = oldPassword__from_db;
            }
            if (oldPasswordInput.text != "" || password.Equals(""))
            {
                Popup.Show("Error", "If you will one fill both password inputs", "OK", PopupColor.Red);
                return;
            }

            if (password.Length > 7 && oldPasswordInput.text.Equals(""))
            {
                if (password.Length > 7)
                {
                    update_my_account = (specific_vehicle_jsonArraystring) =>
                    {

                        StartCoroutine(update_user(specific_vehicle_jsonArraystring));

                    };

                    StartCoroutine(Command.Instance.web_.Update_user(user_name, surname, password, userid_, update_my_account));
                }
                else if (oldPasswordInput.text != "" && oldPasswordInput.text.Length > 7 && hash.Equals(oldPassword__from_db))
                {
                    update_my_account = (specific_vehicle_jsonArraystring) =>
                    {

                        StartCoroutine(update_user(specific_vehicle_jsonArraystring));

                    };

                    StartCoroutine(Command.Instance.web_.Update_user(user_name, surname, oldPassword__from_db, userid_, update_my_account));
                }
                else 
                {
                    Popup.Show("Error", "Make sure the old password is fill if you need to update the password and more than 8 characters,else leave empty", "OK", PopupColor.Red);
                }
               
            }
            else {
               /// Debug.Log("password too short");
                Popup.Show("Error", "password too short", "OK", PopupColor.Red);
            }
           
        }

    }


    public IEnumerator update_user(string jsonArraystring_)
    {
        //Parsing json array
        Command.Instance.pull_DATA();
        string name_ = Command.Instance.user_name__;
        string surname_ = Command.Instance.surname__;
        string userid_ = Command.Instance.user_id__;
        string isSuper_ = Command.Instance.isSuperUser__;
        Debug.Log("update result " + jsonArraystring_);
        if (jsonArraystring_.Equals("modification Successful"))
        {
            Popup.Show("Error", "Update Successfull", "OK", PopupColor.Red);
            pulluser_data = (specific_vehicle_jsonArraystring) => {

                StartCoroutine(after_update_pull_users(specific_vehicle_jsonArraystring));

            };

            StartCoroutine(Command.Instance.web_.Get_user_data(userid_, pulluser_data));
        }


        yield return null;
    }


    public IEnumerator after_update_pull_users(string jsonArraystring_)
    {
        //Parsing json array
        //Debug.Log(jsonArraystring_);

        JSONArray jsonArray_vehicles = JSON.Parse(jsonArraystring_) as JSONArray;

        for (int i = 0; i < jsonArray_vehicles.Count; i++)
        {

            String _user_id = jsonArray_vehicles[i].AsObject["U_userid"];
            String surname = jsonArray_vehicles[i].AsObject["U_surname"];
            String name = jsonArray_vehicles[i].AsObject["U_name"];
            String isSuper = jsonArray_vehicles[i].AsObject["isSuper_user"];
            String pass = jsonArray_vehicles[i].AsObject["U_Password"];


            Command.Instance.saved_DATA(_user_id, name, surname, isSuper);
            set_data(_user_id, surname, name, pass);

            Command.Instance.pull_DATA();
            string name_ = Command.Instance.user_name__;
            string surname_ = Command.Instance.surname__;
            string userid_ = Command.Instance.user_id__;
            string isSuper_ = Command.Instance.isSuperUser__;

            nam_e.text = name_;
            surnam_e.text = surname_;
            user_id.text = userid_;

        }



        yield return null;
    }

}
