using UnityEngine;
using System.Collections;

public class FertilizerController : MonoBehaviour {

	public float speed;
	
	private Vector3 _moveVector;
	
	// Use this for initialization
	void Start () {
		_moveVector = new Vector3();
		if (tag == "Fertilizer1") {
			_moveVector.x = 0.1f * speed;
		} 
		else if (tag == "Fertilizer2") {
			_moveVector.x = -0.1f * speed;
		}
	}


	// Update is called once per frame
	void Update () {
		transform.Translate (_moveVector);
	}

	
	void OnTriggerEnter2D( Collider2D collider){
		if (collider.tag == "OuterWall")
			Destroy (gameObject);
	}
}
