using EasyUI.Popup;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class login_form : MonoBehaviour
{
    public InputField USER_id_Input;
    public InputField PasswordInput;
    public Button LoginButton;
    public GameObject reg_form;
    Action<String> the_login_man;
    Action<String> pull_user_data;






    public void getsome() 
    {

       // PlayerPrefs.DeleteAll();
        //Command.Instance.get_references();

        //Command.Instance.wipe_prefs();
        
        Command.Instance.pull_DATA();
        string name_ = Command.Instance.user_name__;
        string surname_ = Command.Instance.surname__;
        string userid_ = Command.Instance.user_id__;
        string isSuper_ = Command.Instance.isSuperUser__;

        if (name_!= "" || surname_ != "" || userid_ != "" || isSuper_ != "") 
        {
            SceneManager.LoadScene("central");
        }
       // Debug.Log("..lll......" + name_ + ".." + surname_ + ".." + userid_ + ".." + isSuper_);
        
    }
    private void Awake()
    {
        Invoke("getsome", 0f);
    }


    // Start is called before the first frame update
    void Start()
    {

        


        LoginButton.onClick.AddListener(() => {

            if (USER_id_Input.text.Equals("") || PasswordInput.text.Equals(""))
            {
                Debug.Log("make sure all inputs are filled");
                Popup.Show("Error", "make sure all inputs are filled", "OK", PopupColor.Red);
                return;

            }
            if (PasswordInput.text.Length < 8) 
            {
                Popup.Show("Error", "Make sure the password is 8 charcters or more", "OK", PopupColor.Red);
                return;
            }

            the_login_man = (specific_vehicle_jsonArraystring) => {

                StartCoroutine(Create_login_q(specific_vehicle_jsonArraystring));

            };

            StartCoroutine(Command.Instance.web_.Login_user(USER_id_Input.text, PasswordInput.text, the_login_man));

            // Command.Instance.web_.Login_user();

        });
    }


    public IEnumerator Create_login_q(string jsonArraystring_)
    {
       

        if (jsonArraystring_.Equals("Wrong User ID"))
        {
            Debug.Log("Wrong password or User ID");
            Popup.Show("Error", "Wrong password or User ID", "OK", PopupColor.Red);
           
        }
        else if(jsonArraystring_.Equals(""))
        {
            Popup.Show("Error", "Wrong password or User ID", "OK", PopupColor.Red);
        }
        else 
        {

            get_user_data(jsonArraystring_);
        }

        yield return null;
    }


    public void get_user_data(string user_id ) 
    {

        pull_user_data = (specific_vehicle_jsonArraystring) => {

            StartCoroutine(pull_user(specific_vehicle_jsonArraystring));

        };

        StartCoroutine(Command.Instance.web_.Get_user_data(user_id, pull_user_data));

    }

    public IEnumerator pull_user(string jsonArraystring_)
    {
        //Parsing json array
        JSONArray jsonArray_vehicles = JSON.Parse(jsonArraystring_) as JSONArray;

        for (int i = 0; i < jsonArray_vehicles.Count; i++)
        {
        
            String user_id = jsonArray_vehicles[i].AsObject["U_userid"];
            String username = jsonArray_vehicles[i].AsObject["U_surname"];
            String name  = jsonArray_vehicles[i].AsObject["U_name"];
            String sup_user = jsonArray_vehicles[i].AsObject["isSuper_user"];

           // Debug.Log(user_id+".."+username+".."+name+".."+sup_user);
            Command.Instance.saved_DATA(user_id, username, name, sup_user);

            Command.Instance.pull_DATA();
            string name_ =  Command.Instance.user_name__;
            string surname_ = Command.Instance.surname__;
            string userid_ = Command.Instance.user_id__;
            string isSuper_ = Command.Instance.isSuperUser__;
            SceneManager.LoadScene("central");
            //  Debug.Log("........"+name_ + ".." + surname_ + ".." + userid_ + ".." + isSuper_);
        }

        yield return null;
    }

    public void reveal_reg()
    {
        reg_form.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
