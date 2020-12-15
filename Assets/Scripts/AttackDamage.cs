using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{

    public LayerMask Layer;
    public float radius = 2f;
    public float damage = 10f;

 
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, Layer);
        if(hits.Length>0)
        {
            hits[0].GetComponent<Health>().ApplyDamage(damage);
            gameObject.SetActive(false);
        }

    }
}
