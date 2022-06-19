using EasyUI.Popup;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class register_form : MonoBehaviour
{
    public InputField reg_NameInput;
    public InputField reg_SurnameInput;
    public InputField reg_UserID_Input;
    public InputField reg_PasswordInput;
    public InputField reg_PasswordInput1;
    public Button reg_Reg_Button;
    public GameObject login_form;
    public Text user_type;
    Action<String> Register_user;
    Action<String> Reg_get_super_count;
    public Dropdown USR_TYPE;




    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(user_type.text);

        reg_Reg_Button.onClick.AddListener(() => {

            //Debug.Log(reg_NameInput.text +""+ reg_SurnameInput.text + "" + reg_UserID_Input.text + "" + reg_PasswordInput.text);
            if (reg_NameInput.text.Equals("")|| reg_SurnameInput.text.Equals("") || reg_UserID_Input.text.Equals("") || reg_PasswordInput.text.Equals("") || reg_PasswordInput1.text.Equals("")) 
            {
                //Debug.Log("Make sure all inputs are filled");
               // Debug.Log("Text length  "+ reg_PasswordInput.text.Length);
                Popup.Show("Error", "make sure all inputs are filled", "OK", PopupColor.Red);
                return;

            }
            if (reg_PasswordInput.text.Length < 8 || reg_PasswordInput1.text.Length < 8) 
            {
                //Debug.Log("make sure the password has more than 8 characters");
                Popup.Show("Error", "make sure the password has more than 8 characters", "OK", PopupColor.Red);
                return;
            }
            

            if (reg_PasswordInput.text.Equals(reg_PasswordInput1.text))
            {
                string super ="";
                string user = user_type.text;
                if (user.Equals("User"))
                {
                    super = "no";
                } else if (user.Equals("Super User")) 
                {
                    super = "yes";
                }

                // Debug.Log(reg_NameInput.text+""+reg_SurnameInput.text+""+reg_PasswordInput.text+""+ super);

                // Command.Instance.web_.Register_user(reg_NameInput.text,reg_SurnameInput.text, reg_UserID_Input.text, reg_PasswordInput.text,super);
                Register_user = (specific_vehicle_jsonArraystring) => {

                    StartCoroutine(get_registration_result(specific_vehicle_jsonArraystring));

                };

           

                StartCoroutine(Command.Instance.web_.Register_user(reg_NameInput.text, reg_SurnameInput.text,reg_UserID_Input.text,reg_PasswordInput.text,super,Register_user));


            }
            else {
                Debug.Log("passwords dont match");
                Popup.Show("Error", "passwords dont match", "OK", PopupColor.Red);
            }


            //StartCoroutine(Main.Instance.register.Registe_r(reg_UsernameInput.text, reg_PasswordInput.text, 10, 1));

        });
        Manage_super_count();
    }


    public IEnumerator get_registration_result(string jsonArraystring_)
    {
        Debug.Log(jsonArraystring_);

        if (jsonArraystring_.Equals("Registration Successful")) 
        {
            reveal_login();
        }

        yield return null;
    }




    public void reveal_login()
    {
        login_form.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Manage_super_count()
    {
        Reg_get_super_count = (specific_vehicle_jsonArraystring) => {

            StartCoroutine(get_su_count(specific_vehicle_jsonArraystring));

        };



        StartCoroutine(Command.Instance.web_.get_super_user_count_(Reg_get_super_count));

    }

    public IEnumerator get_su_count(string jsonArraystring_)
    {
        //Parsing json array
        JSONArray jsonArray_vehicles = JSON.Parse(jsonArraystring_) as JSONArray;

        for (int i = 0; i < jsonArray_vehicles.Count; i++)
        {

            String super_count = jsonArray_vehicles[i].AsObject["COUNT(*)"];
           int su_count = int.Parse(super_count);
            if (su_count > 2) 
            {
                USR_TYPE.interactable = false;
            }

      
        }

        yield return null;
    }

}
