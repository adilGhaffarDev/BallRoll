using UnityEngine;
using System.Collections;

public class moveScript : MonoBehaviour {


	/// <summary>
	/// Scrolling speed
	/// </summary>
	public Vector2 speed = new Vector2(10, 10);
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(0,1);
	


	Vector3 movement;
	
	/// <summary>
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Movement
		movement = new Vector3(
			speed.x * direction.x,
			speed.y * direction.y,
			0);
		
	//	movement *= Time.deltaTime;
//	transform.Translate(movement);
	
	}
	void FixedUpdate()
	{
		// 5 - Move the game object
		GetComponent<Rigidbody2D>().velocity = movement;
		
	}
}
