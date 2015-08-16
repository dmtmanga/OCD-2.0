using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BushCutTrigger : MonoBehaviour {

	public GameObject trimmedGrassPrefab;
	public GameObject grassBladesPrefab;
	public int bushHP;
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
	
	void OnCollisionEnter2D (Collision2D collision){
		if (collision.collider.tag == "Sword") {
			_soundbanks ["cut"].Play ();
			bushHP -= 1;
			if (bushHP <= 0)
				Cut ();
		}
	}
	
	public void Cut(){

		Instantiate (trimmedGrassPrefab, transform.position, new Quaternion());
		Instantiate (grassBladesPrefab, transform.position, new Quaternion(180, 0, 0, 1) );
		Destroy (gameObject);
	}
}
