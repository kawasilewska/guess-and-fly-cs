using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level3Score : MonoBehaviour {

#region Variables
	
	public GameObject textPointsLevel1 = null;
	public GameObject textPointsLevel2 = null;
	public GameObject textPointsLevel3 = null;
	public GameObject textPointsTotal = null;

#endregion
	
	void Start () {
		foreach (GameObject lvl3 in GameMaster.level3) {
			Destroy (lvl3);
		}
		foreach (GameObject _ui in GameMaster.ui) {
			Destroy (_ui);
		}
		Text text = textPointsLevel1.GetComponent<Text> ();
		text.text += GameMaster.points1.ToString ();
		
		Text text2 = textPointsLevel2.GetComponent<Text> ();
		text2.text += GameMaster.points2.ToString ();

		Text text3 = textPointsLevel3.GetComponent<Text> ();
		text3.text += GameMaster.points3.ToString ();

		Text text4 = textPointsTotal.GetComponent<Text> ();
		text4.text += GameMaster.totalPoints.ToString ();
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			FadeInOut.LoadLevel("Menu", 1, 1, Color.black);
			//Application.LoadLevel("Menu");
		}
	}
}
