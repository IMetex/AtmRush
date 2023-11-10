using System;
using System.Collections;
using System.Collections.Generic;
using Stack;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        [Header("Movement Speed Values")]
        [SerializeField] private float forwardSpeed;
        [SerializeField] private float horizontalSpeed;
        
        [Header("Player Clamp X Position")]
        [SerializeField] private float clampX;

        private float _horizontalInput;
        private GameObject _firstObject;

        void FixedUpdate()
        {
            transform.position += Vector3.forward * (forwardSpeed * Time.deltaTime);

            _firstObject = StackLerpMovement.Instance.collected[0];
            _horizontalInput = Input.GetAxisRaw("Horizontal");

            if (_horizontalInput != 0)
            {
                Vector3 targetPosition = _firstObject.transform.position +
                                         new Vector3(_horizontalInput * horizontalSpeed, 0f, 0f);

                targetPosition.x = Mathf.Clamp(targetPosition.x, -clampX, clampX);

                _firstObject.transform.position = Vector3.Lerp(
                    _firstObject.transform.position, targetPosition, Time.deltaTime * forwardSpeed);
            }
        }
    }
}