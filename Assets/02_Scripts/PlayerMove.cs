using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;   

    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float jumpForce = 7.0f;
    [SerializeField] Transform cameraTransform;
    private bool isGround = true;

    private static readonly int moveSpeedhash = Animator.StringToHash("move");
    private static readonly int jumpForcehash = Animator.StringToHash("isGround");


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (GameManager.Instance.State != GameState.Playing) return;
        HandleMove();
        HandlJump();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            anim.SetBool("isGround", false);
        }
    }
    private void HandleMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(moveX, 0.0f, moveZ);
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0.0f;
        if (dir.magnitude > 1.0f)
        {
            dir = dir.normalized;
        }
        MoveRotation(dir);
        Move(dir);
    }
    private void MoveRotation(Vector3 dir)
    {
        transform.LookAt(transform.position + dir);
    }
    private void Move(Vector3 dir)
    {
        Vector3 move = dir * moveSpeed * Time.deltaTime;
        transform.position += move;

        float moveValue = dir.magnitude;
        anim.SetFloat(moveSpeedhash,moveValue);
    }
    private void HandlJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                Jump();
            }            
        }
    }
    private void Jump()
    {
        anim.SetBool(jumpForcehash, true);
        Vector3 jumpV = rb.velocity;
        jumpV.y = jumpForce;
        rb.velocity = jumpV;
        isGround = false;
    }
}
