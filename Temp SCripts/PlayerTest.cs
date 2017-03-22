using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour {

	
	//WORKING PASS IT TO PLAYER LOGIC SCRIPT
	void OnTriggerEnter(Collider col){
		if (col.name == "Bullet(Clone)"){
			Debug.Log("hit");
		}
		Debug.Log("HEY");

	
	}

}
