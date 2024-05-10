using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] EnemyAiTutorial enemy;
    
    public void Damage()
    {
        enemy.health -= damage;
    }  

     public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Damage();
           
            if(enemy.health <= 0)
            {
                Destroy(other.gameObject);
            }

        }

       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wood"))
        {
            Destroy(other.gameObject);
        }
    }





}
