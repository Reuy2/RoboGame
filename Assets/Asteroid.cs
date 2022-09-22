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
        _rb.velocity = new Vector2(Random.Range(-_xMaxSpeed, 0), Random.Range(-1f, 1f));
        
    }
    

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.right * 3 * Time.deltaTime);
        transform.Translate(Vector3.up * -Input.GetAxis("Vertical") * 3 * Time.deltaTime);
        BG_Scroller.y = Input.GetAxis("Vertical")/100;

        /*if (Input.GetKey(KeyCode.W) && speedUp > -3)
        {
            speedUp -= 0.5f;
        }
        else if (Input.GetKey(KeyCode.S) && speedUp < 3)
        {
            speedUp += 0.5f;
        }
        else if (speedUp > 0)
        {
            speedUp -= 1;

        }
        else if (speedUp < 0)
        {
            speedUp += 1;

        }*/

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
