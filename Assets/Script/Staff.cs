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


  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Damage();
        }
    }



}
