using UnityEngine;
using System.Collections;

public class Answer : MonoBehaviour {

	public void GoodAnswer () {
		Time.timeScale = 1;
		DestroyQuestions ();
		Questions.ActivateObjects ();
		GameMaster.totalPoints += 1;
		if (GameMaster.level == 1) {
			GameMaster.points1 += 1;
		} else if (GameMaster.level == 2) {
			GameMaster.points2 += 1;
		} else if (GameMaster.level == 3) {
			GameMaster.points3 += 1;
		}
	}

	public void BadAnswer () {
		Time.timeScale = 1;
		DestroyQuestions ();
		Questions.ActivateObjects ();
	}

	void DestroyQuestions () {
		foreach (GameObject q in GameMaster.questions) {
			Destroy (q.gameObject);
		}
	}
}
