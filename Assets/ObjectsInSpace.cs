using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInSpace : MonoBehaviour
{
    [SerializeField] List<GameObject> ObjectPrefab;
    GameObject _gameObject;
    int i = -1;
    float _timeElapsed = 0;
    void Start()
    {
        _gameObject = ObjectPrefab[0];
        StartCoroutine(SpawnObject());
    }
    IEnumerator SpawnObject() 
    {
        while (MoveControl.ship—ontrol && i < ObjectPrefab.Count) 
        {
            i++;
            SpawnObj();
            yield return new WaitForSeconds(30f);
        }
    }
    void SpawnObj()
    {
        _gameObject = Instantiate(ObjectPrefab[i]);
        _gameObject.transform.position = new Vector2(75, Random.Range(-20, +20));
        Color _transp = _gameObject.GetComponentInChildren<TextMesh>().color;
        TextMesh _textMesh = _gameObject.GetComponentInChildren<TextMesh>();
        _transp.a = 0;
        _textMesh.color = _transp;
    }
    public void Appear(TextMesh _text)
    {
        Color transp = _text.color;
        if (_timeElapsed<3f && transp.a == 0)
        {
            transp.a = Mathf.Lerp(0, 1, _timeElapsed);
            _text.color = transp;
            _timeElapsed += Time.deltaTime;
        }
    }
}
