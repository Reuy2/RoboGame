using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleBoost : MonoBehaviour
{
    float xSpeed;
    float ySpeed;

    private Vector2 _screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        xSpeed = Random.Range(-10, -4);
        ySpeed = Random.Range(-5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        Speed();

        ScreenBoundDestroy();
    }

    void Speed()
    {
        transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.up * -BG_Scroller.y * 500 * Time.deltaTime * Mathf.Sqrt(MoveControl.Boost));
    }

    void ScreenBoundDestroy()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if (transform.position.x < _screenBounds.x)
        {
            Destroy(this.gameObject);
        }
    }
}
