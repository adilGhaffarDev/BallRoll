using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public int lives = 2;
	public Sprite blackHeart;
	public Sprite redHeart;
	public List<GameObject> livesTex;
	public int score;
	public GameObject scoreLabel;
	public GameObject highScoreLabel;
	//public GameObject livesLabel;
	public GameObject ball;
	public GameObject ballKillParticle;

	// Use this for initialization
	void Start () 
	{
		lives = 2;
		score = 0;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		scoreLabel.GetComponent<Text> ().text = score.ToString();
		//livesLabel.GetComponent<Text> ().text = lives.ToString();
		//if(lives == 0)
		//{
		//	Destroy(ball);
		//}
	
	}
	public void Respawn()
	{
		if (lives >= 0 && lives<=4) {
			livesTex [lives].GetComponent<Image> ().sprite = blackHeart;
			lives--;
		}
		Vector3 particlePos = GameObject.Find ("Bars").GetComponent<RandomBars> ().ball.transform.position;
		Quaternion spawnRotation = Quaternion.identity;
		GameObject tempParticle = (GameObject)Instantiate (ballKillParticle, particlePos, spawnRotation);
		Destroy(tempParticle,2);
		Destroy(GameObject.Find ("Bars").GetComponent<RandomBars> ().ball);
		GameObject.Find ("Bars").GetComponent<RandomBars> ().spawnBallToo = true;

	}

	public void ItemPickedUp(Vector3 pos, ItemTypes type)
	{
		switch (type) {
		case ItemTypes.Health:
		{
			if(lives<4)
			{
				lives++;
				livesTex [lives].GetComponent<Image> ().sprite = redHeart;
			}
			score += 10;
			Quaternion spawnRotation = Quaternion.identity;
			GameObject tempParticle = (GameObject)Instantiate (ballKillParticle, pos, spawnRotation);
			Destroy(tempParticle,2);
			break;
		}
		case ItemTypes.FlipControls:
		{
			break;
		}
		case ItemTypes.FlipScreen:
		{
			break;
		}
		case ItemTypes.Fast:
		{
			break;
		}
			
		}
	}
	
}
