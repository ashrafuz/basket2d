using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target){
		if(target.gameObject.tag == "ball"){
			Destroy(target.gameObject);
		}
	}//ontriggerenter2d
}
