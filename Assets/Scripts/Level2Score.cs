using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level2Score : MonoBehaviour {

#region Variables
	
	public GameObject textPointsLevel1 = null;
	public GameObject textPointsLevel2 = null;

#endregion

	void Start () {
		foreach (GameObject lvl2 in GameMaster.level2) {
			Destroy (lvl2);
		}
		foreach (GameObject _ui in GameMaster.ui) {
			Destroy (_ui);
		}
		Text text = textPointsLevel1.GetComponent<Text> ();
		text.text += GameMaster.points1.ToString ();

		Text text2 = textPointsLevel2.GetComponent<Text> ();
		text2.text += GameMaster.points2.ToString ();
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			FadeInOut.LoadLevel("Level3", 1, 1, Color.black);
			//Application.LoadLevel("Level3");
		} else if (Input.GetKeyDown (KeyCode.Escape)) {
			FadeInOut.LoadLevel("Menu", 1, 1, Color.black);
			//Application.LoadLevel("Menu");
		}
	}
}
