using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

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
    [SerializeField] private float _kickbackForce = 100f;
    [SerializeField] private float _minAngularVelocity = 10f;

    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Casing;

    [SerializeField] public int Ammo;


    void Start()
    {
        _nozzle = transform.Find("Nozzle");
        _throwDirection = transform.Find("ThrowDirection");
        _casingExit = transform.Find("CasingExit");

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();

        if (_rigidBody)
        {
            Debug.Log(_rigidBody.angularVelocity);
            if (_rigidBody.angularVelocity > _minAngularVelocity)
            {
                _rigidBody.angularDrag = 0.3f;
            }
            else
            {
                _rigidBody.angularDrag = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0.1f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
            Time.timeScale = 1f;
    }

    public void Throw()
    {
        transform.parent = null;
        _rigidBody = gameObject.AddComponent<Rigidbody2D>();
        _rigidBody.interpolation = RigidbodyInterpolation2D.Interpolate;

        Debug.Log(_throwDirection.right);
        _rigidBody.AddForce(_throwDirection.right * _throwForce);
        _rigidBody.AddTorque(_kickbackTorque);
    }

    public void Shoot()
    {
        if (Ammo == 0)
            return;
        Ammo--;

        Debug.Log("Shoot");

        // Add force to gun
        _rigidBody.AddForce(-_nozzle.right * _kickbackForce);
        _rigidBody.AddTorque(_kickbackTorque);

        // Bullet
        var newBullet = Instantiate(Bullet, _nozzle.position, _nozzle.rotation);
        var nbrb = newBullet.GetComponent<Rigidbody2D>();
        if (_rigidBody)
            nbrb.velocity = _rigidBody.velocity;
        nbrb.AddForce(_nozzle.transform.right * _bulletForce);


        //Casing
        var newCasing = Instantiate(Casing, _casingExit.position, _casingExit.rotation);
        var ncrb = newCasing.GetComponent<Rigidbody2D>();
        ncrb.AddForce(_casingExit.right * _casingForce);
    }
}
