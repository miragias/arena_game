using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ColliderCheck : MonoBehaviour {

	public BarrelMovement bm;
	public NavMeshAgent nm;
	public bool reachedWater= false;
	public MeshCollider platform;
	TurnBarrel turnbarrelscript;
	void OnTriggerEnter(Collider col){

		Debug.Log(col);
		gameObject.GetComponent<Rigidbody>().isKinematic = true;
		gameObject.GetComponent<Collider>().isTrigger =true;
		gameObject.GetComponentInChildren<MeshCollider>().convex = false;
		turnbarrelscript.rolling = false;
		reachedWater = true;
		platform.enabled = true;
		//Make the collider trigger it no longer needs physics
	}

	void Start(){
		turnbarrelscript = gameObject.GetComponent<TurnBarrel>();
		nm = GetComponent<NavMeshAgent>();
		bm = GetComponent<BarrelMovement>();
	}

}
