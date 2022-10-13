using System.Collections;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    //[SerializeField] public Camera CurrentCamera = Camera.main;
    [SerializeField] private GameObject _asteroid;
    [SerializeField] private float _respawnTime = 0.7f;
    private Vector2 _screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(asteroidWave());
    }

    void Update()
    {
        //_screenBounds = CurrentCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, CurrentCamera.transform.position.z));
    }
    private void spawnEnemy()
    {
        
        GameObject a = Instantiate(_asteroid) as GameObject;
        a.transform.position = new Vector2(75, Random.Range(-40, +40));
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
