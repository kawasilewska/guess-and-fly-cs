using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level1Score : MonoBehaviour {

#region Variables

	public GameObject textPointsLevel1 = null;

#endregion

	void Start () {
		foreach (GameObject lvl1 in GameMaster.level1) {
			Destroy (lvl1);
		}
		foreach (GameObject _ui in GameMaster.ui) {
			Destroy (_ui);
		}
		Text text = textPointsLevel1.GetComponent<Text> ();
		text.text += GameMaster.points1.ToString ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			FadeInOut.LoadLevel("Level2", 1, 1, Color.black);
			//Application.LoadLevel("Level2");
		} else if (Input.GetKeyDown (KeyCode.Escape)) {
			FadeInOut.LoadLevel("Menu", 1, 1, Color.black);
			//Application.LoadLevel("Menu");
		}
	}
}
