using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {


	Vector2 movement;
	public Vector2 speed = new Vector2(25, 25);
	//bool jump = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	//	#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_METRO
		float inputX = Input.GetAxis("Horizontal");
//		float inputY = Input.GetAxis("Vertical");
		//if(inputY>0)
		//{
		//	jump = true;
		//}
		// 4 - Movement per direction
	//	if(inputX>0 || inputX<0)
		//GetComponent<Rigidbody2D>().AddForce(Vector3.down*10,ForceMode2D.Force);


		movement = new Vector2(
			speed.x * inputX ,
			GetComponent<Rigidbody2D>().velocity.y);
//		#endif
		var dist1 = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist1)
			).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist1)
			).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist1)
			).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist1)
			).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);

	
	}
	void FixedUpdate()
	{
		// 5 - Move the game object

		/*if (jump) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, 600));
			jump = false;

		} else */
		{
			GetComponent<Rigidbody2D>().velocity = movement;
		}
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		string colliderName = collision.gameObject.name;
		switch (colliderName) 
		{
			case "middle(Clone)":
			{
				GameObject.Find ("Player").GetComponent<PlayerScript> ().score++;
				break;
			}
			case "spikeKill(Clone)":
			{
				GameObject.Find ("Player").GetComponent<PlayerScript> ().Respawn();
				break;
			}
			case "TopWall":
			{
				GameObject.Find ("Player").GetComponent<PlayerScript> ().Respawn();
				break;
			}
			case "BottomWall":
			{
				GameObject.Find ("Player").GetComponent<PlayerScript> ().Respawn();
				break;
			}

		}
	}

}
