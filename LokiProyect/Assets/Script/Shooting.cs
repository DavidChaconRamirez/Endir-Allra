using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
	public GameObject bulletPrefab;
	public Transform rutation;
	
	
	public float bulletForce= 20f;
	public float cooldownTime;
	public Image habilidad;
	
	private float nextFireTime;
	bool isCooldown = false;
	
	void Start()
	{
		habilidad.fillAmount = 0;
	}

    // Update is called once per frame
    void Update()
    {
		if (isCooldown)
		{
			habilidad.fillAmount -= 1 / cooldownTime * Time.deltaTime;
			if(habilidad.fillAmount <= 0)
			{
				habilidad.fillAmount = 0;
				isCooldown = false;
			}
		}
		if(Time.time > nextFireTime){
		   if(Input.GetButtonDown("Fire2"))
		   {
				nextFireTime = Time.time + cooldownTime;
				isCooldown = true;
				habilidad.fillAmount = 1;
				Shoot();
		   }
		}
		
    }
	
	void Shoot()
	{
		GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
	}
}