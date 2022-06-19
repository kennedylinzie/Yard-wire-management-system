using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMenuAnim : MonoBehaviour
{
    public GameObject PanelMenu;
    public Text Current_user;

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
        Command.Instance.pull_DATA();
        Current_user.text = "Hi' "+Command.Instance.user_name__;
        if (PanelMenu != null)
        {
            Animator animator = PanelMenu.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show", !isOpen);
            }
        }
       
    }


    

}
