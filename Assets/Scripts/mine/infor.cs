using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infor :MonoBehaviour
{
    public Dropdown dir, equ, con, der;
    public code data;
    //public int sNum;//用于辨别if-endif组
    private void Awake()
    {

        try
        {
            dir = transform.Find("condition").gameObject.GetComponent<Dropdown>();
            equ = transform.Find("equivalent").gameObject.GetComponent<Dropdown>();
            con = transform.Find("moreCondition").gameObject.GetComponent<Dropdown>();
            der = transform.Find("derivative").gameObject.GetComponent<Dropdown>();
        }
        catch (System.Exception)
        {
            dir = null;
            equ = null;
            con = null;
            der = null;
        }
        //dir = transform.Find("condition").gameObject.GetComponent<Dropdown>();
        //equ = transform.Find("equivalent").gameObject.GetComponent<Dropdown>();
        //con = transform.Find("moreCondition").gameObject.GetComponent<Dropdown>();
        //der = transform.Find("derivative").gameObject.GetComponent<Dropdown>();
    }
    private void Start()
    {

        //data.functionType = transform.tag;
        //dir = transform.Find("condition").gameObject.GetComponent<Dropdown>();
        //equ= transform.Find("equivalent").gameObject.GetComponent<Dropdown>();
        //con= transform.Find("moreCondition").gameObject.GetComponent<Dropdown>();
        //der= transform.Find("derivative").gameObject.GetComponent<Dropdown>();
        //Debug.Log(dir.captionText.text);
    }
    //void makeIfComeTrue(int d,int e,int mc)
    //{
    //    switch (d)
    //    {
    //        case 1:
    //            break;
    //    }
    //}
    private void Update()
    {
        
    }
}
