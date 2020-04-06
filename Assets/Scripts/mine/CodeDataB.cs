using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeDataB : MonoBehaviour
{
    public List<code> dataBase;
    public Dictionary<GameObject,Vector3> cube;
    public GameObject hero, runPanel, tar;
    public float step;
    private float isMoving;
    private Stack<GameObject> ifnum, jnum;
    private int nowact;//当前执行的语句序号
    private Vector2 temptar;
    private void Awake()
    {
        dataBase = new List<code>();
        cube = new Dictionary<GameObject, Vector3>();
        ifnum = new Stack<GameObject>();
        jnum = new Stack<GameObject>();
        isMoving = 0;
    }

    private void Start()
    {
        runPanel = GameObject.Find("RunPanel");
    }
    public void prepare()
    {
        nowact = 0;
        GameObject cur;
        infor temp;
        code item;
        //Stack<GameObject> knum = runPanel.GetComponent<keynum>().ifGroNum;
        for (int i=0;i<runPanel.transform.childCount;i++)
        {
            cur = runPanel.transform.GetChild(i).gameObject;
            temp = cur.GetComponent<infor>();
            item = temp.data;
            item.functionType = runPanel.transform.GetChild(i).tag;
            Debug.Log(item.functionType);
            switch (item.functionType)
            {
                case "if":
                    item.movementDir = temp.dir.value;
                    item.equivalent = temp.equ.value;
                    item.condition = temp.con.captionText.text;
                    item.thisPos = i;
                    ifnum.Push(cur);
                    break;
                case "endif":
                    try
                    {
                        GameObject t = ifnum.Pop();
                        t.GetComponent<infor>().data.tarPos = i;
                    }
                    catch
                    {

                    }
                    break;
                case "jump":
                    item.thisPos = i;
                    jnum.Push(cur);
                    break;
                case "endjump":
                    try
                    {
                        GameObject t1 = jnum.Pop();
                        t1.GetComponent<infor>().data.tarPos = i;
                    }
                    catch
                    {

                    }
                    break;
                case "pickup":
                    item.movementDir = temp.dir.value;
                    break;
                case "drop":
                    break;
                case "move":
                    item.movementDir = temp.dir.value;
                    break;
                default:
                    break;
            }
            dataBase.Add(item);
        }
    }
    private void run()
    {
        List<GameObject> around;
        while (nowact<dataBase.Count)
        {
            around = hero.GetComponent<scanAround>().item;
            switch (dataBase[nowact].functionType)
            {
                case "if":
                    for (int i = 0; i < around.Count; i++)
                    {
                        float tx = around[i].transform.position.x - hero.transform.position.x;
                        float ty = around[i].transform.position.y - hero.transform.position.y;
                        if (tx == dataBase[nowact].direction[dataBase[nowact].movementDir][0] * Mathf.Abs(tx) && ty == dataBase[nowact].direction[dataBase[nowact].movementDir][1] * Mathf.Abs(ty))//判断该物体是否在判断位置上
                        {
                            tar = around[i];
                            break;
                        }
                    }
                    if (dataBase[nowact].equivalent == 0)
                    {
                        if (tar != null && tar.tag == dataBase[nowact].condition || tar==null && dataBase[nowact].condition == "nothing")
                        {
                            nowact = dataBase[nowact].tarPos;
                        }
                        else
                        {
                            nowact++;
                        }
                    }
                    else if (dataBase[nowact].equivalent==1)
                    { 
                        if (tar != null && tar.tag == dataBase[nowact].condition || tar == null && dataBase[nowact].condition == "nothing")
                        {
                            nowact++;
                        }
                        else
                        {
                            nowact = dataBase[nowact].tarPos;
                        }
                    }
                    tar = null;
                    break;
                case "endif":
                    nowact++;
                    continue;
                case "move":
                    if (isMoving==0)
                    {
                        temptar = new Vector2(hero.transform.position.x + step * dataBase[nowact].direction[dataBase[nowact].movementDir][0], hero.transform.position.y + step * dataBase[nowact].direction[dataBase[nowact].movementDir][1]);
                        isMoving += Time.deltaTime * 3;
                        hero.transform.position = Vector2.Lerp(hero.transform.position, temptar,isMoving);
                    }
                    else if (isMoving>1.0f)
                    {
                        nowact++;
                        isMoving = 0;
                    }
                    else
                    {
                        hero.transform.position = Vector2.Lerp(hero.transform.position, temptar, isMoving);
                    }
                    break;
                case "jump":
                    nowact = dataBase[nowact].tarPos;
                    break;
                case "endjump":
                    nowact++;
                    continue;
                case "pickup":
                    //将目标设为hero的子物体
                    break;
                case "drop":
                    //接触当前携带物和hero的父子关系
                    break;
                default:
                    break;
            }
        }
    }
}
