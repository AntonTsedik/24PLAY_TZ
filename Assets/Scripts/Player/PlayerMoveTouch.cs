using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTouch : MonoBehaviour
{
    private float LeftSide = -2;
    private float RightSide = 2;
    private bool isMoving = false;
    private Touch touch;
    private float speedModifier;
    private float moveSpeed = 7.5f;

    [SerializeField] GameObject StartMenu;
    [SerializeField] GameObject WarpEffect;

    private void Start()
    {
        speedModifier = 0.01f;
    }
    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward, Space.World);
            StartMenu.SetActive(false);
        }
        
        if (Input.touchCount > 0)
        {
            WarpEffect.SetActive(true);
            isMoving = true;
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y, transform.position.z);
            }
        }

        if (gameObject.transform.position.x < LeftSide)
        {
            transform.position = new Vector3(LeftSide, transform.position.y, transform.position.z);
        }
        if (gameObject.transform.position.x > RightSide)
        {
            transform.position = new Vector3(RightSide, transform.position.y, transform.position.z);
        }
    }
}
