using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IfOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private Transform originalParent;
    RectTransform currentRect;
    GameObject runPanel;
    GameObject empty;
    void Awake()
    {
        currentRect = GetComponent<RectTransform>();
        runPanel = GameObject.Find("RunPanel");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.parent.parent.parent);
        //transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        CanvasGroup cg;
        for (int i = 0; i <runPanel.transform.childCount; i++)
        {
            for (int j = 0; j < runPanel.transform.GetChild(i).childCount; j++)
            {
                cg = runPanel.transform.GetChild(i).GetChild(j).GetComponent<CanvasGroup>();
                cg.blocksRaycasts = false;
                cg.ignoreParentGroups = true;
            }
        }
        empty = (GameObject)Resources.Load("Prefabs 1/empty");
        empty=Instantiate(empty, runPanel.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = eventData.position;
        currentRect.anchoredPosition += eventData.delta;
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            Debug.Log(eventData.pointerCurrentRaycast.gameObject.tag);
            Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
        }
        if (eventData.pointerCurrentRaycast.gameObject.tag=="if")
        {
            GameObject temp = eventData.pointerCurrentRaycast.gameObject;
            empty.transform.SetSiblingIndex(temp.transform.GetSiblingIndex());
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name==runPanel.name||eventData.pointerCurrentRaycast.gameObject.name=="mask")
        {
            if (currentRect.anchoredPosition.y<=runPanel.transform.GetChild(runPanel.transform.childCount-1).GetComponent<RectTransform>().anchoredPosition.y)
            {
                empty.transform.SetSiblingIndex(runPanel.transform.childCount - 1);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject==null)
        {
            Destroy(gameObject);
            Destroy(empty);
            return;
        }
        if (eventData.pointerCurrentRaycast.gameObject.name=="RunPanel"|| eventData.pointerCurrentRaycast.gameObject.name == "mask")
        {
            //transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            transform.SetParent(originalParent);
            transform.SetSiblingIndex(empty.transform.GetSiblingIndex());
        }
        else if (eventData.pointerCurrentRaycast.gameObject.tag=="if"|| eventData.pointerCurrentRaycast.gameObject.tag=="empty")
        {
            //GameObject temp = eventData.pointerCurrentRaycast.gameObject;
            //Transform tp = eventData.pointerCurrentRaycast.gameObject.transform.parent;
            //int index = -1;
            ////if (temp.name.IndexOf("runIf") >= 0)
            ////{
            ////    transform.SetParent(tp);
            ////    index = temp.transform.GetSiblingIndex();
            ////}
            ////else if (temp.transform.parent.parent.name.IndexOf("runIf")>=0)
            ////{
            ////    transform.SetParent(tp.parent.parent);
            ////    index = tp.parent.GetSiblingIndex();
            ////}
            ////else
            ////{
            ////    transform.SetParent(tp.parent);
            ////    index = temp.transform.parent.GetSiblingIndex();
            ////}
            //transform.SetParent(tp);
            //index = temp.transform.GetSiblingIndex();
            //transform.SetSiblingIndex(index);
            transform.SetParent(originalParent);
            transform.SetSiblingIndex(empty.transform.GetSiblingIndex());
        }
        else
        {
            Destroy(gameObject);
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        CanvasGroup cg;
        for (int i = 0; i < runPanel.transform.childCount; i++)
        {
            for (int j = 0; j < runPanel.transform.GetChild(i).childCount; j++)
            {
                cg = runPanel.transform.GetChild(i).GetChild(j).GetComponent<CanvasGroup>();
                cg.blocksRaycasts = true;
                cg.ignoreParentGroups = false;
            }
        }
        Destroy(empty);
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
