using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAppear : MonoBehaviour
{
    float _timeElapsed = 0;
    bool appearing = false;
    bool disappearing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.gameObject == null)
            return;
        
        if (transform.position.x < -70f)
        {
            Destroy(transform.parent.gameObject);
        }
        transform.parent.Translate(Vector3.left * MoveControl.Boost * Time.deltaTime * 10);
        transform.parent.Translate(Vector3.up * -BG_Scroller.y * 500 * Time.deltaTime * Mathf.Sqrt(MoveControl.Boost) / 2);
    }

    private void FixedUpdate()
    {
        if (appearing)
            Appear(GetComponent<TextMesh>());
        if (disappearing)
            Disapppear(GetComponent<TextMesh>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ObjectCheck"))
        {
            Appear(gameObject.GetComponent<TextMesh>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ObjectCheck"))
        {
            appearing = false;
            disappearing = true;
            _timeElapsed = 0;
            Disapppear(gameObject.GetComponent<TextMesh>());
        }
    }
    void Appear(TextMesh _text)
    {
        appearing = true;
        Color transp = _text.color;
        if (_timeElapsed < 3f && appearing)
        {
            transp.a = Mathf.Lerp(0, 1, _timeElapsed);
            _text.color = transp;
            _timeElapsed += Time.deltaTime;
            return;
        }
        appearing = false;
    }

    void Disapppear(TextMesh _text)
    {
        disappearing = true;
        Color transp = _text.color;
        if (_timeElapsed<3f && disappearing)
        {
            transp.a = Mathf.Lerp(1, 0, _timeElapsed);
            _text.color = transp;
            _timeElapsed += Time.deltaTime;
            return;
        }
        disappearing = false;
        _timeElapsed = 0;
    }
}
