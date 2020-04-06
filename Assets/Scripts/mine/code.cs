using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code 
{
    public string functionType;
    public List<List<int>> direction = new List<List<int>>();//direction中为↖，↑，↗，←，当前，→，↙，↓，↘
    public int equivalent;//0为≠，1为==//，2为>，3为>=，4为<，5为<=；
    public string condition;
    public bool isMore;//是否有额外条件
    public int movementDir;//用于从direction中提取方向
    public int thisPos, tarPos;
    
    public code()
    {
        for (int i=-1;i<2;i++)
        {
            for (int j=-1;j<2;j++)
            {
                List<int> temp = new List<int>() { i, j };
                direction.Add(temp);
            }
        }

    }
}
