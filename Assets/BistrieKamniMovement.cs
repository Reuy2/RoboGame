using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BistrieKamniMovement : MonoBehaviour
{
    [SerializeField] private float _xMaxSpeed;
    private Rigidbody2D _rb;
    private Vector2 _screenBounds;
    //float speedUp = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * MoveControl.Boost * Time.deltaTime * _xMaxSpeed);

        transform.Translate(Vector3.up * -BG_Scroller.y * 500 * Time.deltaTime * Mathf.Sqrt(MoveControl.Boost));

        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if (transform.position.x < _screenBounds.x-20)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("Boost"))
        {
            Destroy(collision.gameObject);
        }
    }
}
