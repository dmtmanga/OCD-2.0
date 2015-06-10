using UnityEngine;
using System.Collections;

public class BushCutTrigger : MonoBehaviour {

	public GameObject trimmedGrassPrefab;
	public GameObject grassBladesPrefab;
	public int bushHP;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		if (collision.collider.tag == "Sword") {
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
