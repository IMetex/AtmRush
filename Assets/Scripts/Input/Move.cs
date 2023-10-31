using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float swipeSpeed;
    public float moveSpeed;
    public float swipeModifier;
    public float clampX;

    void FixedUpdate()
    {
        if (!GameStateScreen.Instance.IsStartded)
            return;
        
        transform.position += Vector3.forward * (moveSpeed * Time.deltaTime);
        
        GameObject firstCube = PlayerManager.Instance.collected[0];
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            Vector3 targetPosition = firstCube.transform.position + new Vector3(
                horizontalInput * swipeModifier, 0f, 0f);

            targetPosition.x = Mathf.Clamp(targetPosition.x, -clampX, clampX);

            firstCube.transform.position = Vector3.Lerp(
                firstCube.transform.position, targetPosition, Time.deltaTime * moveSpeed);
        }
    }
}