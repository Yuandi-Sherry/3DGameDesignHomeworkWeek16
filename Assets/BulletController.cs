using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
    	Debug.Log("hittttttttttttttttttttt");
        var hit = collision.gameObject;
        var hitPlayer = hit.GetComponent<PlayerController>();

        if (hitPlayer != null)
        {
            var combat = hit.GetComponent<Combat>();
            combat.TakeDamage(30);
            Destroy(gameObject);
        }
    }
}