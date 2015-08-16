using UnityEngine;
using System.Collections;

public class CameraEffects : MonoBehaviour {

	private Vector3 _initial;
	private float _time;
	private float _magnitude;

	// Use this for initialization
	void Start () {
		_initial = transform.position;
	}

	public void ScreenShake(float time, float magnitude)
	{
		_time = time;
		_magnitude = magnitude;
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
