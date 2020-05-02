using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	[SerializeField]
	private Text scoreText,starText;
	public static bool ANIMATE = false;

	private int sizeToChange = -10;
	private int initialSize = 160;
	
	
	void Awake(){
		initialSize = scoreText.fontSize;
	}//awake
	
	void Start () {
		scoreText.text = "0";
		starText.text =  "x" + Ball2d.STAR_COUNT;
		scoreText.fontSize = initialSize;
	}//start


	IEnumerator HoldFor(){
		scoreText.fontSize += sizeToChange;
		//Debug.Log ("size of text " + scoreText.fontSize);
		yield return new WaitForSeconds (0.01f);
		if(scoreText.fontSize <= 0){
			sizeToChange = 10;
			scoreText.text = ""+Ball2d.SCORE;
			StartCoroutine("HoldFor");
		} else if (scoreText.fontSize > (initialSize+2)){
			scoreText.text = ""+Ball2d.SCORE;
		} else {
			StartCoroutine("HoldFor");
		}
	}//hold for

	void StartAnimation(){
		sizeToChange = -10;
		StopCoroutine ("HoldFor");
		StartCoroutine ("HoldFor");
	}//startanimation

	void Update () {
		starText.text = Ball2d.STAR_COUNT + "";

		if(ANIMATE){
			StartAnimation();
			ANIMATE = false;
		}

	}//update
}//UI_CONTROLLER
