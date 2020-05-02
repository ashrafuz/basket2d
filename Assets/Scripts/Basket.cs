using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {


	private int directionX = 1,directionY = 1;
	private float speed=0.9f;
	private Vector3 startPos;
	
	void Start () {
		startPos = transform.position;
	}//start


	void Move(){
		Vector3 currentPosition = transform.position;
		if (currentPosition.x > 1.24f)
			directionX = -1; // go left
		else if (currentPosition.x < -1.24f)
			directionX = 1; //go right

		if (currentPosition.y > 1.24f)
			directionY = -1; // go down
		else if (currentPosition.y < -1.24f)
			directionY = 1; //go up

		if (Ball2d.SCORE > 10 && Ball2d.SCORE < 25) {
			speed = 0.5f;
		} else if (Ball2d.SCORE > 24 && Ball2d.SCORE < 50) {
			speed = 0.8f;
		} else {
			speed = 1.0f;
		}
		speed = Random.Range((speed-0.1f) , (speed+0.1f));
		currentPosition.x += directionX * Time.deltaTime * speed;
		if(Ball2d.SCORE > 25){
			speed = Random.Range((speed-0.15f) , (speed+0.15f));
			currentPosition.y += directionY * Time.deltaTime * speed;
		}
		transform.position = currentPosition;
	}//move

	void FixedUpdate () {
		if (Ball2d.SCORE > 3) {
			Move ();
		} else {
			transform.position = startPos;
		}
	}//update
}//basket
