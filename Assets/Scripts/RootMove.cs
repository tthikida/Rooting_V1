using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMove : MonoBehaviour
{
    [SerializeField] private GameObject rootTip;
    [SerializeField] private GameObject rootMid;
    [SerializeField] private Transform rootCreatorTr;

    Vector3 moveDir;
    bool movedToNewTile;
    bool validMove;
    public bool hasMoved;
    string tipDir;
    Vector3 lastPos;

    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        movedToNewTile = false;
        validMove = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastPos = rootCreatorTr.position;
            print(lastPos);

            moveDir = new Vector3(0, 1f, 0);
            

            RotatePiece("up");
            transform.position += moveDir;

            animator.SetTrigger("rootMove");
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            lastPos = rootCreatorTr.position;
            moveDir = new Vector3(-1, 0, 0);

            if (!validMove) { return; }
            RotatePiece("left");

            transform.position += moveDir;
            animator.SetTrigger("rootMove");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            lastPos = rootCreatorTr.position;
            moveDir = new Vector3(0, -1, 0);

            if (!validMove) { return; }

            RotatePiece("down");
            transform.position += moveDir;
            animator.SetTrigger("rootMove");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            lastPos = rootCreatorTr.position;
            moveDir = new Vector3(1, 0, 0);

            if (!validMove) { return; }

            RotatePiece("right");
            transform.position += moveDir;

            animator.SetTrigger("rootMove");
        }

    }

    private void RotatePiece(string tipDir)
    {
        switch (tipDir)
        {
            case "left":
                transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case "right":
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case "up":
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case "down":
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }

    public void MoveBack()
    {
        if (hasMoved) { return; }

        rootCreatorTr.position += (moveDir * -1);
        hasMoved = true;

    }

    public void IsValidMove(bool isValid)
    {
        validMove = isValid;
    }

    public bool GetIsValid()
    {
        return validMove;
    }

    public Vector3 GetMoveDir()
    {
        return moveDir;
    }

    public Vector3 GetLastPos()
    {
        return lastPos;
    }
}
