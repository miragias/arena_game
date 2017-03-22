using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBarrel : MonoBehaviour {

	public ParticleSystem barrelExplosion;
	public LayerMask ignoreMask;
	public Collider barrelPlatform;
	// Use this for initialization
	void OnTriggerEnter(Collider col){


		if(col.name == "Bullet(Clone)"){
			barrelPlatform.enabled = false;
			Destroy(col.gameObject);
			barrelExplosion.Play();
			gameObject.GetComponent<Renderer>().enabled = false;
			gameObject.GetComponent<Collider>().enabled = false;
			Destroy(transform.root.gameObject, 5f);
			Collider[] playersHit = Physics.OverlapSphere(transform.position , 8f , ignoreMask); 

			foreach (Collider colid in playersHit){
				Debug.Log(colid);
				Debug.Log(colid.gameObject.name);
				Destroy(colid.gameObject.transform.root.gameObject);
			}

		}

	}


	/*
	void OnDrawGizmos(){
		Gizmos.color = Color.black;
		Gizmos.DrawSphere(transform.position , 8f);
	}
	*/
}
