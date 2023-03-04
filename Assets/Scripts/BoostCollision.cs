using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostCollision : MonoBehaviour
{

    public CooldownBoostTimer BoostTimer;
    [SerializeField] public ScoreCount Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Boost"))
        {
            BoostTimer.SetScale(20);
            Score.StartScore += 20;
            Destroy(collision.gameObject);
        }
    }
}
