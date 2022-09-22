using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _xMaxSpeed;
    private Rigidbody2D _rb;
    private Vector2 _screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(Random.Range(-_xMaxSpeed, 0), Random.Range(-1f, 1f));
        
    }
    

    // Update is called once per frame
    void Update()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if (transform.position.x < _screenBounds.x)
        {
            Destroy(this.gameObject);
        }
    }
    public void SetSpeedX(float speed)
    {
        _rb.velocity = new Vector2(speed, 0);
    }
}
