using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class list_to_verify : MonoBehaviour
{

    Action<String> _createItems;
    public GameObject itemli;
    Action<String> _give_access;




    // Start is called before the first frame update
    void Start()
    {


        Invoke("create_terms", 1f);

    }
    public void create_terms() 
    {
        clear_field();
        _createItems = (jsonArraystring) => {

            StartCoroutine(CreateItemsRoutin(jsonArraystring));

        };

        StartCoroutine(Command.Instance.web_.get_unverified_users(_createItems));

    }

    public void clear_field()
    {
        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
        
            
        }
    }

    IEnumerator CreateItemsRoutin(string jsonArraystring)
    { 
        //Parsing json array
        JSONArray jsonArray = JSON.Parse(jsonArraystring) as JSONArray;

        for (int i = 0; i < jsonArray.Count; i++)
        {
           
            String name = jsonArray[i].AsObject["U_name"];
            String surname = jsonArray[i].AsObject["U_surname"];
            String userid = jsonArray[i].AsObject["U_userid"];
         
            GameObject item = Instantiate(itemli);
            item.transform.SetParent(this.transform);
           
            //fill information
            item.transform.Find("name").GetComponent<Text>().text = name;
            item.transform.Find("surname").GetComponent<Text>().text = surname;
            item.transform.Find("userid").GetComponent<Text>().text = userid;
            item.gameObject.gameObject.name = userid;
            item.transform.Find("veri").GetComponent<Button>().onClick.AddListener(() => {
                access_giver(userid);
            });
            //continue to the next item
            item.transform.localScale = new Vector3(1f,1f,1f);
        }
        yield return null;
    }

    public void access_giver(string num) 
    {

       
        _give_access = (jsonArraystring) => {

            StartCoroutine(Create_access_result(jsonArraystring));

        };

        StartCoroutine(Command.Instance.web_.give_access_(num,_give_access));

    }


    IEnumerator Create_access_result(string jsonArraystring)
    {
        Debug.Log("mose ...."+jsonArraystring);
        if (jsonArraystring.Equals("modification Successful")) 
        {
            create_terms();
        }
        yield return null;
    }

}
