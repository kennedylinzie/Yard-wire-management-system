using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userGetitemID : MonoBehaviour
{
   
    public Button load_item_button;
  

    // Start is called before the first frame update
    void Start()
    {


        load_item_button.onClick.AddListener(() => {

           // StartCoroutine(Main.Instance.getitemids.GetItem_IDS(Main.Instance.userInfo.userID));

        });
    }
   

    // Update is called once per frame
    void Update()
    {

    }
}
