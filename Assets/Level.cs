using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	public Enemy[] Enemies;

	public int StartDelay = 3;

	private int _spawnWaitTime = 2;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemies());
	}
	
	private IEnumerator SpawnEnemies()
	{
		yield return new WaitForSeconds(StartDelay);

		int enemy = -1;
		while(true)
		{
			enemy = (enemy + 1) % Enemies.Length;

			Instantiate(Enemies[enemy]);

			yield return new WaitForSeconds(_spawnWaitTime);
		}
	}
}
