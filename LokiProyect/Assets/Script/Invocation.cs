using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invocation : MonoBehaviour
{
    public Transform turget;
    public Transform rutation;	
    public GameObject Sumoner;
	public GameObject Meteoro;
	//public GameObject Explosion;
	private Vector2 target;
	
	//variables cooldown
	bool isCooldown = false;
	private float nextFireTime;
	public float cooldownTime;
	public Image habilidad;
    // Update is called once per frame
    void Start()
	{
		habilidad.fillAmount = 0;
	}
	
	void Update()
    {
		target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
		Sumoner.transform.position = target;
		
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
			if (Input.GetKeyDown ( KeyCode.E ))
			{
				Cursor.visible = false;
				Sumoner.SetActive(true);
			}else if (Input.GetKeyUp ( KeyCode.E )){
				nextFireTime = Time.time + cooldownTime;
				isCooldown = true;
				habilidad.fillAmount = 1;
				Cursor.visible = true;
				Sumoner.SetActive(false);
				StartCoroutine (Lanzamiento ());
			}
		}
    }
	
	IEnumerator Lanzamiento ()
	{
		GameObject meteor = Instantiate(Meteoro, turget.position, transform.rotation);
		//Meteoro.transform.position = target;
		//Meteoro.SetActive(true);
		//Explosion.SetActive(true);
		yield return new WaitForSeconds(0.2f);
		//Meteoro.SetActive(false);
		Destroy(meteor);
		//Explosion.SetActive(false);
	}
}
