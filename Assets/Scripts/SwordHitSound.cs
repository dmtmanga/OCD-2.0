using UnityEngine;
using System.Collections;

public class SwordHitSound : MonoBehaviour {
	public AudioClip[] soundClips;
	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter2D (Collider2D collider){
		if (collider.tag == "Sword") {
			AudioSource.PlayClipAtPoint(soundClips[Random.Range (0 ,soundClips.Length)], transform.position);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
