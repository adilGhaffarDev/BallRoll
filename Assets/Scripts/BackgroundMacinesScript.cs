using UnityEngine;
using System.Collections;

public class BackgroundMacinesScript : MonoBehaviour {

	public GameObject c1,c2;
	// Use this for initialization
	void Start () {
		StartCoroutine ("SpawnWaves");
	
	}

	IEnumerator SpawnWaves ()
	{
		

		yield return new WaitForSeconds (1);
		while (true)
		{
			int rand = Random.Range (1, 10);
			if(rand>5)
			{
				Vector3 spawnPosition = new Vector3 (-5f, 17f, 0f);
				
				Quaternion spawnRotation = Quaternion.identity;
				GameObject tempC1 = Instantiate (c1, spawnPosition, spawnRotation)as GameObject;
				Destroy(tempC1,20);
			}
			else
			{
				Vector3 spawnPosition = new Vector3 (6.7f, 19f, 0f);
				
				Quaternion spawnRotation = Quaternion.identity;
				GameObject tempC2 = Instantiate (c2, spawnPosition, spawnRotation)as GameObject;
				Destroy(tempC2,20);
			}
			yield return new WaitForSeconds (20);
		}

	}

}
