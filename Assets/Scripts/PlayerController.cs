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

	private Rigidbody2D _r;
	private bool _isAttacking = false;
	private float _attackTime;
	private Animator _animator;
	private bool _facingLeft;
	private bool _carryingFert;
	
	// Use this for initialization
	void Start () {
		_facingLeft = true;
		_carryingFert = false;
		_animator = GetComponent<Animator> ();
		_attackTime = attackCooldown;
		_r = GetComponent<Rigidbody2D> ();
		sword.transform.position = new Vector3 (sword.transform.parent.transform.position.x, 
		                                        sword.transform.parent.transform.position.y - 0.32f);
	}
	
	// Update is called once per frame
	void Update () {
		Attack ();
		
		if (Mathf.Abs(_r.velocity.x) > Mathf.Abs(_r.velocity.y)) {
			if( _r.velocity.x > 0)
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
			else if (_r.velocity.x < 0)
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
		else if (Mathf.Abs(_r.velocity.x) < Mathf.Abs(_r.velocity.y)) {
			if( _r.velocity.y > 0)
			{
				sword.transform.position = new Vector3 (sword.transform.parent.transform.position.x, 
				                                        sword.transform.parent.transform.position.y + 0.32f);
				_animator.SetBool("up", true);
				_animator.SetBool("down", false);
				_animator.SetBool ("left", false);
				_animator.SetBool ("right", false);

			}
			else if (_r.velocity.y < 0)
			{
				sword.transform.position = new Vector3 (sword.transform.parent.transform.position.x, 
				                                        sword.transform.parent.transform.position.y - 0.32f);
				_animator.SetBool("down", true);
				_animator.SetBool("up", false);
				_animator.SetBool ("left", false);
				_animator.SetBool ("right", false);
			}
		} 
		_animator.SetFloat ("speed", _r.velocity.magnitude);
	}


	void FootSteps() {
		AudioSource.PlayClipAtPoint(grassfootclips[Random.Range (0 ,grassfootclips.Length)], _r.position);
	}


	void Flip(){
		_facingLeft = !_facingLeft;

		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}


	void Attack(){
		if (!_isAttacking) {
			if (Input.GetButtonDown (a) || Input.GetButtonDown (x)) {
				_isAttacking = true;
				sword.SetActive(true);
				_r.velocity = new Vector3();
				AudioSource.PlayClipAtPoint(swingClips[Random.Range (0 ,swingClips.Length)], _r.position);
			}
		}else {
			_attackTime -= Time.deltaTime;
			if (_attackTime <= 0) {
				_attackTime = attackCooldown;
				_isAttacking = false;
				sword.SetActive(false);
			}
		}
	}


	void OnCollisionEnter2D( Collision2D collision) {
		if (collision.collider.tag == "Fence")
			ThrowFert ();
	}


	public bool isAttacking(){
		return _isAttacking;
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
		AudioSource.PlayClipAtPoint(throwclips[Random.Range (0 ,throwclips.Length)], _r.position);
	}
	
}
