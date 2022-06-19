using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class rail_slot : MonoBehaviour, IDropHandler
{
     [SerializeField] private Canvas canvas;
    private Image danger_color;
    private int counter;
    public Vector2 point_drag_po;
    public Vector2 anchor_pos;
    public Color32 first_color;
    public Color32 second_color;
    public Color32 normal_color;



    private void Start()
    {
         canvas = GetComponentInParent<Canvas>();
        //rectTransform.anchoredPosition = new Vector2(-50f,-101f);
        danger_color = GetComponent<Image>();

    }

 

    
      
    


    public void OnDrop(PointerEventData eventData)
    {


        Debug.Log("i droped");
        if (eventData.pointerDrag != null)
        {
            Debug.Log(".//////////////..........................//////////////////////////....................");

            InvokeRepeating("start_color_lerp", 0f, 0.5f);


            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().eulerAngles = GetComponent<RectTransform>().eulerAngles;

            point_drag_po = eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;
            anchor_pos = GetComponent<RectTransform>().anchoredPosition;
        }
        else {
            point_drag_po = new Vector2(0,0);
            anchor_pos = new Vector2(0,0);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        if (eventData.pointerDrag)
        {
          
            danger_color.color = Color.yellow;
        }
     
    }



    void start_color_lerp()
    {
        danger_color.color = Color.Lerp(first_color, second_color, Mathf.PingPong(Time.time, 1));
        if (counter > 10) 
        {
            counter = 0;
            Stop_lerp_coroutine();
        }
        counter++;
    }
    public void Stop_lerp_coroutine()
    {
        //StopCoroutine("Set_the_time_and_date");
        CancelInvoke("start_color_lerp");
        danger_color.color = normal_color;
    }
   

}
