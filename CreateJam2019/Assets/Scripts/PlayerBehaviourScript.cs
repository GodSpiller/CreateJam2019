using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;

    private Gun _pickedUpGun;

    private Transform _gunPosition;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        _gunPosition = transform.Find("GunPosition");
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        if (!Input.GetKey(KeyCode.RightArrow) || !Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.velocity = Vector2.zero;
        }

        rb2d.velocity = movement * speed;


        if (Input.GetMouseButtonDown(1) && _pickedUpGun)
        {
            Debug.Log("Throw");
            _pickedUpGun.Throw();
            UnityEngine.Camera.main.gameObject.GetComponent<Camera>().Target = _pickedUpGun.transform;

            _pickedUpGun = null;
        }
    }

    void PickUpGun(GameObject gunObj, Gun gun)
    {
        _pickedUpGun = gun;
        gunObj.transform.parent = _gunPosition;
        gunObj.transform.localPosition = Vector3.zero;
        gunObj.transform.localRotation = Quaternion.identity;
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        Gun gun;
        if (col.gameObject.TryGetComponent<Gun>(out gun) && _pickedUpGun == null)
        {
            PickUpGun(col.gameObject, gun);
        }
    }
}
