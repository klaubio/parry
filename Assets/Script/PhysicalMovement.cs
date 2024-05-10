using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class PhysicalMovement : MonoBehaviour
{
   
    [SerializeField] private CharacterController controller;
    private Vector3 velocity;
    private float jumpsCount;
    private float disableGroundDetection;
    [SerializeField] private float fallingGravity =3;
    [SerializeField] private float jumpingGravity = 1;
    [SerializeField] private float dashDistance = 5f;
    [SerializeField] private float dashDuration = 0.5f;
    public bool isDashing = false;
    private Vector3 dashDirection;
    private float dashStartTime;






    private void Update()
    {
        controller.Move(velocity * Time.deltaTime);

        float gravityScale = fallingGravity;
        if (controller.isGrounded)
        {
            velocity.y = 0;
            jumpsCount = 0;
        }
        else
        {
            velocity.y += Physics.gravity.y * gravityScale * Time.deltaTime;
            disableGroundDetection-= Time.deltaTime;
            disableGroundDetection = Mathf.Max(0,disableGroundDetection);
        }

        if(controller.velocity.y >=0) gravityScale = jumpingGravity;


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartDash();
        }

        if (isDashing)
        {
            PerformDash(isDashing);
        }


    }


    public void Move(Vector3 velocity)
    {
        this.velocity.x = velocity.x;
        this.velocity.z = velocity.z;
    }

    public void Jump(float force)
    {
        if(jumpsCount >1) return;

        velocity.y = force;
        jumpsCount++;

        disableGroundDetection = 0.2f;
    }


    public void StartDash()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        dashDirection = new Vector3(horizontal, 0, vertical).normalized;
        dashStartTime = Time.time;
        isDashing = true;
    }

     public void PerformDash(bool isdashing)
    {
        isDashing=isdashing;

        Vector3 dashPosition = transform.position + dashDirection * (dashDistance / dashDuration) * Time.deltaTime;
        controller.Move(dashDirection * (dashDistance / dashDuration) * Time.deltaTime);
        if (Time.time - dashStartTime >= dashDuration)
        {
            isDashing = false;
        }
    }

    
        

  

 


}
