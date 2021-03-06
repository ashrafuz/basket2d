﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ball2d : MonoBehaviour {

	public float forceX=5, forceY=575, forceZ=0;

	int shootingDirection=1;
	Rigidbody2D ballBody;

	public static int SCORE, POT_SCORE=2,STAR_COUNT;

	[SerializeField]
	private GameObject collider1,collider2,shredder,potMarker,deactivateTriggers,activateTrigger;

	[SerializeField]
	private SpriteRenderer backgroundOfHoop,hoop;

	[SerializeField]
	private GameObject shadow;


	public static bool isActiveColliders,initAgain,isShooting;

	private Color start,end;
	
	float duration = 0.7f,t = 0.0f,timeDivider = 0.5f;

	Touch initialTouch = new Touch();

	CircleCollider2D circleCollider;
	SpriteRenderer sprite;

	void Awake(){

		//TODO TAKE FROM PREFS
		STAR_COUNT = 0;

		isActiveColliders = false;
		initAgain = false;
		isShooting = false;
		sprite = gameObject.GetComponent<SpriteRenderer> ();
		circleCollider = gameObject.GetComponent<CircleCollider2D> ();

		start = gameObject.GetComponent<SpriteRenderer>().material.color;
		end = new Color (start.r,start.g,start.b,0.0f);
	}//awake
	
	void Start () {
		Time.timeScale = 2f;
		ballBody = gameObject.GetComponent<Rigidbody2D> ();
	}//start

	/*BUTTON CONTROLS START*/

	public void ShootDefault(){
		isShooting = true;
		float randomX = Random.Range (-5,5);
		ballBody.AddForce(new Vector2(randomX,575));
	}//shoot

	public void Reset(){
		//Application.LoadLevel(Application.loadedLevel);
		SceneManager.LoadScene ( SceneManager.GetActiveScene ().buildIndex );
	}//reset
	
	/*BUTTON CONTROLS END*/


	void SetColliders(bool act){
		collider1.SetActive (act);
		collider2.SetActive (act);
		potMarker.SetActive (act);
		deactivateTriggers.SetActive (act);

		activateTrigger.SetActive (!act);

		if (act) {
			///Debug.Log ("acting");
			hoop.sortingOrder = 2;
			//backgroundOfHoop.sortingOrder = (hoop.sortingOrder - 1);
		} else {
			//Debug.Log ( "not acting" );
			hoop.sortingOrder = -1;
			//backgroundOfHoop.sortingOrder = (hoop.sortingOrder - 1);
		}
	}//activateColliders

	void Shoot(float fX, float fY){
		isShooting = true;
        ballBody.freezeRotation = false;
		ballBody.AddForce(new Vector2(fX,fY));
	}//shoot


	void ReinitializeBall(){
		POT_SCORE = 2;
		shadow.SetActive (true);
		circleCollider.enabled = true;
		sprite.sortingOrder = 0;
		sprite.material.color = start;

		float randomXPos = Random.Range (-2.0f,2.0f);
		transform.position = new Vector3 (randomXPos,-3.62f,transform.position.z);
		shadow.transform.position = new Vector2(randomXPos,shadow.transform.position.y);
		ballBody.velocity = Vector2.zero;
        ballBody.freezeRotation = true;
		
		transform.rotation = Quaternion.Euler(0,0,0);
		transform.localScale = new Vector2(0.75f,0.75f);
	}//ball
	
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space))
		{
			ShootDefault ();
		}

		if (isShooting) {
			Vector3 currentSize = transform.localScale;
			currentSize.x -= Time.deltaTime * 0.5f;
			if (currentSize.x <= 0.45f) {
				currentSize.x = 0.45f;
			}
			currentSize.y = currentSize.x;
			transform.localScale = currentSize;
		}

		// Rotation Controll
		if(ballBody.velocity.y>0.0f){
			var rot = transform.rotation;
			transform.rotation = rot * Quaternion.Euler(0, 0, Time.deltaTime*250*shootingDirection);
		}

		if(transform.position.y > 1.5f){
			var rot = transform.rotation;
			transform.rotation = rot * Quaternion.Euler(0, 0, Time.deltaTime*250*shootingDirection);
		}

		//shadow Control
		if(transform.position.y > -3.1f){
			shadow.SetActive(false);
		}


		if(initAgain){
			gameObject.GetComponent<CircleCollider2D>().enabled = false;
			gameObject.GetComponent<SpriteRenderer>().sortingOrder = -2;
			t += Time.deltaTime;
			gameObject.GetComponent<SpriteRenderer>().material.color = Color.Lerp (start, end, (t/timeDivider));
			if(gameObject.GetComponent<SpriteRenderer> ().material.color.a <=0){
				ReinitializeBall();
				initAgain = false;
				t = 0;
			}else {
				return;
			}
		}

		SetColliders ( isActiveColliders );

		// swipe controller
		foreach (Touch t in Input.touches){
			Debug.Log ("touch " + t.phase);
			if(t.phase == TouchPhase.Began){
				initialTouch = t;
			} else if (t.phase == TouchPhase.Ended){
				float deltaX = initialTouch.position.x - t.position.x;
				float deltaY = Mathf.Abs(initialTouch.position.y - t.position.y);
				Debug.Log ("delta " + deltaY);
				if(deltaY<50 || (initialTouch.position.y > t.position.y)){ continue; } // don't need to check further, too small swipe or reverse swipe
				
				forceX = Mathf.Abs(deltaX)*0.65f;
				forceY = 575f;
				if(deltaX < 0){
					//swiping left to right
					shootingDirection = 1;
					Shoot(forceX,forceY);
				} else if (deltaX >= 0){
					//swiping right to left
					shootingDirection = -1;
					Shoot(-forceX,forceY);
				}
				initialTouch = new Touch();
			}//if
		}//foreach

		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}
	}//update
}
