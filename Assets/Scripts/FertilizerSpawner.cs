using UnityEngine;
using System.Collections;

public class FertilizerSpawner : MonoBehaviour {

	public GameObject fertPrefab;
	public float fertSpawnTime;

	private float timeUntilSpawn;
	private bool fertAvailable;

	// Use this for initialization
	void Start () {
		fertAvailable = false;
		timeUntilSpawn = fertSpawnTime;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject fertilizer;

		if (!fertAvailable) {
			timeUntilSpawn -= Time.deltaTime;
		}
		if (timeUntilSpawn <= 0) {
			fertilizer = (GameObject) Instantiate(fertPrefab, transform.position, new Quaternion());
			if (name == "Fertilizer Spawn 1")
				fertilizer.tag = "Fertilizer1";
			else // Spawn 2
				fertilizer.tag = "Fertilizer2";

			fertAvailable = true;
			timeUntilSpawn = fertSpawnTime;
		}
	}

	void OnTriggerEnter2D (Collider2D collider){
		if (fertAvailable && collider.tag == "Player") {
			fertAvailable = false;

		}
	}



}
