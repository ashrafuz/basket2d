using UnityEngine;
using System.Collections;

public class GamePrefs : MonoBehaviour {

	public static string SOUND_ON_OR_OFF_KEY =  "sound_option_key";
	public static string HIGHSCORE_KEY = "high_score_key";
	public static string MUSIC_ON_OR_OFF_KEY  = "music_option_key";
	
	
	/*--------- GETTERS ----------- */
	public static int GetSoundSetting(){
		return PlayerPrefs.GetInt(GamePrefs.SOUND_ON_OR_OFF_KEY);
	}//getSoundSetting
	
	public static int GetMusicSetting(){
		return PlayerPrefs.GetInt(GamePrefs.MUSIC_ON_OR_OFF_KEY);
	}//getMusicSetting
	
	public static int GetHighscore(){
		return PlayerPrefs.GetInt(GamePrefs.HIGHSCORE_KEY);
	}//getHighScore
	
	/*--------- SETTERS----------- */
	public static void SetSoundSetting(int value){
		PlayerPrefs.SetInt(GamePrefs.SOUND_ON_OR_OFF_KEY, value);
	}//SetSoundSetting
	
	public static void SetMusicSetting(int value){
		PlayerPrefs.SetInt(GamePrefs.MUSIC_ON_OR_OFF_KEY,value);
	}//SetMusicSetting
	
	public static void SetHighscore(int score){
		PlayerPrefs.SetInt(GamePrefs.HIGHSCORE_KEY,score);
	}//SetHighScore
}
