using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dañoExplosion : MonoBehaviour
{
    public Vidita sn;
    public int damageCausado=0;
    void OnTriggerEnter2D(Collider2D col) {
	if (col.gameObject.tag == "Meteorito"){
	    sn.TakeDamage(damageCausado);
	}   
    }
}
