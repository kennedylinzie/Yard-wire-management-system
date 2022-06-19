using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.Win32;

public class appBar : MonoBehaviour
{
    public Button quit;
    public Button mini;
    public Button full;

    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = !Screen.fullScreen;

        quit.onClick.AddListener(() => {

            Application.Quit();

        });

       

        full.onClick.AddListener(() => {

            Screen.fullScreen = !Screen.fullScreen;

        });


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
