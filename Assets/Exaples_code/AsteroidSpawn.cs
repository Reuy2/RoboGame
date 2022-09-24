using System.Collections;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    [SerializeField] private Camera _currentCamera;
    [SerializeField] private GameObject _asteroid;
    [SerializeField] private float _respawnTime = 1.0f;
    private Vector2 _screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(asteroidWave());
    }

    void Update()
    {
        _screenBounds = _currentCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _currentCamera.transform.position.z));
    }
    private void spawnEnemy()
    {
        
        GameObject a = Instantiate(_asteroid) as GameObject;
        a.transform.position = new Vector2(_screenBounds.x + 75, Random.Range(-_screenBounds.y-10, _screenBounds.y+10));
    }

    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(_respawnTime);
            spawnEnemy();
        }
    }
}
