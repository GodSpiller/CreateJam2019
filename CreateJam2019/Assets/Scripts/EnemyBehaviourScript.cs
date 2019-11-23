using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    private int health;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();

        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollosionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bullet")
        {
            health -= 1;
            Debug.Log(health);
            Debug.Log("avav");
        }
    }
}
