using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInvoque : MonoBehaviour
{   
    private GameObject cristal;
    private float nextFireTime=0;
    public float cooldownTime;
    public GameObject CristalPrefab;
    public GameObject Enemy;
    public Transform firepoint;
    bool prueba=true;
    // Update is called once per frame
    void Awake()
    {
        GameObject Cristal = Instantiate(CristalPrefab, firepoint.position, firepoint.rotation);
        cristal = GameObject.FindGameObjectWithTag("Cristal");
    }
    void Update()
    {
	
	if(prueba==true && nextFireTime == 60){
      	     GameObject enemy = Instantiate(Enemy, firepoint.position, firepoint.rotation);
	     Destroy(cristal);	
	     prueba=false;
        }else{
	     nextFireTime++;
	}
    }
}
