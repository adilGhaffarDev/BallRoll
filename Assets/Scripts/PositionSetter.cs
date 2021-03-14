using UnityEngine;
using System.Collections;

public class PositionSetter : MonoBehaviour {


	public float screenW;
	public float screenH;
	public float leftBorder;
	public float rightBorder;
	public float topBorder;
	public float bottomBorder;
	public GameObject top;
	public GameObject bottom;
	public GameObject right;
	public GameObject left;
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
		
		bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist1)
			).y;
		
		topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist1)
			).y;

		left.transform.position =  new Vector3(leftBorder,0,0);
		right.transform.position =  new Vector3(rightBorder,0,0);
		bottom.transform.position =  new Vector3(0,bottomBorder,0);
		top.transform.position =  new Vector3(0,topBorder,0);

	}
	

}
