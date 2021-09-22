using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : Bird
{
    public float fieldofImpact;

    public float force;

    public LayerMask LayerToHit;

    public GameObject ExplosionEffect;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            explode();
        }
    }
    private void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, LayerToHit);
        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
     GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(ExplosionEffectIns, 5);
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    }
}
