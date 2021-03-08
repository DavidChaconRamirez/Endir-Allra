using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    bool active;
    Canvas canvas;
    public healthBar sn;
    public GameObject Player, Puntero;
    public GameObject CameraPlayer, CameraPlayer2;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (sn.slider.value <= 0){
	   
	   StartCoroutine("PrimerInvoke1");
	} 
    }
    IEnumerator PrimerInvoke1()
    {
	Puntero.SetActive(false);
	Player.GetComponent<Shooting>().enabled = false;
	Player.GetComponent<PlayerMovement>().enabled = false;
	CameraPlayer.GetComponent<Invocation>().enabled = false;
	CameraPlayer2.GetComponent<Invocation>().enabled = false;
	active = true;
        canvas.enabled = active;
	//Time.timeScale = 0;
	yield return new WaitForSeconds(3);
	LevelLoader.LoadLevel("SampleScene");
    }
}
