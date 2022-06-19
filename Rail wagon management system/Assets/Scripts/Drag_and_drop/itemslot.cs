using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class itemslot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Canvas canvas;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        //rectTransform.anchoredPosition = new Vector2(-50f,-101f);
      

    }

    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            Debug.Log(".//////////////..........................//////////////////////////....................");
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition  = GetComponent<RectTransform>().anchoredPosition; 
            eventData.pointerDrag.GetComponent<RectTransform>().eulerAngles = GetComponent<RectTransform>().eulerAngles;

            Vector2 posA = eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;
            Vector2 posB = GetComponent<RectTransform>().anchoredPosition;

            if (posA.Equals(posA))
            {
                eventData.pointerDrag.GetComponent<DragDrop>().set_modify_line(this.gameObject.tag, GetComponent<RectTransform>().anchoredPosition);
            }

            
        }
    }

}
