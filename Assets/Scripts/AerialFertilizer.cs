using UnityEngine;
using System.Collections;

public class AerialFertilizer : MonoBehaviour {

	public float speed;

	private Vector3 moveVector;
	private bool thrown;

	// Use this for initialization
	void Start () {
		thrown = false;
		moveVector = new Vector3();
		if (tag == "Fertilizer1") {
			moveVector.x = speed;
		} else {
			moveVector.x = -1 * speed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (thrown) {
			transform.Translate (moveVector);
		}
	}

	void OnTriggerEnter2D( Collider2D collider){
		if (collider.tag == "OuterWall")
			Destroy (gameObject);
	}

	public void Fly(){
		transform.parent = null;
		thrown = true;
	}
}
