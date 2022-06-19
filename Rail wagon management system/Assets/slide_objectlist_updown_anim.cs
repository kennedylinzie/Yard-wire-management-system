using EasyUI.Popup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class slide_objectlist_updown_anim : MonoBehaviour
{
    public GameObject PanelMenu;
    public GameObject itemli;
    public GameObject spawn_parent;



    private void Start()
    {
        if (PanelMenu != null)
        {
            Animator animator = PanelMenu.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show", !isOpen);
            }
        }
    }

   
        public void ShowHideMenu()
        {
            if (PanelMenu != null)
            {
                Animator animator = PanelMenu.GetComponent<Animator>();
                if (animator != null)
                {
                    bool isOpen = animator.GetBool("show");
                    animator.SetBool("show", !isOpen);
                }
            }
        }

    public void clear_field()
    {
        foreach (Transform child in spawn_parent.transform)
        {
            GameObject.Destroy(child.gameObject);
          
           // Popup.Show("Success", "Station Refreshed", "OK", PopupColor.Green);
        }
    }
   
    public void fill_the_list(string vehicle_type_, string wagon_type_, string series_, string last_event_, string status_, string yard_sector_,string line, string vehicle_number_) 
    {
        GameObject item = Instantiate(itemli);
        item.transform.SetParent(spawn_parent.transform);
        item.transform.localScale = new Vector3(0.7431903f, 0.7431903f, 0.7431903f);
        //item.transform.localPosition = Vector3.zero;

        //fill information
        item.transform.Find("number").GetComponent<Text>().text = vehicle_number_;
        item.transform.Find("wagon_type").GetComponent<Text>().text = wagon_type_;
        item.transform.Find("Series").GetComponent<Text>().text = series_;
        item.transform.Find("status").GetComponent<Text>().text = status_;

        item.GetComponent<train_instance_holder>().set_wagon(vehicle_type_,wagon_type_,series_,last_event_,status_,yard_sector_,line,vehicle_number_);
       
        item.transform.Find("Delete").GetComponent<Button>().onClick.AddListener(() => {

            
            item.GetComponent<train_instance_holder>().self_distruct(item.GetComponent<train_instance_holder>().vehicle_number);
            Command.Instance.get_references();
            Command.Instance.t_conduit.Reload_the_yard();

        });
        item.transform.Find("View").GetComponent<Button>().onClick.AddListener(() => {

            Debug.Log(" SET TO View");
            //Command.Instance.updown_anim.ShowHideMenu();
            Command.Instance.updown_anim.set_train_info(item.GetComponent<train_instance_holder>().vehicle_type
                ,item.GetComponent<train_instance_holder>().wagon_type, item.GetComponent<train_instance_holder>().series
                , item.GetComponent<train_instance_holder>().last_event, item.GetComponent<train_instance_holder>().status
                , item.GetComponent<train_instance_holder>().yard_sector, item.GetComponent<train_instance_holder>().line
                , item.GetComponent<train_instance_holder>().vehicle_number
                );

        });

    }


}
