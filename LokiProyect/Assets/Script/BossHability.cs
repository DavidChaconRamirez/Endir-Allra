using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHability : MonoBehaviour
{
   	 private float nextFireTime;
    	public GameObject CristalPrefab;
	public GameObject CristalPrefab2;
    	bool isCooldown = false;
    	public Transform firepoint;
	public Transform firepoint2;
    	public float cooldownTime;
	private GameObject cristal;
        private GameObject cristal2;
	public GameObject Enemy;
	private float rndNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown)
		{
			
		}
		if(Time.time > nextFireTime){
				rndNumber = Random.Range(0, 4);
				nextFireTime = Time.time + cooldownTime;
				isCooldown = true;
				switch (rndNumber)
				{
				  case 0:
					  StartCoroutine("PrimerInvoke1");
					  break;
				  case 1:
					  StartCoroutine("PrimerInvoke1");
					  break;
				  case 2:
					  StartCoroutine("PrimerInvoke2");
					  break;
				  case 3:
					  StartCoroutine("PrimerInvoke2");
					  break;
				  default:
					  Debug.Log("Default case");
					  break;
				}
		}
    }
	
	IEnumerator PrimerInvoke1 ()
    {

        GameObject Cristal = Instantiate(CristalPrefab, firepoint.position, firepoint.rotation);
		cristal = GameObject.FindGameObjectWithTag("Cristal");
        yield return new WaitForSeconds(2);
		GameObject enemy = Instantiate(Enemy, firepoint.position, firepoint.rotation);
	    Destroy(cristal);
    }
	IEnumerator PrimerInvoke2 ()
    {
        GameObject Cristal = Instantiate(CristalPrefab, firepoint.position, firepoint.rotation);
		cristal = GameObject.FindGameObjectWithTag("Cristal");
		GameObject Cristal2 = Instantiate(CristalPrefab2, firepoint2.position, firepoint2.rotation);
		cristal2 = GameObject.FindGameObjectWithTag("Cristal2");
        yield return new WaitForSeconds(2); 
		GameObject enemy = Instantiate(Enemy, firepoint.position, firepoint.rotation);
		GameObject enemy2 = Instantiate(Enemy, firepoint2.position, firepoint2.rotation);
	    Destroy(cristal);
		Destroy(cristal2);
    }
}

