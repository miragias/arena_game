using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour {
	float timeAlive;
	[Range(0.0f, 20f)]	
	public float bulletDeadTimer =5f;
	[Range(0.0f , 30f)]
	public float bulletSpeed;

	//Moves the bullet constantly forward and destroys it after a few seconds.
	void Start () {
		timeAlive = 0f;
	}
	
	void Update () {
		transform.Translate(Vector3.up * Time.deltaTime* bulletSpeed );
		timeAlive += Time.deltaTime;
		if (timeAlive>=bulletDeadTimer){
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter (Collision bullethit){
		if(bullethit.gameObject.tag == "Player"){
			Destroy(gameObject);
		}
	}

	/*
	void RemoveBulletFromPlayer(){
		//Understand from which player the bullet comes from
		string playerNumb = gameObject.name.Substring(1,1);
		int playerNumber = int.Parse(playerNumb);

		//Find the player in the hirierachy
		playerNumb = "Player" + playerNumber.ToString();
		Debug.Log(GameObject.FindWithTag("Player


	}
	*/

}
