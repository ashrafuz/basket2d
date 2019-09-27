using UnityEngine;
using System.Collections;

public class ActivateTrigger : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D target){
		if(target.gameObject.tag == "ball"){
			Ball2d.isActiveColliders = true;
			Ball2d.isShooting = false;

			DeactivateTrigger.SAVE_SCORE = Ball2d.SCORE;
		}
	}//onTriggerEnter2d
}//class
