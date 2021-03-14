using UnityEngine;
using System.Collections;


public enum ItemTypes
{
	Health, 
	FlipControls, 
	FlipScreen,
	Slow,
	Fast,
	InstantKill,
	Dizzy
}
public class PickUpItemScript : MonoBehaviour {



	public ItemTypes CurrentType;
	// Use this for initialization

	void Awake ()
	{
		switch (CurrentType) 
		{
		case ItemTypes.Health:
		{

		}
			break;
		case ItemTypes.FlipControls:
		{
				
		}
			break;
		}
	}


	void Update()
	{

		if (GetComponentInChildren<Renderer> ().IsVisibleFrom (Camera.main) == false) {

			Destroy (gameObject);

		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		string colliderName = collision.gameObject.name;
		string currnetBallName = GameObject.Find("Bars").GetComponent<RandomBars>().ball.name;
		if (colliderName == currnetBallName) {
			switch (CurrentType) {
			case ItemTypes.Health:
			{
				GameObject.Find ("Player").GetComponent<PlayerScript> ().ItemPickedUp(transform.position,CurrentType);
				Destroy(gameObject);
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


}
