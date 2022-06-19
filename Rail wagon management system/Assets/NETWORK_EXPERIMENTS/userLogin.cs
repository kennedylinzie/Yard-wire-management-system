using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userLogin : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public Button LoginButton;
    public GameObject reg_form;

    // Start is called before the first frame update
    void Start()
    {
        

        LoginButton.onClick.AddListener(()=> {

            StartCoroutine(Main.Instance.login.Logi_n(UsernameInput.text, PasswordInput.text));
        
        });
    }
    public void reveal_reg()
    {
        reg_form.SetActive(true);
        this.gameObject.SetActive(false); 
    }

 
}
