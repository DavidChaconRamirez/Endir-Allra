using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaLimpia : MonoBehaviour
{
    public bool enemiesAlive = false;
    public float count;
    public GameObject Door;
    public GameObject Door2;
    public GameObject Door3;
    public GameObject Move;
    GameObject[] enemySpawns;
    // Update is called once per frame
    void Awake(){
	enemySpawns = GameObject.FindGameObjectsWithTag("Enemy");
    }
    void Update()
    {
	    count = enemySpawns.Length;
	    enemySpawns = GameObject.FindGameObjectsWithTag("Enemy");

                if(enemiesAlive == true){
                    
		    if(enemySpawns.Length<=0){
			enemiesAlive = false;
                    }
                }else{
		    Debug.Log("hola");
                    Door.SetActive(false);
                    Door2.SetActive(true);
                    Door3.SetActive(true);
		    Move.SetActive(true);
		    this.gameObject.SetActive(false);
		}
    }
}
