using UnityEngine;
using System.Collections;

public class Pointers : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DestroyItself",2.0f);
	}

	void DestroyItself(){
		Destroy (gameObject);
	}
}
