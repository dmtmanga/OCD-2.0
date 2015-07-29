using UnityEngine;
using System.Collections;

public class FertilizerSpawner : MonoBehaviour {

	public GameObject myFertilizer;
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
		if (!fertAvailable) {
			timeUntilSpawn -= Time.deltaTime;
		}
		if (timeUntilSpawn <= 0) {
			fertAvailable = true;
			myFertilizer.SetActive(true);
			timeUntilSpawn = fertSpawnTime;
		}
	}

	// Player picks up fertilizer if it is available
	void OnTriggerEnter2D (Collider2D collider){
		if (fertAvailable && collider.tag == "Player") {
			fertAvailable = false;
			myFertilizer.SetActive(false);
			PlayerController player =  collider.GetComponent<PlayerController>();
			player.PickupFert();
		}
	}



}
