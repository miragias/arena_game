using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurnBarrel : MonoBehaviour {

	public int turnspeed = 50;
	public bool rolling = true;
	public BarrelMovement bm;
	public ColliderCheck cc;
	public NavMeshAgent nm;

	// Update is called once per frame
	void Update () {
		if(transform.rotation.eulerAngles.x >0f && !rolling){
			transform.rotation = Quaternion.RotateTowards(transform.rotation , Quaternion.Euler(0,90,0), turnspeed * Time.deltaTime);
		}
		if(transform.rotation.eulerAngles.x<0.01f && GetComponent<ColliderCheck>().reachedWater)
		{
			nm.enabled = true;
			bm.enabled = true;
			Debug.Log("h");
			gameObject.GetComponent<TurnBarrel>().enabled=false;

		}

		
	}
}
