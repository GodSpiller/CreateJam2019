using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    private bool _isAlive = true;
    public bool IsAlive
    {
        get => _isAlive;
        set
        {
            _isAlive = value;
            _enemyController.CheckWinState();
        }
    }

    private EnemyController _enemyController;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _deadSprite;
    [SerializeField] private Transform _deadPosition;

    // Start is called before the first frame update
    void Start()
    {
        _enemyController = transform.parent.GetComponent<EnemyController>();
        _spriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet") 
        {
            var brb = coll.gameObject.GetComponent<Rigidbody2D>();
            if (brb.velocity.magnitude > 20f)
            {
                IsAlive = false;
                changeSprite();
                Destroy(coll.gameObject);
            }
        }
    }

    void changeSprite()
    {
        _spriteRenderer.sprite = _deadSprite;
        transform.Find("Sprite").localPosition = _deadPosition.localPosition;
    }
}