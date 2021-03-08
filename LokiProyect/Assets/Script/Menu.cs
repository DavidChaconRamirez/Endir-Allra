using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    bool active;
    Canvas canvas;
    public GameObject Player, Puntero, Detector;
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
        if (Input.GetKeyDown(KeyCode.Escape)){
	   active = !active;
	   canvas.enabled = active;
	   Puntero.SetActive((active) ? false : true);
	   Detector.SetActive((active) ? false : true);
	   Player.GetComponent<Shooting>().enabled =(active) ? false : true;
	   Player.GetComponent<PlayerMovement>().enabled =(active) ? false : true;
	   Player.GetComponent<slash>().enabled =(active) ? false : true;
	   CameraPlayer.GetComponent<Invocation>().enabled =(active) ? false : true;
	CameraPlayer2.GetComponent<Invocation>().enabled =(active) ? false : true;
	   Time.timeScale = (active) ? 1f : 1f;
	   //StartCoroutine("PrimerInvoke1");
	} 
    }
    /*IEnumerator PrimerInvoke1()
    {
	
	active = true;
        canvas.enabled = active;
	//Time.timeScale = 0;
	yield return new WaitForSeconds(3);
	LevelLoader.LoadLevel("SampleScene");
    }*/
}
