using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostCapsuleSpawn : MonoBehaviour
{
    [SerializeField] private GameObject capsuleBoost;
    [SerializeField] private float _respawnTime = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(asteroidWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(capsuleBoost);
        a.transform.position = new Vector2(60, Random.Range(-40, +40));
    }

    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(_respawnTime*(2-DataHolder.Dificulty));
            spawnEnemy();
        }
    }
}
