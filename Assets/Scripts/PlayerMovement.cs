using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;	

	private GameObject _GM;
	private Rigidbody2D _r;
	private Vector3 _moveVector;
	private string _x;
	private string _y;


	// Use this for initialization
	void Start () {
		_GM = GameObject.FindGameObjectWithTag ("GameController");
		_r = GetComponent<Rigidbody2D>();
		if (name == "P1") {
			_x = "LeftStickX1";
			_y = "LeftStickY1";
		}else { //P2 
			_x = "LeftStickX2";
			_y = "LeftStickY2";
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (_GM.GetComponent<PlayerWin> ().GameOver ()) {
			_moveVector.x = 0;
			_moveVector.y = 0;
			_r.velocity = _moveVector;
			return;
		}

		if (!GetComponent<PlayerController> ().isAttacking () ){
			_moveVector.x = Input.GetAxis (_x) * speed;
			_moveVector.y = Input.GetAxis (_y) * speed * -1;
			_moveVector.z = 0f;

			_r.velocity = _moveVector;
		}
	}
}
