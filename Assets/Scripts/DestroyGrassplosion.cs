using UnityEngine;
using System.Collections;

public class DestroyGrassplosion : MonoBehaviour {

	private ParticleSystem leaves;
	public float lifetime;

	// Use this for initialization
	void Start () {
		leaves = GetComponent<ParticleSystem> ();
		leaves.Play ();
		Invoke ("Stop", lifetime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Stop() {
		Destroy (gameObject);
	}
}
