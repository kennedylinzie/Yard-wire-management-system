using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_prefs : MonoBehaviour
{
    
    public string user_id { set; get; }
    public string user_name { set; get; }
    public string surname { set; get; }
    public string isSuperUser { set; get; }


    public void saved_DATA(string user_id, string user_name, string surname, string isSuperUser) 
    {
         PlayerPrefs.SetString("user_id", user_id);  
         PlayerPrefs.SetString("user_name", user_name);       
         PlayerPrefs.SetString("surname", surname);
         PlayerPrefs.SetString("isSuperUser", isSuperUser);
         PlayerPrefs.Save();
    }

    public void pull_DATA()
    {
        this.user_id = PlayerPrefs.GetString("user_id");
        this.user_name = PlayerPrefs.GetString("user_name");
        this.surname = PlayerPrefs.GetString("surname");
        this.isSuperUser = PlayerPrefs.GetString("isSuperUser");
        
    }
}
