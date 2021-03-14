using UnityEngine;
using System.Collections;

public class checkthings : MonoBehaviour {

	public float screenW;
	public float screenH;
	public float leftBorder;
	public float rightBorder;
	public float topBorder;
	public float bottomBorder;

	// Use this for initialization
	void Start () {
		screenW = Screen.width;
		screenH = Screen.height;

		var dist1 = (transform.position - Camera.main.transform.position).z;
		
	   leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist1)
			).x;
		
		 rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist1)
			).x;
		
		 topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist1)
			).y;
		
		 bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist1)
			).y;

		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
