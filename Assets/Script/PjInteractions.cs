using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PjInteractions : MonoBehaviour
{
    [SerializeField] private float forwardOffset = 0;
    [SerializeField] private float verticalOffset = 0;
    [SerializeField] private Vector3 size = Vector3.one;
    [SerializeField] private Player player;
    
    
    public int damageEnemy = 1;
    public int damageBalls = 1;





    [SerializeField] private LayerMask layerMask;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Vector3 center = transform.position + (transform.forward * forwardOffset);
        center.y += verticalOffset;

        Gizmos.DrawWireCube(center, size);
    }

    private void Update()
    {
        Vector3 center = transform.position + (transform.forward * forwardOffset);
        center.y += verticalOffset;

        Collider[] colliders = Physics.OverlapBox(center, size, transform.rotation, layerMask);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {

                player.TakeDamage(damageEnemy);

            }


            if (collider.CompareTag("Balls"))
            {
                player.TakeDamage(damageBalls);
            }

        }
    }



  

}
