
using UnityEngine;

public class userInfo : MonoBehaviour
{

    public string userID { get; private set; }
    public string userName;
    public string userPassword;
    public string level;
    public string coins; 

    public void SetCredentials(string username,string password) 
    {
        userName = username;
        userPassword = password;
    }

    public void SetID(string id)  
    {
        userID = id; 
    
    }


}
