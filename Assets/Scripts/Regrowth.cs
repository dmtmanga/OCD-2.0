using UnityEngine;
using System.Collections;

public class Regrowth : MonoBehaviour {

	public GameObject grownPrefab;
	public float growTime;
	public float growTimeVariance;
	public float fertilizeGrowTime;

	private GameObject GM;
	private float timeUntilGrown;

	// Use this for initialization
	void Start () {
		GM = GameObject.FindGameObjectWithTag("GameController");
		timeUntilGrown = growTime + Random.Range(-1 * growTimeVariance, growTimeVariance);
	}
	
	// Update is called once per frame
	void Update () {
		if (GM.GetComponent<PlayerWin>().GameOver())
			return;

		timeUntilGrown -= Time.deltaTime;
		if (timeUntilGrown <= 0) {
			Grow();
		}
	}

	void OnTriggerEnter2D( Collider2D collider) {
		if( (collider.tag == "Fertilizer1" && tag == "Trimmed2") || (collider.tag == "Fertilizer2" && tag == "Trimmed1") ){
			timeUntilGrown = fertilizeGrowTime;
		}
	}

	void Grow(){
		GameObject grass;
		grass = (GameObject) Instantiate(grownPrefab, transform.position, new Quaternion());
		if (grass.transform.position.x < 0)
			grass.tag = "Grass1";
		else
			grass.tag = "Grass2";
		//Instantiate (grassBladesPrefab, transform.position, new Quaternion(180, 0, 0, 1) );
		Destroy(gameObject);
	}
}
