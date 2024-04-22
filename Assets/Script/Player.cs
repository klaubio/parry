using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] private PhysicalMovement physicalMovement;
    public float speedMove;
    [SerializeField] private float forceJump;
    [SerializeField] private Transform camerar;
    [SerializeField] private float sensMouse;


    public void Move(InputAction.CallbackContext context)
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        physicalMovement.Move(new Vector3(x, 0, z) * speedMove);
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started) 
        { 
            physicalMovement.Jump(forceJump);
        } 
    }


    public void Look(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        Vector3 rotation = Vector3.zero;
        rotation.x += -input.y;
        rotation.y += input.x;

        rotation.x = Mathf.Clamp(rotation.x, -90, 90);

        camerar.localEulerAngles += rotation * sensMouse;


    }


}
