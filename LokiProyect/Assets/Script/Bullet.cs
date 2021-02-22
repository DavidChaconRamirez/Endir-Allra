using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public Transform rutation;	
	void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject effect = Instantiate(hitEffect, transform.position, rutation.rotation);
		Destroy(effect, 5f);
		Destroy(gameObject);
	}
}
