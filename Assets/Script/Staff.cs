using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
     public int damage;
     public EnemyAiTutorial enemy;
    
    

     public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyAiTutorial>().TakeDamage(damage);

            if (enemy.health <= 0)
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
