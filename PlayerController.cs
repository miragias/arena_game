using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float inputx;
	private float inputz;
	public float mouseInput;
	private bool jump;

	[SerializeField]
	[Range(0.0f, 1000.0f)]
	private float jumpStrength =10;

	Rigidbody rb;

	[SerializeField]
	[Range(0.0f,0.2f)]
	private float speed = 0.1f;
	[SerializeField]
	private Quaternion deltaRot;
	[Range(-1f,1f)]
	public float angleFix;
	public float an;

	Vector2 positionOnScreen;
	Vector2 mouseOnScreen;

	void Start () {
		rb = GetComponent<Rigidbody>();
		Cursor.visible = false;
	}
	
	void Update () {
		//Get Input
		inputx = Input.GetAxis("Horizontal");
		inputz = Input.GetAxis("Vertical");
		if (Input.GetKeyDown(KeyCode.Space)){
			jump = true;
		}
		//Get the angle between camera and mouse pointer
		positionOnScreen = Camera.main.WorldToViewportPoint( transform.position);
		mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		//Calculate it and ass it so player rotates
		an = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
		transform.rotation = Quaternion.Euler (new Vector3(0f,an+90,0f));
		
	}

	float AngleBetweenTwoPoints(Vector3 a , Vector3 b){
		return Mathf.Atan2(a.x - b.x , a.y - b.y) * Mathf.Rad2Deg;
	}


	void FixedUpdate(){
		//Move based on input
		rb.MovePosition(transform.position +new Vector3(-inputz,0,inputx) * speed);

		//Jump
		if(jump){
			jump = false;
			rb.AddForce(transform.up * jumpStrength);
		}

	}

}
