using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    ObjectsInSpace ObjectInSpace;
    GameObject Prefab;
    // Start is called before the first frame update
    void Start()
    {
        ObjectInSpace = GameObject.Find("Ship").GetComponent<ObjectsInSpace>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag.Equals("Ship"))
        {
           ObjectInSpace.Appear(Prefab);
        }
    }
}
