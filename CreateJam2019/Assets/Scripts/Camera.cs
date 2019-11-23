using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] public Transform Target;

    void Update()
    { 
        transform.position = new Vector3(Target.position.x, transform.position.y, transform.position.z);
    }

    
}
