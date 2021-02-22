using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slash : MonoBehaviour
{
    //public Transform firepoint;
	//public GameObject bulletPrefab;
	public GameObject Damage;
	public GameObject Damage2;	
	public GameObject Damage3;
	public GameObject Damage4;
	//public Transform rutation;
	
	
	public float bulletForce= 20f;
	public float cooldownTime2;
	public float cooldownTime;
	private Animator anim;
	//public Image habilidad;
	
	private float nextFireTime;
	bool isCooldown = false;
	float moveX,moveY;
	
	void Start()
	{
		//habilidad.fillAmount = 0;
		anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
		
		if (isCooldown)
		{
			/*habilidad.fillAmount -= 1 / cooldownTime * Time.deltaTime;
			if(habilidad.fillAmount <= 0)
			{
				//habilidad.fillAmount = 0;
				//isCooldown = false;
			}*/
		}
		   if(Input.GetButtonDown("Fire1"))
		   {
				moveX = anim.GetFloat("movX");
				moveY = anim.GetFloat("movY");
				nextFireTime = Time.time + cooldownTime;
				anim.SetBool("atacking", true);
				//isCooldown = true;
				//habilidad.fillAmount = 1;
				//Shoot();
				if (moveX == 1){
				    Damage.SetActive(true);
				}
				if (moveX == -1){
				    Damage2.SetActive(true);
				}
				if (moveY == -1){
				    Damage3.SetActive(true);
				}
				if (moveY == 1){
				    Damage4.SetActive(true);
				}
		   }else{
				anim.SetBool("atacking", false);
			if(Time.time > nextFireTime){
				nextFireTime = Time.time + cooldownTime;
				Damage.SetActive(false);
				Damage2.SetActive(false);
				Damage3.SetActive(false);
				Damage4.SetActive(false);
                        }
		   }	
		
    }
	
	void Shoot()
	{
		/*GameObject bullet = Instantiate(bulletPrefab, firepoint.position, 		firepoint.rotation);*/
	}
}