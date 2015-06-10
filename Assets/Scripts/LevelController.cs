using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public GameObject concretePrefab;
	public GameObject grassPrefab;
	public GameObject bushPrefab;

	// Use this for initialization
	void Start () {
		PrepareLevel ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void PrepareLevel() {
		Vector3 position = new Vector3 ();
		GameObject currentGrass;

		for (int i = -14; i < 14; i++) {
			if (i >-2 && i < 1 ) { // middle concrete divider w/ fence
				for (int j = -8; j < 8; j++) {
					position.x = i * 0.64f + 0.32f;
					position.y = j * 0.64f + 0.32f;
					Instantiate(concretePrefab, position, new Quaternion());
				}
			}
			else { // everything else
				for (int j = -8; j < 8; j++) {
					position.x = i * 0.64f + 0.32f;
					position.y = j * 0.64f + 0.32f;
					if ( j < -7 || j > 4 || i < -13 || i > 12)
						Instantiate(concretePrefab, position, new Quaternion());
					else {
						if (Mathf.Abs(i) == 7 && Mathf.Abs(j) == 4)
							currentGrass = (GameObject) Instantiate(bushPrefab, position, new Quaternion());
						else
							currentGrass = (GameObject) Instantiate(grassPrefab, position, new Quaternion());
						if (i < 0)
							currentGrass.tag = "Grass1";
						else
							currentGrass.tag = "Grass2";
					}
				}
			}
		}

		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject player in players) {
			if(player.name == "P1")
				player.transform.position = new Vector3(-6, 4.15f, 0);
			else // P2
				player.transform.position = new Vector3(6, 4.15f, 0);
		}
	}





}
