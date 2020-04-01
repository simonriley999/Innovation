using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class If :MonoBehaviour
{
    public int line;
    private List<int> directions = new List<int>() {1,2,3,4,6,7,8,9 };//九宫格对应的数字方向
    private List<int> equivalent = new List<int>() { 1, 2, 3, 4, 5, 6 };//1为==，2为≠，3为>，4为>=，5为<，6为<=；
    private List<int> moreCondition = new List<int>() {1,2 };//1为nothing，2为数据块
    void makeIfComeTrue(int d,int e,int mc)
    {
        switch (d)
        {
            case 1:
                break;
        }
    }
    private void Update()
    {
        
    }
}
