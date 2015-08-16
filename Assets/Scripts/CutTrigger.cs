using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SoundBank))]

public class CutTrigger : MonoBehaviour {
	public GameObject trimmedGrassPrefab;
	public GameObject grassBladesPrefab;
	private Dictionary<string, SoundBank> _soundbanks;

	// Use this for initialization
	void Start () {
		_soundbanks = new Dictionary<string, SoundBank> ();
		SoundBank[] soundbanks = GetComponents<SoundBank> ();
		
		foreach(SoundBank soundbank in soundbanks)
		{
			_soundbanks.Add(soundbank.sample, soundbank);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider){
		if (collider.tag == "Sword") {
			_soundbanks["cut"].PlayPersistent ();
			Cut ();
		}
	}

	public void Cut(){
		GameObject trimmed;
		trimmed = (GameObject) Instantiate (trimmedGrassPrefab, transform.position, new Quaternion());
		Instantiate (grassBladesPrefab, transform.position, new Quaternion(180, 0, 0, 1) );
		if (tag == "Grass1")
			trimmed.tag = "Trimmed1";
		else
			trimmed.tag = "Trimmed2";
		Destroy (gameObject);
	}
}
