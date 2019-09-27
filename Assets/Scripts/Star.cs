using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}//star
	
	void OnTriggerEnter2D(Collider2D target){
		if(target.gameObject.tag == "ball"){
			anim.SetInteger("StarAnimTrigger",1);
			Ball2d.STAR_COUNT++;
		}
	}//OnTriggerEnter2D

	public void DestroyItself(){
		gameObject.SetActive(false);
	}//DestroyItself

}//star
