using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using EasyUI.Popup;

public class slide_updown_anim : MonoBehaviour
{
    public GameObject PanelMenu;

    public TextMeshProUGUI vehicle_type;
    public TextMeshProUGUI wagon_type;
    public TextMeshProUGUI series;
    public TextMeshProUGUI last_event;
    public TextMeshProUGUI status;
    public TextMeshProUGUI yard_sector;
    public TextMeshProUGUI line;
    public TextMeshProUGUI vehicle_number;
    //public TextMeshProUGUI number_of_wagons;
    Action<String> _train_leaves;

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

    public void set_train_info(string vehicle_type_, string wagon_type_, string series_, string last_event_, string status_, string yard_sector_,
        string line_, string vehicle_number_)
    {
        vehicle_type.text = vehicle_type_;
        wagon_type.text = wagon_type_;
        series.text = series_;
        last_event.text = last_event_;
        status.text = status_;
        yard_sector.text = yard_sector_;
        line.text = line_;
        vehicle_number.text = vehicle_number_;
        
    }
/*
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
*/
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

    public void openMenu()
    {
        if (PanelMenu != null)
        {
            Animator animator = PanelMenu.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show", isOpen);
            }
        }
    }

    public void train_leaves() 
    {



        _train_leaves = (all_live_data) => {

            StartCoroutine(Make_train_leave(all_live_data));

        };

        StartCoroutine(Command.Instance.web_.Train_leaves_platform(vehicle_number.text, _train_leaves));

    }


    public IEnumerator Make_train_leave(string jsonArraystring_)
    {
       
        Debug.Log(jsonArraystring_);
        Popup.Show("Success", "ship removed successfully.", "OK", PopupColor.Green);
      


        yield return null;
    }


}
