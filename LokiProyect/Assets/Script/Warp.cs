using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Warp : MonoBehaviour
{
    // Para almacenar el punto de destino
    public GameObject target;
    public GameObject Camera; 
    public GameObject Camera2;
    public GameObject Seccion1;
    public GameObject Seccion2;
    public GameObject Boss;

    // Para controlar si empieza o no la transición
    bool start = false;
    // Para controlar si la transición es de entrada o salida
    bool isFadeIn = false;
    // Opacidad inicial del cuadrado de transición
    float alpha = 0;
    // Transición de 1 segundo
    float fadeTime = 1f;


    void OnTriggerEnter2D (Collider2D col) {

        if (col.tag == "Player"){
			col.transform.position = target.transform.position;
			Seccion1.SetActive(false);
			Camera.SetActive(false);
			Seccion2.SetActive(true);
			Camera2.SetActive(true);
			Boss.SetActive(true);
			
        }

    }

    // Dibujaremos un cuadrado con opacidad encima de la pantalla simulando una transición
    void OnGUI () {

        // Si no empieza la transición salimos del evento directamente
        if (!start)
            return;

        // Si ha empezamos creamos un color con una opacidad inicial a 0
        GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        // Creamos una textura temporal para rellenar la pantalla
        Texture2D tex;
        tex = new Texture2D (1, 1);
        tex.SetPixel (0, 0, Color.black);
        tex.Apply ();

        // Dibujamos la textura sobre toda la pantalla
        GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), tex);

        // Controlamos la transparencia
        if (isFadeIn) {
            // Si es la de aparecer le sumamos opacidad
            alpha = Mathf.Lerp (alpha, 1.1f, fadeTime * Time.deltaTime);
        } else {
            // Si es la de desaparecer le restamos opacidad
            alpha = Mathf.Lerp (alpha, -0.1f, fadeTime * Time.deltaTime);
            // Si la opacidad llega a 0 desactivamos la transición
            if (alpha < 0) start = false;
        }

    }

    // Método para activar la transición de entrada
    void FadeIn () {
        start = true;
        isFadeIn = true;
    }

    // Método para activar la transición de salida
    void FadeOut () {
        isFadeIn = false;
    }

}
