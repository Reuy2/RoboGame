using UnityEngine;
using UnityEngine.UI;

public class BG_Scroller : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x;
    public static float y;

    // Update is called once per frame
    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, y) * Time.deltaTime, _img.uvRect.size);
    }
}
