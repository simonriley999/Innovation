using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class create : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerClickHandler
{
    RectTransform curRect;
    private Transform originalParent;
    // Start is called before the first frame update
    void Start()
    {
        curRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        //curRect.anchoredPosition += eventData.delta;
        //GetComponent<CanvasGroup>().blocksRaycasts = false;
        //return;
        //throw new System.NotImplementedException();
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        
        //return;
        //throw new System.NotImplementedException();
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("QAQ");
        GameObject runif = (GameObject)Resources.Load("Prefabs 1/runIf");
        Instantiate(runif, transform.position, transform.rotation, transform.parent.parent);
        EventSystem.current.SetSelectedGameObject(runif);
        runif.SendMessage("IDragHandler.OnDrag", eventData);
        Debug.Log("TAT");
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("QAQ");
        //GameObject runif = (GameObject)Resources.Load("Prefabs 1/runIf");
        //Instantiate(runif, transform.position,transform.rotation,transform.parent.parent);
        //EventSystem.current.SetSelectedGameObject(runif);
        //runif.SendMessage("IBeginDragHandler.OnBeginDrag",eventData);
        //Debug.Log("TAT");
    }
}
