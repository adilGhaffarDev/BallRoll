using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffeectsManager : MonoBehaviour {

	public GameObject prefabGO;

	GameObject tempGo;

	public GameObject winParticle;
	GameObject tempWinParticle;

	public GameObject hotSpotParticle;
	GameObject tempHotSpotParticle;

	public static EffeectsManager instance = null;
	
	
	void Awake () {
		if (instance == null) { 	//making sure we only initialize one instance.
			instance = this;
			GameObject.DontDestroyOnLoad (this.gameObject);
		} else {					//Destroying unused instances.
			GameObject.Destroy (this.gameObject);
		}

		
	}
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	public void moveBezierGlobal(GameObject targett,GameObject startt)
	{
		StartCoroutine(moveBezier(targett,startt));
	}

	IEnumerator moveBezier(GameObject targett,GameObject startt)
	{
		//SoundManager.instance.playCoinsSound();
		Vector3 middle = (targett.transform.position + startt.transform.position) * .5f;
		middle.y = middle.y + .5f;

		middle.z = prefabGO.transform.position.z;
		List<Vector3> pathNodes = new List<Vector3> ();
		pathNodes.Add (startt.transform.position);
		pathNodes.Add (middle);
		pathNodes.Add (targett.transform.position);

		for (int i = 0; i<10 ; i++) {
			GameObject tempoGo = Instantiate (prefabGO, startt.transform.position, Quaternion.identity) as GameObject;
			//Vector3[] pathnodes = new Vector3[3]();
			//pathnodes =	iTweenPath.GetPath(path);
			//pathnodes [0] = startt.transform.position;
			//pathnodes [2] = targett.transform.position;
		//	Destroy(tempoGo,5);
		//	Debug.Log ("ite: " + i);
			//iTweenPath.GetPath(path)[0] = startt.transform.position;
			//iTweenPath.GetPath(path)[1] = targett.transform.position;
		//	iTween.MoveTo (tempGo, iTween.Hash ("path", pathNodes.ToArray (), "time", 5));

			StartCoroutine(bex(tempoGo,pathNodes.ToArray ()));
			yield return new WaitForSeconds(.1f);
		}
		yield return new WaitForSeconds(2);
	}

	IEnumerator bex(GameObject g, Vector3[] v )
	{
		iTween.MoveTo (g, iTween.Hash ("path", v, "time", 1,"easetype",iTween.EaseType.easeInOutCirc));
		yield return new WaitForSeconds(1);
		Destroy (g);
	}

	public void punchInOut(GameObject gg)
	{
	//	Vector3 baseScale = gg.transform.localScale;
		iTween.PunchScale (gg,new Vector3 (.5f, .5f, 0), 2);
		//	yield return new WaitForSeconds(2);
		//	iTween.PunchScale (gg, baseScale, 2);
	}

	public void punchInOutRepeat(GameObject gg)
	{
		//	Vector3 baseScale = gg.transform.localScale;
		iTween.PunchScale (gg,iTween.Hash ("amount", new Vector3 (.2f, .2f, 0), "looptype","loop","time", 2,"easetype",iTween.EaseType.easeInBounce));

		//	yield return new WaitForSeconds(2);
		//	iTween.PunchScale (gg, baseScale, 2);
	}

	public void winParticleFun(GameObject pos)
	{
		tempWinParticle = Instantiate (winParticle,new Vector3( pos.transform.position.x,pos.transform.position.y,winParticle.transform.position.z), Quaternion.identity) as GameObject;
		Destroy(tempWinParticle,2);
	}

	public void hotSpotParticleFun(GameObject pos)
	{
		tempHotSpotParticle = Instantiate (hotSpotParticle, new Vector3( pos.transform.position.x,pos.transform.position.y,hotSpotParticle.transform.position.z), Quaternion.identity) as GameObject;
		Destroy(tempHotSpotParticle,2);
	}
//	public Vector3[] MakePath(Vector3 startNode,Vector3 endNode)
//	{
//		
//		var v3New = new Vector3[endNode - startNode + 1];
//		for (var i = startNode; i <= endNode; i++)
//			v3New[i-startNode] = arv3AllPos[i];
//		
//		return v3New; 
//	}
}
