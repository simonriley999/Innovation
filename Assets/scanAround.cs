using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scanAround : MonoBehaviour
{
    public List<GameObject> item;

    private void Awake()
    {
        item = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        item.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        serialNumber t;
        for (int i=0; i<item.Count;i++)
        {
            t = collision.GetComponent<serialNumber>();
            if (t.serialnum==item[i].GetComponent<serialNumber>().serialnum)
            {
                item.RemoveAt(i);
                break;
            }
        }
    }
}
