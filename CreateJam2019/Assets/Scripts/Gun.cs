using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    private bool _flipped;

    private Transform _throwDirection;
    private Transform _nozzle;
    private Transform _casingExit;

    [SerializeField] private float _throwForce = 800f;
    [SerializeField] private float _bulletForce = 100f;
    [SerializeField] private float _casingForce = 10f;
    [SerializeField] private float _kickbackTorque = 100f;

    [SerializeField] private GameObject Bullet;

    [SerializeField] public int Ammo;


    void Start()
    {
        _nozzle = transform.Find("Nozzle");
        _throwDirection = transform.Find("ThrowDirection");
        _casingExit = transform.Find("CasingExit");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Throw();

        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    public void Throw()
    {
        _rigidBody = gameObject.AddComponent<Rigidbody2D>();

        Debug.Log(_throwDirection.right);
        _rigidBody.AddForce(_throwDirection.right * _throwForce);
        _rigidBody.AddTorque(-_kickbackTorque);
    }

    public void Shoot()
    {
        if (Ammo == 0)
            return;
        Ammo--;

        Debug.Log("Shoot");
        var newBullet = Instantiate(Bullet, _nozzle.position, _nozzle.rotation);

        var nbrb = newBullet.GetComponent<Rigidbody2D>();
        nbrb.velocity = _rigidBody.velocity;
        nbrb.AddForce(_nozzle.transform.right * _bulletForce);
    }
}
