using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Cloud") {
			Destroy (coll.gameObject);
			Time.timeScale = 0;
			FadeInOut.LoadLevel("Question", 1, 1, Color.black);
			//Application.LoadLevel("Question");
		}
	}
}
