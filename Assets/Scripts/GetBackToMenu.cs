using UnityEngine;
using System.Collections;

public class GetBackToMenu : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			FadeInOut.LoadLevel("Menu", 1, 1, Color.black);
			//Application.LoadLevel("Menu");
		}
	}
}
