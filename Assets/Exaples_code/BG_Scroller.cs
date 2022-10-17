using UnityEngine;
using UnityEngine.UI;

public class BG_Scroller : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] GameObject _gameObj;
    [SerializeField] private float _x;
    public static float y;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_gameObj.tag == "MarsAndEarth")
        {
            _img.uvRect = new Rect(_img.uvRect.position + (new Vector2(_x, 0) * Mathf.Sqrt(MoveControl.Boost) * Time.deltaTime), _img.uvRect.size);
        }
        else
        {
            _img.uvRect = new Rect(_img.uvRect.position + (new Vector2(_x, y) * Mathf.Sqrt(MoveControl.Boost) * Time.deltaTime), _img.uvRect.size);
        }
    }
}
