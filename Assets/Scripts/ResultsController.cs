using UnityEngine;
using System.Collections;

public class ResultsController : MonoBehaviour {

#region Variables

	private string secretKey = "ibmiwm"; // Edit this value and make sure it's the same as the one stored on the server
	private string addResultURL = "http://localhost/edmuch/unity/addresult.php"; //be sure to add a ? to your url
	//public string highscoreURL = "http://localhost/unity_test/display.php";

#endregion

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (GameMaster.level == 1 || GameMaster.level == 2) {
				StartCoroutine ("PostResult");
			}
		} else if (Input.GetKeyDown(KeyCode.Return) && GameMaster.level == 3) {
			StartCoroutine ("PostResult");
		} else if (Input.GetKeyDown(KeyCode.Return) && GameMaster.gameoverstate) {
			StartCoroutine ("PostResult");
		}

	}

	// remember to use StartCoroutine when calling this function!
	IEnumerator PostResult () {
		//This connects to a server side php script that will add the result to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		string hash = MD5.Md5Sum(GameMaster.gameName + Login.email + GameMaster.points1 + GameMaster.points2 + GameMaster.points3 + GameMaster.totalPoints + GameMaster.btime + secretKey);

		WWWForm Form = new WWWForm ();
		Form.AddField("game", GameMaster.gameName);
		Form.AddField("email", Login.email);
		Form.AddField("points1", GameMaster.points1);
		Form.AddField("points2", GameMaster.points2);
		Form.AddField("points3", GameMaster.points3);
		Form.AddField("totalPoints", GameMaster.totalPoints);
		Form.AddField("btime", GameMaster.btime.ToString());
		Form.AddField("hash", hash);
		WWW addResultWWW = new WWW (addResultURL, Form);
		yield return addResultWWW;

		if (addResultWWW.error != null) {
			Debug.LogError ("Wystąpił błąd podczas przesyłania wyniku do bazy danych");
		}
	}

	// Get the scores from the MySQL DB to display in a GUIText.
	// remember to use StartCoroutine when calling this function!
	/*
	IEnumerator GetScores () {
		gameObject.guiText.text = "Loading Scores";
		WWW hs_get = new WWW(highscoreURL);
		yield return hs_get;
		
		if (hs_get.error != null) {
			print("There was an error getting the high score: " + hs_get.error);
		} else {
			gameObject.guiText.text = hs_get.text; // this is a GUIText that will display the scores in game.
		}
	}
	*/
	
}