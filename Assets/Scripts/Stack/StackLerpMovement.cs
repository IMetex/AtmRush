using System.Collections.Generic;
using Singleton;
using UnityEngine;

namespace Stack
{
    public class StackLerpMovement : Singleton<StackLerpMovement>
    {
        public List<GameObject> collected = new List<GameObject>();

        [Header("Stack Movement Values")] 
        [SerializeField] private float movementTailDelay;
        [SerializeField] private float movementOriginDelay;

        private void Update()
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                MoveElements();
            }
            else
            {
                MoveOrigins();
            }
        }

        private void MoveElements()
        {
            for (int i = 1; i < collected.Count; i++)
            {
                var collectPos = collected[i].transform.position;
                
                collectPos.x = collected[i - 1].transform.position.x;

                collected[i].transform.position = Vector3.Lerp(collected[i].transform.position, collectPos,
                    movementTailDelay * Time.deltaTime);
            }
        }

        private void MoveOrigins()
        {
            for (int i = 1; i < collected.Count; i++)
            {
                var collectPos = collected[i].transform.position;

                collectPos.x = collected[0].transform.position.x;

                collected[i].transform.position = Vector3.Lerp(collected[i].transform.position, collectPos,
                    movementOriginDelay * Time.deltaTime);
            }
        }
    }
}