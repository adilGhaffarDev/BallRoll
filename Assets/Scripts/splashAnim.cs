using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class splashAnim : MonoBehaviour {

	public GameObject mage;
	public GameObject eyeL;
	public GameObject eyeR;
	public GameObject nose;
	public GameObject mouth;
	public GameObject face;
	//public List<GameObject> splashes; 

	void Start () {
		StartCoroutine("startSplashAnim");
		
	}

	IEnumerator startSplashAnim()
	{
		yield return new WaitForSeconds (.5f);
		iTween.ScaleTo (face, iTween.Hash ("scale",new Vector3( 1,1,1), "time", .7f,"easetype",iTween.EaseType.easeOutElastic));
		yield return new WaitForSeconds (.7f);
		iTween.ScaleTo (eyeL, iTween.Hash ("scale",new Vector3( 1,1,1), "time", .7f,"easetype",iTween.EaseType.easeOutElastic));
		iTween.ScaleTo (eyeR, iTween.Hash ("scale",new Vector3( 1,1,1), "time", .7f,"easetype",iTween.EaseType.easeOutElastic));
		yield return new WaitForSeconds (.7f);
		iTween.ScaleTo (mouth, iTween.Hash ("scale",new Vector3( 1,1,1), "time", .7f,"easetype",iTween.EaseType.easeOutElastic));
		yield return new WaitForSeconds (.7f);
		iTween.ScaleTo (nose, iTween.Hash ("scale",new Vector3( 1,1,1), "time", .7f,"easetype",iTween.EaseType.easeOutElastic));
		yield return new WaitForSeconds (.7f);
		iTween.ScaleTo (mage, iTween.Hash ("scale",new Vector3( 1,1,1), "time", .7f,"easetype",iTween.EaseType.easeOutElastic));
		yield return new WaitForSeconds (.7f);

//		foreach(GameObject s in splashes)
//		{
//			//iTween.ScaleTo (s, iTween.Hash ("scale",new Vector3( 1,1,1), "time", .5f,"easetype",iTween.EaseType.easeInQuint));
//			//yield return new WaitForSeconds (.5f);
//		}
	}
	
}
