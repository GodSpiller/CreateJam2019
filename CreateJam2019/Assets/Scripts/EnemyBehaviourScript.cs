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

        gameObject.AddComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            changeSprite();
            health -= 1;
            Debug.Log(health);
            Destroy(coll.gameObject);
        }
    }

    void changeSprite()
    {
        GameObject.Find("sprite").GetComponent<SpriteRenderer>().sprite = Resources.Load("BadGuyDead", typeof(Sprite)) as Sprite;
    }
}