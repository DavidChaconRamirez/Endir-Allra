using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public healthBar sn;
    void Update(){
	if (sn.slider.value <= 0){
	   Destroy(gameObject, 0.1f);
	} 
    }
	  
}
