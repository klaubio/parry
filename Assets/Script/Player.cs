using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] private PhysicalMovement physicalMovement;
    [SerializeField] private float health;
    public float speedMove;
    [SerializeField] private float forceJump;
    [SerializeField] private Transform camerar;
    [SerializeField] private float sensMouse;
    [SerializeField] private float upDownRange = 80f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private Animator animator;
    

    
    public bool canAttack = true;
 

    private Vector3 camAngles;
 
   

    private void Start()
    {
        health = 20;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public void Move(InputAction.CallbackContext context)
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 velocity = Quaternion.Euler(0, camerar.eulerAngles.y, 0) * new Vector3(x, 0, z);

        physicalMovement.Move(velocity * speedMove);
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

        camAngles += rotation * sensMouse;
        camAngles.x = Mathf.Clamp(camAngles.x, -upDownRange, upDownRange);


        camerar.localEulerAngles = camAngles;

    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
           //Destroy(this.gameObject);
        }
    }
   


    public void Attack(InputAction.CallbackContext context)
    {

        if(context.started)
        {
            OnAttack();
            Debug.Log("Attack");
        }
       
    }

    public void OnAttack()
    {
        canAttack = false;
        animator.SetTrigger("Attack1");
        StartCoroutine(ResetAttackCoolDown());
    }


    IEnumerator ResetAttackCoolDown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }


}
