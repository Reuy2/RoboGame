using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject MiniGame1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject a = Instantiate(MiniGame1);
        }
    }
}
