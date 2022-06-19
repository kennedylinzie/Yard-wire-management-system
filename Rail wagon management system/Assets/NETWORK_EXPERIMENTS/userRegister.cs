using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userRegister : MonoBehaviour
{

    public InputField reg_Userid_Input;
    public InputField reg_PasswordInput;
    public Button reg_LoginButton;
    public GameObject login_form;
   

    

    // Start is called before the first frame update
    void Start()
    {
        

        reg_LoginButton.onClick.AddListener(() => {

            if (reg_Userid_Input.text.Equals("") || reg_PasswordInput.text.Equals(""))
            {
                Debug.Log("make sure all inputs are filled");
                Debug.Log("Text length  " + reg_PasswordInput.text.Length);
                return;

            }
            if (reg_PasswordInput.text.Length < 8)
            {
                Debug.Log("make sure the password has more than 8 characters");

            }

        });

    }

    public void reveal_login() {
        login_form.SetActive(true);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
