using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class create : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    RectTransform curRect;
    private Transform originalParent;
    GameObject runPanel, empty;
    // Start is called before the first frame update
    void Start()
    {
        curRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        originalParent = GameObject.Find("SelectPanel").GetComponent<Transform>();
        runPanel = GameObject.Find("RunPanel");
    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        curRect.anchoredPosition += eventData.delta;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            Debug.Log(eventData.pointerCurrentRaycast.gameObject.tag);
            Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
        }
        if (eventData.pointerCurrentRaycast.gameObject.tag == "if")
        {
            GameObject temp = eventData.pointerCurrentRaycast.gameObject;
            empty.transform.SetSiblingIndex(temp.transform.GetSiblingIndex());
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == runPanel.name || eventData.pointerCurrentRaycast.gameObject.name == "mask"|| eventData.pointerCurrentRaycast.gameObject.tag=="empty")
        {
            if (curRect.anchoredPosition.y <= runPanel.transform.GetChild(runPanel.transform.childCount - 1).GetComponent<RectTransform>().anchoredPosition.y)
            {
                empty.transform.SetSiblingIndex(runPanel.transform.childCount - 1);
            }
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Destroy(gameObject);
        if (eventData.pointerCurrentRaycast.gameObject==null)
        {
            Destroy(empty);
            return;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "RunPanel" || eventData.pointerCurrentRaycast.gameObject.name == "mask" || eventData.pointerCurrentRaycast.gameObject.tag == "empty")
        {
            GameObject temp = (GameObject)Resources.Load("Prefabs 1/runIf");
            temp = Instantiate(temp, runPanel.transform);
            temp.transform.SetSiblingIndex(empty.transform.GetSiblingIndex());
            temp = (GameObject)Resources.Load("Prefabs 1/endif");
            temp = Instantiate(temp, runPanel.transform);
            temp.transform.SetSiblingIndex(empty.transform.GetSiblingIndex());
            Destroy(empty);
        }
        Destroy(empty);
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
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("QAQ");
        int index = transform.GetSiblingIndex();
        transform.SetParent(originalParent.parent);
        GameObject selectif = (GameObject)Resources.Load("Prefabs 1/selectIf");
        selectif=Instantiate(selectif, originalParent);
        selectif.transform.SetSiblingIndex(index);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        CanvasGroup cg;
        for (int i = 0; i < runPanel.transform.childCount; i++)
        {
            for (int j = 0; j < runPanel.transform.GetChild(i).childCount; j++)
            {
                cg = runPanel.transform.GetChild(i).GetChild(j).GetComponent<CanvasGroup>();
                cg.blocksRaycasts = false;
                cg.ignoreParentGroups = true;
            }
        }
        empty = (GameObject)Resources.Load("Prefabs 1/empty");
        empty = Instantiate(empty, runPanel.transform);
        //Debug.Log("TAT");
    }

}
