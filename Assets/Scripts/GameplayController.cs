using UnityEngine;
using System.Collections;

public class GameplayController : MonoBehaviour {

	void Start () {
	
		/*TODO DEBUG */
		GamePrefs.SetSoundSetting(1);
		GamePrefs.SetMusicSetting(1);
		GamePrefs.SetHighscore(10);
	}//start
	
}//gameplayController
