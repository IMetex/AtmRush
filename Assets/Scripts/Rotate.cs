using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;
    void Update()
    {
        // object rotation
        transform.Rotate(rotation,Space.World);
    }
}

