using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHorda : MonoBehaviour
{
   bool verdadero = false;
   void Update(){
	 if (Input.GetKeyDown(KeyCode.F) && verdadero == true)
	    {
		menu.SetActive(true);
	    }
   }
   public GameObject piedra, menu;
   void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
	    piedra.SetActive(true);
	    verdadero=true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
	    piedra.SetActive(false);
	    verdadero=false;
        }
    }
}
