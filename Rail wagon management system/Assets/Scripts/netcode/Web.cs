using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    
    public IEnumerator Get_vehecle_number(System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 1);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/getTrain.php",form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                //Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
                string jsonArray = www.downloadHandler.text;
                callback(jsonArray);
            }
        }
    }
    public IEnumerator Get_vehecle_data(string v_number ,System.Action<string> callback1)
    {
        WWWForm form = new WWWForm();
        form.AddField("key",2);
        form.AddField("v_number",v_number);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/getTrain.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
                string jsonArray = www.downloadHandler.text;
                callback1(jsonArray);
            }
        }
    }
    public IEnumerator Update_vehecle_data(string v_number, string Line, string Date_Hour_Last_Event, string Status, System.Action<string> callback1)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 3);
        form.AddField("v_number", v_number);

        form.AddField("Line", Line);
        //form.AddField("No_of_wagons", No_of_wagons);
        form.AddField("Date_Hour_Last_Event", Date_Hour_Last_Event);
        form.AddField("Status", Status);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/getTrain.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
               // Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
                //string jsonArray = www.downloadHandler.text;
                callback1(www.downloadHandler.text);
            }
        }
    }
    public IEnumerator Update_position_and_line(string v_number, string Line, string posx, string posy, System.Action<string> callback1)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 4);
        form.AddField("v_number", v_number);
        form.AddField("Line", Line);
        form.AddField("posY", posy);
        form.AddField("posX", posx);




        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/getTrain.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                // Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
                //string jsonArray = www.downloadHandler.text;
                callback1(www.downloadHandler.text);
            }
        }
    }
    public IEnumerator Get_all_unreleased_vehicles(System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 5);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/getTrain.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                //Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
               
                string jsonArray = www.downloadHandler.text;
                if (jsonArray.Equals(""))
                {
                    
                }
                else {
                    callback(jsonArray);
                }
               
            }
        }
    }
    public IEnumerator Train_leaves_platform(string vnum,System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 6);
        form.AddField("released_state", "yes");
        form.AddField("v_number", vnum);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/getTrain.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                //Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
                string jsonArray = www.downloadHandler.text;
                callback(jsonArray);
            }
        }
    }
    public IEnumerator Train_added_to_platform(string vnum,string data_home,System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 6);
        form.AddField("released_state", "no");
        form.AddField("v_number", vnum);
        form.AddField("data_home", data_home);



        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/getTrain.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                //Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
                string jsonArray = www.downloadHandler.text;
                callback(jsonArray);
            }
        }
    }
    public IEnumerator Test_connection(System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
       



        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/Get_SERVER_ACESS.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
              
                callback(www.error);
            }
            else
            {
                callback(www.downloadHandler.text);
            }
        }
    }
    public IEnumerator Train_object_insert(string name,string posx,string posy,string tag, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 7);

         

        form.AddField("name",name);
        form.AddField("posx",posx);
        form.AddField("posy",posy);
        form.AddField("obj_tag",tag);



        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/getTrain.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
          
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                //Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
                string jsonArray = www.downloadHandler.text;
             
                    callback(jsonArray);
               
               
               // callback(jsonArray);
            }
        }
    }
    public IEnumerator Train_object_update(string name, string posx, string posy, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 8);
        form.AddField("name", name);
        form.AddField("posx", posx);
        form.AddField("posy", posy);
      

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/getTrain.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                //Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
                string jsonArray = www.downloadHandler.text;
                callback(jsonArray);
            }
        }
    }
    public IEnumerator Get_all_persist_object_data(System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 9);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/getTrain.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                //Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result

                string jsonArray = www.downloadHandler.text;
                if (jsonArray.Equals(""))
                {

                }
                else
                {
                    callback(jsonArray);
                }

            }
        }
    }
    public IEnumerator Get_object_data_contents(string home, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 10);
        form.AddField("Data_home", home);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/getTrain.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                //Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result

                string jsonArray = www.downloadHandler.text;
                if (jsonArray.Equals(""))
                {

                }
                else
                {
                    callback(jsonArray);
                }

            }
        }


    }
    public IEnumerator Get_object_data_for_summary(string home, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 11);
        form.AddField("Data_home", home);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/getTrain.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                //Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result

                string jsonArray = www.downloadHandler.text;
                if (jsonArray.Equals(""))
                {

                }
                else
                {
                    callback(jsonArray);
                }

            }
        }


    }
    public IEnumerator Remove_wagon_from_body(string vehicle_number, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 12);
        form.AddField("Vehicle", vehicle_number);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/getTrain.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {        
                    callback(www.downloadHandler.text);
            }
        }


    }
    public IEnumerator Remove_wagon_body(string name,System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 13);
        form.AddField("name", name);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/getTrain.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                callback(www.downloadHandler.text);
            }
        }


    }
    public IEnumerator Remove_wagon_body_no_wait(string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 13);
        form.AddField("name", name);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/getTrain.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                
               Debug.Log(www.downloadHandler.text);
            }
        }


    }

    public IEnumerator Register_user(string name, string surname, string userid, string password,string usSuper, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("name",name);
        form.AddField("surname",surname);
        form.AddField("userid",userid);
        form.AddField("password",password);
        form.AddField("isSuper_user", usSuper);
        form.AddField("key",1);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/Register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log(www.downloadHandler.text);
                callback(www.downloadHandler.text);

            }
        }
    }

    public IEnumerator Login_user(string user_id, string password,System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", user_id);
        form.AddField("password", password);
        form.AddField("key",1);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {

                //Debug.Log(www.downloadHandler.text);
                callback(www.downloadHandler.text);

            }
        }
    }

    public IEnumerator Get_user_data(string userid, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 2);
        form.AddField("userid", userid);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                //Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result

                string jsonArray = www.downloadHandler.text;
                if (jsonArray.Equals(""))
                {

                }
                else
                {
                    callback(jsonArray);
                }

            }
        }


    }

    public IEnumerator Delete_user_account(string userid, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 3);
        form.AddField("user_id", userid);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                //Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result

                string jsonArray = www.downloadHandler.text;
                if (jsonArray.Equals(""))
                {

                }
                else
                {
                    callback(jsonArray);
                }

            }
        }


    }

    public IEnumerator Update_user(string name, string surname, string password, string userid, System.Action<string> callback1)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 4);
        form.AddField("U_name", name);

        form.AddField("U_surname", surname);
        form.AddField("user_id", userid);
        form.AddField("U_Password", password);
       

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                // Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
                //string jsonArray = www.downloadHandler.text;
                callback1(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator get_unverified_users(System.Action<string> callback1)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 5);
       

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                // Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
                //string jsonArray = www.downloadHandler.text;
                callback1(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator give_access_(string use_id,System.Action<string> callback1)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 6);
        form.AddField("user_id", use_id);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                // Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
                //string jsonArray = www.downloadHandler.text;
                callback1(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator get_super_user_count_(System.Action<string> callback1)
    {
        WWWForm form = new WWWForm();
        form.AddField("key",2);
 


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/Register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                callback1(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator Enrol_wagony( string Vehicle_Type, string Yard_Sector, string Vehicle, string Sequence,string Series, string Wagon_type, string Date_Hour_Last_Event ,string Status,System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
       
        form.AddField("Vehicle_Type", Vehicle_Type);
        form.AddField("Yard_Sector", Yard_Sector);
        form.AddField("Vehicle", Vehicle);
        form.AddField("Sequence", Sequence);
        form.AddField("Series", Series);
        form.AddField("Wagon_type", Wagon_type);
        form.AddField("Date_Hour_Last_Event", Date_Hour_Last_Event);
        form.AddField("Status", Status);
        form.AddField("key", 3);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/Register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log(www.downloadHandler.text);
                callback(www.downloadHandler.text);

            }
        }
    }

    public IEnumerator Download_day_notes(System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 3);
       


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/Notes_man.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                //Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result

                string jsonArray = www.downloadHandler.text;
             
                    callback(jsonArray);
                

            }
        }


    }

    public IEnumerator Download_night_notes(System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 4);
   


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/Notes_man.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                //Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result

                string jsonArray = www.downloadHandler.text;
               
                    callback(jsonArray);
                

            }
        }


    }


    public IEnumerator Upload_day_notes(string notes, System.Action<string> callback1)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 2);
        form.AddField("Noteboday", notes);

 

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/Notes_man.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                // Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
                //string jsonArray = www.downloadHandler.text;
                callback1(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator Upload_night_notes(string notes, System.Action<string> callback1)
    {
        WWWForm form = new WWWForm();
        form.AddField("key", 1);
        form.AddField("Noteboday", notes);



        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/railsystem/v1_/Notes_man.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //byte[] results = www.downloadHandler.data;
                // Debug.Log(www.downloadHandler.text);
                //call callback fucntion to pass result
                //string jsonArray = www.downloadHandler.text;
                callback1(www.downloadHandler.text);
            }
        }
    }

}
