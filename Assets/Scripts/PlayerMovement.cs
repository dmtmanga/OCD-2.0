using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;	

	private GameObject GM;
	private Rigidbody2D r;
	private Vector3 moveVector;
	private string x;
	private string y;


	// Use this for initialization
	void Start () {
		GM = GameObject.FindGameObjectWithTag ("GameController");
		r = GetComponent<Rigidbody2D>();
		if (name == "P1") {
			x = "LeftStickX1";
			y = "LeftStickY1";
		}else { //P2 
			x = "LeftStickX2";
			y = "LeftStickY2";
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (GM.GetComponent<PlayerWin> ().GameOver ()) {
			moveVector.x = 0;
			moveVector.y = 0;
			r.velocity = moveVector;
			return;
		}

		if (! GetComponent<PlayerController> ().isAttacking ()) {
			moveVector.x = Input.GetAxis (x) * speed;
			moveVector.y = Input.GetAxis (y) * speed * -1;
			moveVector.z = 0f;

			r.velocity = moveVector;
		}
	}
}
