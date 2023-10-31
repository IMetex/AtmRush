using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerManager : Singletion<PlayerManager>
{
    public List<GameObject> collected = new List<GameObject>();

    [Header("Movement && Speeds")] [Space(10)]
    public float movementTailDelay = .25f;
    public float movementOriginDelay;
    
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            MoveElements();
        }
        else
        {
            MoveOrigin();
        }
    }

    public void MoveElements()
    {
        for (int i = 1; i < collected.Count; i++)
        {
            Vector3 pos = collected[i].transform.position;
            pos.x = collected[i - 1].transform.position.x;
            collected[i].transform.position =
                Vector3.Lerp(collected[i].transform.position, pos, movementTailDelay * Time.deltaTime);
        }
    }

    public void MoveOrigin()
    {
        for (int i = 1; i < collected.Count; i++)
        {
            Vector3 pos = collected[i].transform.position;
            pos.x = collected[0].transform.position.x;
            collected[i].transform.position = Vector3.Lerp(collected[i].transform.position, pos,
                movementOriginDelay * Time.deltaTime);
        }
    }
}