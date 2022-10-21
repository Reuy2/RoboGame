using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _xMaxSpeed;
    private Rigidbody2D _rb;
    private Vector2 _screenBounds;
    //float speedUp = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(Random.Range(-_xMaxSpeed, -3), Random.Range(-0.5f, 0.5f));
        
    }
    

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * MoveControl.Boost * Time.deltaTime);

        transform.Translate(Vector3.up * -BG_Scroller.y * 500 * Time.deltaTime * Mathf.Sqrt(MoveControl.Boost));

        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if (transform.position.x < _screenBounds.x)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Asteroid"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("Boost"))
        {
            Destroy(collision.gameObject);
        }
    }
    public void SetSpeedX(float speed)
    {
        _rb.velocity = new Vector2(speed, 0);
    }
}
