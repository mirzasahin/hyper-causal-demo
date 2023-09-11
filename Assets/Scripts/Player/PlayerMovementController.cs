using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    PlayerLife playerLife;

    [SerializeField] private PlayerInputController playerInputController;

    [SerializeField] private float forwardMovementSpeed;

    [SerializeField] private float horizontalMovementSpeed;

    [SerializeField] private float horizontalLimitValue;


    private float newPositionX;

    private void Start()
    {
        playerLife = GameObject.FindObjectOfType<PlayerLife>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        SetPlayerForwardMovement();
        SetPlayerHorizontalMovement();
    }

    private void SetPlayerForwardMovement()
    {
        if (playerLife.isLive)
        {
            transform.Translate(Vector3.down * forwardMovementSpeed * Time.fixedDeltaTime);
        }
    }
     
    private void SetPlayerHorizontalMovement()
    {
        newPositionX = transform.position.x + playerInputController.horizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValue, horizontalLimitValue);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
