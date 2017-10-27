using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2D : MonoBehaviour {

	public GameObject food;
	public Vector3 SpawnValues;
	public Vector3 MaxSpawnValues;
	private float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	private int startWait;
	private bool stop;

	int randEnemy;
	// Use this for initialization
	void Start () {
		StartCoroutine (waitSpawner());
	}
	
	// Update is called once per frame
	void Update () {
		spawnWait = Random.Range (spawnLeastWait, spawnMostWait);
	}

	IEnumerator waitSpawner()
	{
		yield return new WaitForSeconds (startWait);
		while (!stop) 
		{

			Vector3 spawnPosition = new Vector3 (Random.Range (-SpawnValues.x, SpawnValues.x), 1, Random.Range (-SpawnValues.z, SpawnValues.z));
			Instantiate (food, spawnPosition + transform.TransformPoint (0, 0, 0), gameObject.transform.rotation);
			
		}
		yield return new WaitForSeconds (startWait);
	}
}
