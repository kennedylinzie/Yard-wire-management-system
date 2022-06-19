using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EasyUI.Popup;

public class searchWagon : MonoBehaviour
{
    public TMP_InputField search_input;
    public GameObject prefab_holder;

    public void Search_wagon() 
    {
        //Command.Instance.get_references();
        //Command.Instance.dd_.the_wagon_search_man();

        if (search_input.text.Equals("")) 
        {
            Popup.Show("Error", "The wagon number is empty", "OK", PopupColor.Red);
            return;
        }
        search_thingy(search_input.text);
    }

    public void search_thingy(string number)
    {
        foreach (Transform child in prefab_holder.transform)
        {
            child.gameObject.GetComponent<DragDrop>().the_wagon_search_man(number);
          
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
