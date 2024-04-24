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



}
