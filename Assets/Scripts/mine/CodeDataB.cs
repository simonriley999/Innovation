using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeDataB : MonoBehaviour
{
    public List<code> dataBase;
    public Dictionary<GameObject,Vector3> cube;
    public GameObject hero, runPanel;
    public float step;
    private bool isMoving;
    private void Awake()
    {
        dataBase = new List<code>();
        cube = new Dictionary<GameObject, Vector3>();
    }

    private void Start()
    {
        runPanel = GameObject.Find("RunPanel");
    }
    public void run()
    {
        infor temp;
        code item;
        int knum = runPanel.GetComponent<keynum>().ifGroNum;
        for (int i=0;i<runPanel.transform.childCount;i++)
        {
            temp = runPanel.transform.GetChild(i).GetComponent<infor>();
            item = temp.data;
            switch (item.functionType)
            {
                case "if":
                    item.movementDir = temp.dir.value;
                    item.equivalent = temp.equ.value;
                    item.condition = temp.con.captionText.text;
                    item.thisPos = i;
                    break;
                default:
                    break;
            }
            dataBase.Add(item);
        }

        for (int i=0;i<dataBase.Count;i++)
        {
            switch (dataBase[i].functionType)
            {
                case "if":
                    //GameObject temp = new GameObject();
                    if (dataBase[i].condition=="cube")
                    {

                    }
                    break;
                default:
                    break;
            }
        }
    }
}
