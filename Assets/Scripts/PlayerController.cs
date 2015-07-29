using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {
	
	public GameObject sword;
	public GameObject myFertilizer;
	public GameObject fertPrefab;
	public float attackCooldown;
	public string x;
	public string a;
	public AudioClip[] swingClips;
	public AudioClip[] grassfootclips;
	public AudioClip[] throwclips;

	private Rigidbody2D r;
	private bool attacking = false;
	private float attackTime;
	private Animator _animator;
	private bool _facingLeft;
	private bool _carryingFert;
	
	// Use this for initialization
	void Start () {
		_facingLeft = true;
		_carryingFert = false;
		_animator = GetComponent<Animator> ();
		attackTime = attackCooldown;
		r = GetComponent<Rigidbody2D> ();
		sword.transform.position = new Vector3 (sword.transform.parent.transform.position.x, 
		                                        sword.transform.parent.transform.position.y - 0.32f);
	}
	
	// Update is called once per frame
	void Update () {
		Attack ();
		
		if (Mathf.Abs(r.velocity.x) > Mathf.Abs(r.velocity.y)) {
			if( r.velocity.x > 0)
			{
				sword.transform.position = new Vector3 (sword.transform.parent.transform.position.x + 0.32f, sword.transform.parent.transform.position.y);
				_animator.SetBool ("right", true);
				_animator.SetBool ("left", false);
				_animator.SetBool ("up", false);
				_animator.SetBool ("down", false);

				if(_facingLeft)
				{
					Flip ();
				}
			}
			else if (r.velocity.x < 0)
			{
				sword.transform.position = new Vector3 (sword.transform.parent.transform.position.x - 0.32f, 
				                                        sword.transform.parent.transform.position.y);
				_animator.SetBool("left", true);
				_animator.SetBool("right", false);
				_animator.SetBool ("up", false);
				_animator.SetBool ("down", false);
				if(!_facingLeft)
				{
					Flip ();
				}
			}
		}
		else if (Mathf.Abs(r.velocity.x) < Mathf.Abs(r.velocity.y)) {
			if( r.velocity.y > 0)
			{
				sword.transform.position = new Vector3 (sword.transform.parent.transform.position.x, 
				                                        sword.transform.parent.transform.position.y + 0.32f);
				_animator.SetBool("up", true);
				_animator.SetBool("down", false);
				_animator.SetBool ("left", false);
				_animator.SetBool ("right", false);

			}
			else if (r.velocity.y < 0)
			{
				sword.transform.position = new Vector3 (sword.transform.parent.transform.position.x, 
				                                        sword.transform.parent.transform.position.y - 0.32f);
				_animator.SetBool("down", true);
				_animator.SetBool("up", false);
				_animator.SetBool ("left", false);
				_animator.SetBool ("right", false);
			}
		} 
		_animator.SetFloat ("speed", r.velocity.magnitude);
	}


	void FootSteps() {
		AudioSource.PlayClipAtPoint(grassfootclips[Random.Range (0 ,grassfootclips.Length)], r.position);
	}


	void Flip(){
		_facingLeft = !_facingLeft;

		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}


	void Attack(){
		if (!attacking) {
			if (Input.GetButtonDown (a) || Input.GetButtonDown (x)) {
				attacking = true;
				sword.SetActive(true);
				r.velocity = new Vector3();
				AudioSource.PlayClipAtPoint(swingClips[Random.Range (0 ,swingClips.Length)], r.position);
			}
		}else {
			attackTime -= Time.deltaTime;
			if (attackTime <= 0) {
				attackTime = attackCooldown;
				attacking = false;
				sword.SetActive(false);
			}
		}
	}


	void OnCollisionEnter2D( Collision2D collision) {
		if (collision.collider.tag == "Fence")
			ThrowFert ();
	}


	public bool isAttacking(){
		return attacking;
	}


	public bool isCarrying(){
		return _carryingFert;
	}


	public void PickupFert() {
		_carryingFert = true;
		myFertilizer.SetActive(true);
	}

	
	public void ThrowFert() {
		GameObject thrownFert;

		_carryingFert = false;
		thrownFert = (GameObject) Instantiate(fertPrefab, transform.position, new Quaternion());
		if (gameObject.name == "P1")
			thrownFert.tag = "Fertilizer1";
		else if (gameObject.name == "P2")
			thrownFert.tag = "Fertilizer2";
		else
			System.Console.WriteLine ("Cannot determine which playwer is throwing fertilizer!!!");
		AudioSource.PlayClipAtPoint(throwclips[Random.Range (0 ,throwclips.Length)], r.position);
	}
	
}
