using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomBars : MonoBehaviour {


	/// <summary>
	/// Scrolling speed
	/// </summary>
	public Vector2 speed = new Vector2(10, 10);
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(0,-1);
	
	/// <summary>
	/// Movement should be applied to camera
	/// </summary>
	public bool isLinkedToCamera = false;
	
	/// <summary>
	/// 1 - Background is infinite
	/// </summary>
	public bool isLooping = false;
	
	/// <summary>
	/// 2 - List of children with a renderer.
	/// </summary>

	public GameObject middle;
	public GameObject side;
	public GameObject spike;
	public List<Transform> bars;
	public float leftBorder;
	public float rightBorder;
	public float topBorder;
	public float bottomBorder;
	public bool spawnBallToo = true;
	public GameObject ballPrefab;
	public GameObject ball;
	public GameObject pickUpItemPrefab;
	GameObject pickUpItem;
	//public GameObject ballKillParticle;


	// Use this for initialization
	void Start () 
	{
		bars = new List<Transform>();
		var dist1 = (transform.position - Camera.main.transform.position).z;


		 leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist1)
			).x;
		
		 rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist1)
			).x;

		 bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist1)
			).y;
		
		 topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist1)
			).y;
		float i = bottomBorder;
		while(i<topBorder-2)
		{
			float randd = Random.Range (leftBorder+1,rightBorder-1);
			//if(rand1<8)
			{
				Vector3 spawnPosition = new Vector3 (randd,i, dist1);
				Quaternion spawnRotation = Quaternion.identity;
				GameObject temp = (GameObject)Instantiate (middle, spawnPosition, spawnRotation);
				bars.Add(temp.transform);
				if(spawnBallToo)
				{
					if(ball!=null)
						Destroy(ball);
					ball = (GameObject)Instantiate (ballPrefab, new Vector3 (randd,i+0.5f, dist1), spawnRotation);
					spawnBallToo = false;
				}
			}

			i = i+2.0f;
		}
		bars = bars.OrderByDescending(
			t => t.position.y
			).ToList();
	
	}
	
	// Update is called once per frame
	void Update () {

		// Movement
		Vector3 movement = new Vector3(
			speed.x * direction.x,
			speed.y * direction.y,
			0);
		
		movement *= Time.deltaTime;
		transform.Translate(movement);
		
		// Move the camera
		if (isLinkedToCamera)
		{
			Camera.main.transform.Translate(movement);
		}
		
		// 4 - Loop
		if (isLooping)
		{
			// Get the first object.
			// The list is ordered from left (x position) to right.
			Transform firstChild = bars.FirstOrDefault();

			if (firstChild != null)
			{
				// Check if the child is already (partly) before the camera.
				// We test the position first because the IsVisibleFrom
				// method is a bit heavier to execute.
				if (firstChild.position.y > Camera.main.transform.position.y)
				{
					// If the child is already on the left of the camera,
					// we test if it's completely outside and needs to be
					// recycled.
					if (firstChild.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
					{
						// Get the last child position.
						Transform lastChild = bars.LastOrDefault();
//						Vector3 lastPosition = lastChild.transform.position;
//						Vector3 lastSize = (lastChild.GetComponent<Renderer>().bounds.max - lastChild.GetComponent<Renderer>().bounds.min);
						
						// Set the position of the recyled one to be AFTER
						// the last child.
						// Note: Only work for horizontal scrolling currently.
						//firstChild.position = new Vector3(firstChild.position.x, -11, firstChild.position.z);
						Destroy(firstChild.gameObject);
						// Set the recycled child to the last position
						// of the backgroundPart list.
						bars.Remove(firstChild);
				//		bars.Add(firstChild);


						var dist1 = (transform.position - Camera.main.transform.position).z;
						float i = lastChild.position.y - 2;
							//int randd = Random.Range (1,4);
						int rand1 = Random.Range (1,11);
						float randd = Random.Range (leftBorder+1,rightBorder-1);
						if(rand1<8)
						{
							Vector3 spawnPosition = new Vector3 (randd,i, dist1);
							Quaternion spawnRotation = Quaternion.identity;
							GameObject temp = (GameObject)Instantiate (middle, spawnPosition, spawnRotation);
							bars.Add(temp.transform);
							if(spawnBallToo)
							{
								if(ball!=null)
								{
									//Vector3 particlePos = ball.transform.position;
									//GameObject tempParticle = (GameObject)Instantiate (ballKillParticle, particlePos, spawnRotation);
									//Destroy(tempParticle,2);
									Destroy(ball);
								}
								ball = (GameObject)Instantiate (ballPrefab, new Vector3 (randd,i+0.5f, dist1), spawnRotation);
								spawnBallToo = false;
							}
							else
							{
								int randForPickUpItem = Random.Range (1,11);
								if(randForPickUpItem<6)
								{
									pickUpItem = (GameObject)Instantiate (pickUpItemPrefab, new Vector3 (randd,i+0.5f, dist1), spawnRotation);
								}
							}
						}
						else
						{
							Vector3 spawnPosition = new Vector3 (randd,i, dist1);
							Quaternion spawnRotation = Quaternion.identity;
							GameObject temp = (GameObject)Instantiate (spike, spawnPosition, spawnRotation);
							bars.Add(temp.transform);
						}
						/*switch (randd) 
							{
								
							case 1:
							{
								Vector3 spawnPosition = new Vector3 (0.0f,i, dist1);
								Quaternion spawnRotation = Quaternion.identity;
								GameObject temp = (GameObject)Instantiate (middle, spawnPosition, spawnRotation);
								bars.Add(temp.transform);
								break;
							}
							case 2:
							{
								Vector3 spawnPosition = new Vector3 (leftBorder + 1.0f,i, dist1);
								Quaternion spawnRotation = Quaternion.identity;
								GameObject temp = (GameObject)Instantiate (side, spawnPosition, spawnRotation);
								bars.Add(temp.transform);
								break;
							}
							case 3:
							{
								Vector3 spawnPosition = new Vector3 (rightBorder - 1.0f,i, dist1);
								Quaternion spawnRotation = Quaternion.identity;
								GameObject temp = (GameObject)Instantiate (side, spawnPosition, spawnRotation);
								bars.Add(temp.transform);
								break;
							}
								//	GameObject.Find("ShakeCamera").GetComponent<ShakeCamera>().Shake();
								
								
							}*/


					}
				}
			}
		}
	}
	



}
