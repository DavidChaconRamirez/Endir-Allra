using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    void Start(){
		string levelToLoad = LevelLoader.nextLevel;
		StartCoroutine(this.MakeTheLoad(levelToLoad));
	}
    IEnumerator MakeTheLoad(string level){
                //Solo para ver pantalla de carga.
		yield return new WaitForSeconds(1f);
		AsyncOperation operacion = SceneManager.LoadSceneAsync(level);
		while(operacion.isDone == false)
		{
			yield return null;
		}
	}
}
