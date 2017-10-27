using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSphere : MonoBehaviour {
	public GameObject foodPrefab;
	public int maxFood;
	public int ah;
	private float spawnRadius;
	public float minSpawnWait, maxSpawnWait;
	private Vector3 maxVal;
	private Vector3 minVal;
	private GameObject[] food;
	// Use this for initialization
	void Start () {
		//GetComponentInParent<SphereCollider> ().radius;
		//Debug.Log("Radio de la tierra :"+GetComponentInParent<SphereCollider>().radius);
		float sphareRadius =(GetComponentInParent<SphereCollider>().transform.localScale.x)/2;
		spawnRadius=sphareRadius*ah;
		for (int i = 0; i < maxFood; i++) {
			spawnFood ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		food = GameObject.FindGameObjectsWithTag ("Pick Up");
		if (food.Length < maxFood) {
			spawnFood ();
		}
	}


	void spawnFood()
	{
		int ran = Random.Range (1, 3);
		//minimo uno siempre tiene que tener 5

		Vector3 spawnPosition= transform.TransformPoint (0, 0, 0);

		switch (ran) 
		{
		case 1:
			spawnPosition = new Vector3 (spawnRadius, Random.Range (-spawnRadius, spawnRadius), Random.Range (-spawnRadius, spawnRadius));
			break;
		case 2:
			spawnPosition = new Vector3 (Random.Range (-spawnRadius, spawnRadius), spawnRadius, Random.Range (-spawnRadius, spawnRadius));
			break;
		case 3:
			spawnPosition = new Vector3 (Random.Range (-spawnRadius, spawnRadius), Random.Range (-spawnRadius, spawnRadius), spawnRadius);
			break;
		}

		Instantiate (foodPrefab, spawnPosition , gameObject.transform.rotation);
	}
}
