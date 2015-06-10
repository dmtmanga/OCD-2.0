using UnityEngine;
using System.Collections;

public class FertilizerPickup : MonoBehaviour {
	
	private bool _pickedUp;
	// Use this for initialization
	void Start () {
		_pickedUp = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D ( Collider2D collider) {

		if (collider.tag == "Player" && !_pickedUp) {
			_pickedUp = true;
			transform.position = new Vector3(collider.transform.position.x, collider.transform.position.y + 0.32f, 0);
			transform.parent = collider.transform;
			GetComponentInParent<PlayerController>().PickupFert();
		}
	}
}
