using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        if (!Input.GetKey(KeyCode.RightArrow) || !Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.velocity = Vector2.zero;
        }

        rb2d.velocity = movement * speed;
    }
}
