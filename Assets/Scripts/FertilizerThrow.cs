using UnityEngine;
using System.Collections;

public class FertilizerThrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision) {
		Collider2D collider = collision.collider;
		if (collider.tag == "Player" && collider.GetComponent<PlayerController>().isCarrying ()) {
			collider.GetComponent<PlayerController>().ThrowFert();
		}
	}
}
