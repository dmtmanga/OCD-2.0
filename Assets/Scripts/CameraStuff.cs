using UnityEngine;
using System.Collections;

public class CameraStuff : MonoBehaviour {

	private Vector3 _initial;
	private float _time;
	private float _magnitude;

	// Use this for initialization
	void Start () {
		_initial = transform.position;
		ScreenShake ();
	}

	public void ScreenShake()
	{
		_time = 2;
		_magnitude = 0.4f;
	}

	// Update is called once per frame
	void Update () {
		_time -= Time.deltaTime;
		_magnitude -= 0.01f;

		if (_magnitude < 0) {
			_magnitude =0.001f;
		}
		if (_time <= 0) {
			_time = 0;
			transform.position = _initial;
		}

		if (_time > 0) {
			transform.position = new Vector3(_initial.x + Random.Range (-_magnitude, _magnitude), _initial.y + Random.Range (-_magnitude, _magnitude), _initial.z);
		}
	}
}
