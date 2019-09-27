using UnityEngine;
using System.Collections;

public class Hoop : MonoBehaviour {

	[SerializeField]
	private AudioClip[] sounds;

	void OnCollisionEnter2D(Collision2D target){
		if(target.gameObject.tag == "ball"){
			int randomSound = Random.Range(0,100) % 4;
			if(GamePrefs.GetSoundSetting() != 0){
				Debug.Log("Sound should be played here");
				AudioSource.PlayClipAtPoint(sounds[randomSound],transform.position);
			}
			Ball2d.POT_SCORE = 1;
		}
	}//onCollisionEnter2D
}
