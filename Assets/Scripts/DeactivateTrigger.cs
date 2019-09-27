using UnityEngine;
using System.Collections;

public class DeactivateTrigger : MonoBehaviour {

	public static int SAVE_SCORE = 0;

	void OnTriggerEnter2D(Collider2D target){
		if(target.gameObject.tag == "ball"){
			Ball2d.isActiveColliders = false;
			Ball2d.initAgain = true;

			if(Ball2d.SCORE <= SAVE_SCORE ){
				//Debug.Log("Play Again");
				Ball2d.SCORE = 0;
				UIController.ANIMATE = true;
			} else {
				Debug.Log("Continue");
			}
		}
	}//onTriggerEnter2D
}
