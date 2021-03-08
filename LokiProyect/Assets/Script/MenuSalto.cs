using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSalto : MonoBehaviour
{
    public void LanzamientoSalir(){
		Application.Quit();
	}
    public void LanzamientoMenu(){
		LevelLoader.LoadLevel("Menu");
	}
        public void LanzamientoRaid(){
		LevelLoader.LoadLevel("SampleScene");
	}
        public void LanzamientoTrono(){
		LevelLoader.LoadLevel("Templar");
	}
        public void LanzamientoHorda(){
		LevelLoader.LoadLevel("HordeMode");
	}
}
