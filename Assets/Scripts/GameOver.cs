using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

#region Variables

	public GameObject textPointsLevel1 = null;
	public GameObject textPointsLevel2 = null;
	public GameObject textPointsLevel3 = null;

#endregion

	void Awake () {
		GameMaster.gameoverstate = true;
	}

	void Start () {
		foreach (GameObject _ui in GameMaster.ui) {
			Destroy (_ui);
		}
		if (GameMaster.level == 1) {
			foreach (GameObject lvl1 in GameMaster.level1) {
				Destroy (lvl1);
			}
			Text textPL1 = textPointsLevel1.GetComponent<Text> ();
			textPL1.text = "Punkty zdobyte w poziomie pierwszym: " + GameMaster.points1;
		} else if (GameMaster.level == 2) {
			foreach (GameObject lvl2 in GameMaster.level2) {
				Destroy (lvl2);
			}
			Text textPL1 = textPointsLevel1.GetComponent<Text> ();
			textPL1.text = "Punkty zdobyte w poziomie pierwszym: " + GameMaster.points1;

			Text textPL2 = textPointsLevel2.GetComponent<Text> ();
			textPL2.text = "Punkty zdobyte w poziomie drugim: " + GameMaster.points2;
		} else if (GameMaster.level == 3) {
			foreach (GameObject lvl3 in GameMaster.level3) {
				Destroy (lvl3);
			}
			Text textPL1 = textPointsLevel1.GetComponent<Text> ();
			textPL1.text = "Punkty zdobyte w poziomie pierwszym: " + GameMaster.points1;
			
			Text textPL2 = textPointsLevel2.GetComponent<Text> ();
			textPL2.text = "Punkty zdobyte w poziomie drugim: " + GameMaster.points2;

			Text textPL3 = textPointsLevel3.GetComponent<Text> ();
			textPL3.text = "Punkty zdobyte w poziomie trzecim: " + GameMaster.points3;
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			FadeInOut.LoadLevel("Menu", 1, 1, Color.black);
			//Application.LoadLevel("Menu");
		}
	}
}
