using UnityEngine;
using System.Collections;

public class FertilizerController : MonoBehaviour {

	public float speed;
	
	private Vector3 moveVector;
	
	// Use this for initialization
	void Start () {
		moveVector = new Vector3();
		if (tag == "Fertilizer1") {
			moveVector.x = speed;
		} 
		else if (tag == "Fertilizer2") {
			moveVector.x = -1 * speed;
		}
	}


	// Update is called once per frame
	void Update () {
		transform.Translate (moveVector);
	}

	
	void OnTriggerEnter2D( Collider2D collider){
		if (collider.tag == "OuterWall")
			Destroy (gameObject);
	}
}
