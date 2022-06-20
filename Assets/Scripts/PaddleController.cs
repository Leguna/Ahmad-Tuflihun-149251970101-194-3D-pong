using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType { BottomPaddle = 1, TopPaddle = 2, LeftPaddle = 3, RightPaddle = 4 };

public class PaddleController : MonoBehaviour
{
    public int speed = 4;

    public KeyCode leftKey;
    public KeyCode rightKey;
    private Rigidbody rig;

    public bool isReverse;
    public bool isVertical;

    public PlayerType playerType;

    public Vector3 limitMoveMin;
    public Vector3 limitMoveMax;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveObject(GetInput());
    }

    private Vector3 GetInput()
    {
        if (Input.GetKey(leftKey))
        {
            float transformLocal = (isVertical ? transform.position.z : transform.position.x) * (isReverse ? -1 : 1);
            float limitLeft = (isVertical ? limitMoveMin.z : limitMoveMin.x);
            if (transformLocal >= limitLeft)
            {
                return transform.right * speed * -1;
            }
        }
        else if (Input.GetKey(rightKey))
        {
            float transformLocal = (isVertical ? transform.position.z : transform.position.x) * (isReverse ? -1 : 1);
            float limitRight = (isVertical ? limitMoveMax.z : limitMoveMax.x);
            if (transformLocal <= limitRight)
            {
                return transform.right * speed;
            }
        }

        return Vector3.zero;
    }

    private void MoveObject(Vector3 movement) => rig.position += movement * Time.deltaTime;


    public void DisablePlayer()
    {
        gameObject.SetActive(false);
    }
}