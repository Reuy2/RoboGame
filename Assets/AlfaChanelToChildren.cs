using UnityEngine;

public class AlfaChanelToChildren : MonoBehaviour
{
    private SpriteRenderer _shipRenderer;
    [SerializeField]  private GameObject _ship;

    void Update()
    {
        SpriteRenderer[] childList = _ship.GetComponentsInChildren<SpriteRenderer>();
        _shipRenderer = _ship.GetComponent<SpriteRenderer>();
        foreach (SpriteRenderer i in childList)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, _shipRenderer.color.a);
        }
    }
}
