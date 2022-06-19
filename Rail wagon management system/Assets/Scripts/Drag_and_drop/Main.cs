using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance;

    public Register register;
    public Login login;
    public getItemIDs getitemids;
    public userInfo userInfo;
    public getItem getitem;


    public GameObject loginform;
    public GameObject userProfile;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        register = GetComponent<Register>();
        login = GetComponent<Login>();
        getitemids = GetComponent<getItemIDs>();
        userInfo = GetComponent<userInfo>();
        getitem = GetComponent<getItem>();



    }

   
}
