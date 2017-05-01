using UnityEngine;
using System.Collections;

using SimpleJSON;

public class Parameters : MonoBehaviour {

	#region Variables

	private string parametersURL = "http://localhost/edmuch/unity/parameters.php";

	private string json;

	#endregion

	IEnumerator DownloadParameters () {
		
		WWWForm Form = new WWWForm ();
		Form.AddField("email", Login.email);
		Form.AddField("game", GameMaster.gameName);
		
		WWW DownloadParametersWWW = new WWW (parametersURL, Form);
		yield return DownloadParametersWWW;
		if (DownloadParametersWWW.error != null) {
			Debug.LogError("Brak połączenia z serwerem");
		} else {
			json = DownloadParametersWWW.text;

			JSONNode N = JSON.Parse(json);

			GameMaster.minBlowStrength = N["minBlowStrength"].AsInt;
			GameMaster.speed = N["speed"].AsFloat;
			GameMaster.dateOfParameters = N["date"].Value;
		}
	}
	//function to be called on button click
	public void GetParameters () {
		StartCoroutine ("DownloadParameters");
	}

}
