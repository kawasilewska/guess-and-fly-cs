using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

#region Variables

	public float sceneBoundaryUp = 5.65f;
	public float sceneBoundaryDown = -5.65f;

#endregion

	void Update () {
		if (transform.position.y <= sceneBoundaryDown || transform.position.y >= sceneBoundaryUp) {
			GameMaster.DestroyPlayer(this);
			if (GameMaster.level == 1) {
				foreach (GameObject lvl1 in GameMaster.level1) {
					Destroy (lvl1);
				}
			} else if (GameMaster.level == 2) {
				foreach (GameObject lvl2 in GameMaster.level2) {
					Destroy (lvl2);
				}
			} else if (GameMaster.level == 3) {
				foreach (GameObject lvl3 in GameMaster.level3) {
					Destroy (lvl3);
				}
			}

			foreach (GameObject _ui in GameMaster.ui) {
				Destroy (_ui);
			}
			FadeInOut.LoadLevel("GameOver", 1, 1, Color.black);
			//Application.LoadLevel("GameOver");
		}
	}
}
