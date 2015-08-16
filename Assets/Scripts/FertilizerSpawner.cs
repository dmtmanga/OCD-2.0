using UnityEngine;
using System.Collections;

public class FertilizerSpawner : MonoBehaviour {

	public GameObject myFertilizer;
	public float fertSpawnTime;

	private float _timeUntilSpawn;
	private bool _fertAvailable;

	// Use this for initialization
	void Start () {
		_fertAvailable = false;
		_timeUntilSpawn = fertSpawnTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (!_fertAvailable) {
			_timeUntilSpawn -= Time.deltaTime;
		}
		if (_timeUntilSpawn <= 0) {
			_fertAvailable = true;
			myFertilizer.SetActive(true);
			_timeUntilSpawn = fertSpawnTime;
		}
	}

	// Player picks up fertilizer if it is available
	void OnTriggerEnter2D (Collider2D collider){
		if (_fertAvailable && collider.tag == "Player") {
			_fertAvailable = false;
			myFertilizer.SetActive(false);
			PlayerController player =  collider.GetComponent<PlayerController>();
			player.PickupFert();
		}
	}



}
