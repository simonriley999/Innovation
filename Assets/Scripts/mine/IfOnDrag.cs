using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IfOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private Transform originalParent;
    RectTransform currentRect;
    void Awake()
    {
        currentRect = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.parent.parent);
        //transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = eventData.position;
        currentRect.anchoredPosition += eventData.delta;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.tag);
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject==null)
        {
            Destroy(gameObject);
        }
        if (eventData.pointerCurrentRaycast.gameObject.name=="RunPanel")
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
        }
        else if (eventData.pointerCurrentRaycast.gameObject.tag=="Keywords")
        {
            GameObject temp = eventData.pointerCurrentRaycast.gameObject;
            Transform tp = eventData.pointerCurrentRaycast.gameObject.transform.parent;
            int index = -1;
            if (temp.name.IndexOf("runIf") >= 0)
            {
                transform.SetParent(tp);
                index = temp.transform.GetSiblingIndex();
            }
            else if (temp.transform.parent.parent.name.IndexOf("runIf")>=0)
            {
                transform.SetParent(tp.parent.parent);
                index = tp.parent.GetSiblingIndex();
            }
            else
            {
                transform.SetParent(tp.parent);
                index = temp.transform.parent.GetSiblingIndex();
            }
            transform.SetSiblingIndex(index);
        }
        else
        {
            Destroy(gameObject);
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
