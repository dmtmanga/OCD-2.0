using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(AudioSource))]

public class SoundBank : MonoBehaviour {
	public string sample;
	public AudioClip[] soundClips;
	private AudioSource _audiosource;

	// Use this for initialization
	public void Start () {
		_audiosource = GetComponent<AudioSource> ();
	}

	public void PlayPersistent(){
		AudioSource.PlayClipAtPoint(soundClips[Random.Range (0 ,soundClips.Length)], transform.position);
	}
	public void Play(){
		_audiosource.PlayOneShot( soundClips[Random.Range (0 ,soundClips.Length)]);
	}

	public void Stop()
	{
		_audiosource.Stop ();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
