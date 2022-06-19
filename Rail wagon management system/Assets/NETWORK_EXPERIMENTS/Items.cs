using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;
using UnityEngine.UI;


public class Items : MonoBehaviour
{

    Action<String> _createItemsCallback;
    public GameObject itemli;


    

    // Start is called before the first frame update
    void Start()
    {
      

        _createItemsCallback = (jsonArraystring) => {

            StartCoroutine(CreateItemsRoutin(jsonArraystring));

        };
        Create_items();
    }

    public void Create_items()
    {
        String userId = Main.Instance.userInfo.userID;
        StartCoroutine(Main.Instance.getitemids.GetItem_IDS(userId, _createItemsCallback));

    }


    IEnumerator CreateItemsRoutin(string jsonArraystring) 
    {
        //Parsing json array
        JSONArray jsonArray = JSON.Parse(jsonArraystring) as JSONArray;

        for (int i = 0; i < jsonArray.Count; i++)
        {
            bool isDone = false;
            String itemId = jsonArray[i].AsObject["itemID"];

            JSONObject itemInfor = new JSONObject();

            //CREATE A CALL BACK TOT EGT THE INFORMATION FROM WEB.CS
            Action<string> getItemInfomcallback = (itemInfo) => 
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(itemInfo) as JSONArray;
                itemInfor = tempArray[0].AsObject;
            
            };

            StartCoroutine(Main.Instance.getitem.GetIte_m(itemId,getItemInfomcallback));
            //wait until the callback is called from get item (infor finished downloading)
            yield return new WaitUntil(() => isDone == true);


            //Instantiate GameObject (itemslot prefabs)
            //Resources.Load("enemy", typeof(GameObject))) as GameObject;
            GameObject item = Instantiate(itemli);
            item.transform.SetParent(this.transform);
            //item.transform.localScale = Vector3.zero;
            //item.transform.localPosition = Vector3.zero;

            //fill information
            item.transform.Find("name").GetComponent<Text>().text = itemInfor["name"];
            item.transform.Find("price").GetComponent<Text>().text = itemInfor["price"];
            item.transform.Find("description").GetComponent<Text>().text = itemInfor["description"];
            item.transform.Find("SellButton").GetComponent<Button>().onClick.AddListener(() => {

                string i_id = itemId;
                string u_id = Main.Instance.userInfo.userID;

                StartCoroutine(Main.Instance.getitem.sellite_m(i_id,u_id));
            
            });            //continue to the next item
        }

  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
