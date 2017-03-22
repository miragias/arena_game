using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	public ArrayLayout data;
	public string hello;
	public int killme;
	
	void Start(){
		Debug.Log(data.rows[1].column[0]);
		Debug.Log(data.rows[0].column[1]);
		
		
	}
		
}
