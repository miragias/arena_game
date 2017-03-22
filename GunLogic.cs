using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour {
	public GameObject bullet;
	private GameObject bulletStart;
	public GameObject playerBullet;
	public GameObject playerBulletContainer;
	[SerializeField]
	private int maxBullets = 3;

	public int currentBulletsShooting = 0;
	public LineRenderer lr;


	void Start () {
		bulletStart = transform.FindChild("GunEdge").gameObject;
		playerBulletContainer = new GameObject();
		playerBulletContainer.name = "PlayerXBullets";
		playerBulletContainer.layer = 8;
		playerBulletContainer.transform.parent = null;
		lr =gameObject.GetComponent<LineRenderer>();
	}
	
	void Update () {
		//If User presses left button shoot
		if (Input.GetMouseButtonDown(0) && playerBulletContainer.transform.childCount< maxBullets){
			playerBullet = Instantiate(bullet, bulletStart.transform.position, bulletStart.transform.rotation);
			playerBullet.layer = 8;
			//playerBullet.name = "P1_bullet";
			playerBullet.transform.parent = playerBulletContainer.transform;
			currentBulletsShooting++;
		}


		//Debug ray and add it to game mode
		Ray r = new Ray(transform.position, transform.forward);
		Debug.DrawRay(r.origin, r.direction * 10, Color.blue);
		lr.SetPosition(0, transform.localPosition);
		lr.SetPosition(1, transform.InverseTransformVector(transform.forward)* 10);
	}

}
