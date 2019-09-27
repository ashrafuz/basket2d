using UnityEngine;
using System.Collections;

public class PotMarker : MonoBehaviour {

	[SerializeField]
	private GameObject onePointer,twoPointer,star;
	
	[SerializeField]
	private AudioClip potSound;

	void OnTriggerEnter2D(Collider2D target){
		if(target.gameObject.tag == "ball"){
			if(GamePrefs.GetSoundSetting() != 0){
				Debug.Log("during sound");
				AudioSource.PlayClipAtPoint(potSound,transform.position);
			}
			//Debug.Log("After sound ");
			Ball2d.SCORE += Ball2d.POT_SCORE;
			UIController.ANIMATE = true;
			if(Ball2d.POT_SCORE==2){
				Instantiate(twoPointer);
			} else {
				Instantiate(onePointer);
			}
		}
	}//ontriggerEnter2D

}//class
