using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_train : MonoBehaviour
{
    public GameObject enable_menu;
    // Start is called before the first frame update
    void Start()
    {
        //enable_menu.SetActive(false);
    }


    public void enable_window() 
    {

        enable_menu.SetActive(true);
     

    }
    public void close_window()
    {
        
        enable_menu.SetActive(false);

    }


}
