using System.Collections;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    //[SerializeField] public Camera CurrentCamera = Camera.main;
    [SerializeField] private GameObject _asteroidBlue;
    [SerializeField] private GameObject _asteroidBig;
    [SerializeField] private GameObject _asteroidLong;
    [SerializeField] private GameObject _asteroidCommon;
    GameObject[] _asteroid;
    [SerializeField] private float _respawnTime = 0.7f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(asteroidWave());
        _asteroid = new GameObject[] { _asteroidBlue, _asteroidBig, _asteroidLong, _asteroidCommon };
    }

    void Update()
    {
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(_asteroid[Random.Range(0,_asteroid.Length)]);
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
