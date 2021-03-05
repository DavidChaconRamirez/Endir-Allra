using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class cambioImagen : MonoBehaviour
{
    public Image UIImagen;
    private int range;
    public Sprite sprite,sprite2,sprite3,sprite4,sprite5,sprite6;
    void Start()
    {
	range= UnityEngine.Random.Range(0,5);
        UIImagen = GameObject.Find("imageChange").GetComponent<Image>
();    

	switch(range)
	{
    	case 0:
        	UIImagen.sprite = sprite; 
        	break;
    	case 1:
        	UIImagen.sprite = sprite2; 
        	break;
    	case 2:
        	UIImagen.sprite = sprite3; 
        	break;
    	case 3:
        	UIImagen.sprite = sprite4; 
        	break;
    	case 4:
        	UIImagen.sprite = sprite5; 
        	break;
    	case 5:
        	UIImagen.sprite = sprite6; 
        	break;
	default:
        	UIImagen.sprite = sprite; 
        	break;
	}

	
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
