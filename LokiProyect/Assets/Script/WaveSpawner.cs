using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	
	public enum SpawnState {SPAWNING, WAITING, COUNTING};
    [System.Serializable]
    public class Wave
    {
 	public string name;
	public Transform enemy;
	public int count;
	public float rate;
    }

    public Wave[] waves;
	private int nextWave = 0;
	
	public Text TextWave;
	private int NumberWave = 1;
	
	public Transform[] spawnPoints;
	
	public float timeBetweenWaves = 5f;
	private float waveCountdown;
	
	private float searchCountDown = 1f;
	
	public SpawnState state =  SpawnState.COUNTING;
	
	void Start()
	{
		TextWave.text = "Ronda: "+NumberWave;
		if (spawnPoints.Length == 0)
		{
			Debug.Log("No se encuentran los spwans");
		}
		waveCountdown = timeBetweenWaves;
	}
	
	void Update()
	{
		if (state == SpawnState.WAITING)
		{
			Debug.Log(EnemyIsAlive());
			if (!EnemyIsAlive())
			{
				WaveCompleted();
			}
			else
			{
				return;
			}
		}			
		if (waveCountdown <= 0)
		{
			if (state != SpawnState.SPAWNING)
			{
				StartCoroutine( SpawnWave(waves[nextWave]) );
			}
			
		}
		else
		{
			waveCountdown -= Time.deltaTime;
		}
	}
	
	void WaveCompleted()
	{
		state = SpawnState.COUNTING;
		waveCountdown = timeBetweenWaves;
		
		if (nextWave + 1 > waves.Length - 1)
		{
			nextWave = 0;
		}
		else
		{
			nextWave++;	
		}
		NumberWave++;
		TextWave.text = "Ronda: "+NumberWave;
		
	}
	
	bool EnemyIsAlive()
	{
		searchCountDown -= Time.deltaTime;
		if (searchCountDown <= 0f)
		{
			searchCountDown = 1f;
			if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
			{
				return false;
			}
		
		}
		return true;
	}
	
	IEnumerator SpawnWave (Wave _wave)
	{
		state = SpawnState.SPAWNING;
		
		for (int i = 0; i < _wave.count; i++)
		{
			SpawnEnemy (_wave.enemy);
			yield return new WaitForSeconds( 1f/_wave.rate );
		}
		
		state = SpawnState.WAITING;
		
		yield break;
	}
	
	void SpawnEnemy (Transform _enemy)
	{
		Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];
		Instantiate (_enemy, _sp.position, _sp.rotation);
	}
}
