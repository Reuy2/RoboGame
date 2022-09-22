using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollide : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit detected");
        Destroy(collision.gameObject);
    }
}
