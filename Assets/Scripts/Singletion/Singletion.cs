using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletion<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
           
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}