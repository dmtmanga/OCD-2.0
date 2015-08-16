using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerWin : MonoBehaviour {

	public Text winMessage;
	public float restartTime;

	private bool gameEnd = false;
	private float timeUntilRestart;
	private GameObject[] p1Yard;
	private GameObject[] p2Yard;

	// Use this for initialization
	void Start () {
		timeUntilRestart = restartTime;
		winMessage.gameObject.SetActive(false);
		winMessage.text = "";
	}
	
	// Update is called once per frame
	void Update () {

		p1Yard = GameObject.FindGameObjectsWithTag ("Grass1");
		p2Yard = GameObject.FindGameObjectsWithTag ("Grass2");

		if (gameEnd) {
			timeUntilRestart -= Time.deltaTime;
			if (timeUntilRestart <= 0) {
				ClearLevel();
				GetComponent<LevelController>().PrepareLevel();
				timeUntilRestart = restartTime;
				winMessage.gameObject.SetActive(false);
				gameEnd = false;
			}
			return;
		}
		
		// Dev Build Only!
		QuickClear ();
		// ------------------------------------

		if (p1Yard.Length == 0) {
			//Debug.Log("P1 Wins!");
			EndGame("P1");
		} else if (p2Yard.Length == 0) {
			//Debug.Log("P2 Wins!");
			EndGame("P2");
		}
	}

	// Use to quickly test win states.
	void QuickClear(){
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			foreach(GameObject grass in p1Yard)
				grass.GetComponent<CutTrigger>().Cut ();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			foreach(GameObject grass in p2Yard)
				grass.GetComponent<CutTrigger>().Cut ();
		}
	}
	
	void EndGame( string winner ){
		gameEnd = true;
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraEffects>().ScreenShake(2f, 0.4f);
		//Time.timeScale = 0;
		if (winner == "P1") {
			winMessage.rectTransform.anchoredPosition = new Vector2(-200, -175);
			winMessage.text = "Player 1 Wins!";
			winMessage.color = new Color(255, 0, 0);
			winMessage.gameObject.SetActive(true);
		} else if (winner == "P2") {
			winMessage.rectTransform.anchoredPosition = new Vector2(200,-175);
			winMessage.text = "Player 2 Wins!";
			winMessage.color = new Color(0, 0, 255);
			winMessage.gameObject.SetActive(true);
		}
	}

	void EndGame() {
		EndGame ("");
	}

	void ClearLevel(){
		GameObject[] trimmed1 = GameObject.FindGameObjectsWithTag("Trimmed1");
		GameObject[] trimmed2 = GameObject.FindGameObjectsWithTag("Trimmed2");
		foreach(GameObject grass in trimmed1)
			Destroy (grass);
		foreach(GameObject grass in trimmed2)
			Destroy (grass);
		foreach(GameObject grass in p1Yard)
			Destroy(grass);
		foreach(GameObject grass in p2Yard)
			Destroy(grass);
	}

	public bool GameOver(){
		return gameEnd;
	}

}
