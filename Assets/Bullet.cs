using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;

    //this makes the bullet disapear on collision and plays the particle explosion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        Destroy(gameObject, 0.1f);
           
    }

        
        //This makes the box disapear if it has is trigger on and has the tag "Box"
        public void OnTriggerEnter2D(Collider2D other)
        {
            other.gameObject.CompareTag("Box");
        
        Destroy(other.gameObject);
        }




    
}


