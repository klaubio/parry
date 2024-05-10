using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{

    [SerializeField] private float lifetime = 3f;
    private float timer = 0f;

    private void Update()
    {
      
        timer += Time.deltaTime;


        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }








}
