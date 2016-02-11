using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    //private instance variables
    private Animator _animator;
    private float move;
	private float jump;
	private bool facingRight;
	private Transform _transform;

	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
	   	this._animator = gameObject.GetComponent<Animator> ();
       	this.move = 0; 
		this.jump = 0;
		this.facingRight = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	   	move = Input.GetAxis("Horizontal");
		jump = Input.GetAxis("Vertical");

		if (move > 0) {
			facingRight = true;
			Flip ();
		} 

		if(move < 0) {
			facingRight = false;
			Flip ();
		}

		if (move != 0) {
			_animator.SetInteger ("animState", 1);
		} else {
			_animator.SetInteger ("animState",0);
		}

		if(jump > 0)
			_animator.SetInteger ("animState", 2);
		
	}

	private void Flip(){
		if (!facingRight)
			this._transform.localScale = new Vector3 (-1f, 1f);
		else
			this._transform.localScale = new Vector3 (1f, 1f);
	}
}
