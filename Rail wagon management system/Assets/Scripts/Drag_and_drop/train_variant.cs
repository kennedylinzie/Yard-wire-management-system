using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class train_variant : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler,IDropHandler,IPointerClickHandler
{
    private const double x_left_limit = -940.189;
    private const double x_right_limit = 938.2852;
    private const double y_bottom_limit = -456.624;
    private const double y_top_limit = 480.476;
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;

    private CanvasGroup canvasGroup;
    private Image danger_color;
    public GameObject double_click_menu;

   // public  Text train_name;
    private Vector2 temp_pos;

   // public Text wag_amount;






    private void Awake()
    {

       
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        danger_color = GetComponent<Image>();
      
        // train_name = GameObject.Find("title") as Text;



        //rectTransform.anchoredPosition = new Vector2(209,40);
    }

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        //rectTransform.anchoredPosition = new Vector2(-50f,-101f);
        double_click_menu = GameObject.FindGameObjectWithTag("train_spec_panel");
       // train_name = GameObject.Find("title").GetComponent<Text>();
       // train_name.text = (this.gameObject.name+"");
        double_click_menu.SetActive(false);
       // set_wag("100");
    }

  

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBegindrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        temp_pos = rectTransform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("i drag");
        //rectTransform.anchoredPosition += eventData.delta;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        if (rectTransform.anchoredPosition.x < x_left_limit)
        {
            Debug.Log("--------------------------------");
            danger_color.color = Color.red;


        }
       else if (rectTransform.anchoredPosition.x > x_right_limit)
        {
            Debug.Log("+++++++++++++++++++++++++++++++++");
            danger_color.color = Color.red;
        }
       else if (rectTransform.anchoredPosition.y < y_bottom_limit)
        {
            Debug.Log("--------------------------------");
            danger_color.color = Color.red;
        }
       else if (rectTransform.anchoredPosition.y > y_top_limit)
        {
            Debug.Log("+++++++++++++++++++++++++++++++++");
            danger_color.color = Color.red;
        }
        else
        {
            danger_color.color = Color.white;
        }

        // rectTransform.anchoredPosition += eventData.delta;
    }

   

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEnddrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (rectTransform.anchoredPosition.x < x_left_limit)
        {
            Debug.Log("--------------------------------");
            rectTransform.position = temp_pos;
        }
        else if (rectTransform.anchoredPosition.x > x_right_limit)
        {
            Debug.Log("+++++++++++++++++++++++++++++++++");
            rectTransform.position = temp_pos;
        }
       else if (rectTransform.anchoredPosition.y < y_bottom_limit)
        {
            Debug.Log("--------------------------------");
            rectTransform.position = temp_pos;
        }
       else if (rectTransform.anchoredPosition.y > y_top_limit)
        {
            Debug.Log("+++++++++++++++++++++++++++++++++");
            rectTransform.position = temp_pos;
        }
     
            danger_color.color = Color.white;
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("I DROPPED IT");
    }

    float lastClick = 0f;
    float interval = 0.4f;
   
    public void OnPointerClick(PointerEventData eventData)
    {
        if ((lastClick + interval) > Time.time)
        {
            Debug.Log("DOUBLE CLICKED");
            if (double_click_menu.active) 
            {
                double_click_menu.SetActive(false);
            }
            else if(double_click_menu.active.Equals(false))
            {
                double_click_menu.SetActive(true);
            }
        }
        else {
            Debug.Log("SINGLE CLICKED");
        }
        lastClick = Time.time;
       
       
    }
}
