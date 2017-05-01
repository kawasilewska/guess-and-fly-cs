using UnityEngine;
using System.Collections;

public class Questions : MonoBehaviour {

#region Variables

	[System.Serializable]
	public class Question {

		public Transform q1_1 = null;
		public Transform q1_2 = null;
		public Transform q1_3 = null;
		public Transform q1_4 = null;
		public Transform q1_5 = null;
		public Transform q1_6 = null;
		public Transform q1_7 = null;
		public Transform q1_8 = null;
		public Transform q1_9 = null;
		public Transform q1_10 = null;
		
		public Transform q2_1 = null;
		public Transform q2_2 = null;
		public Transform q2_3 = null;
		public Transform q2_4 = null;
		public Transform q2_5 = null;
		public Transform q2_6 = null;
		public Transform q2_7 = null;
		public Transform q2_8 = null;
		public Transform q2_9 = null;
		public Transform q2_10 = null;
		
		public Transform q3_1 = null;
		public Transform q3_2 = null;
		public Transform q3_3 = null;
		public Transform q3_4 = null;
		public Transform q3_5 = null;
		public Transform q3_6 = null;
		public Transform q3_7 = null;
		public Transform q3_8 = null;
		public Transform q3_9 = null;
		public Transform q3_10 = null;

	}

	public Question question = new Question ();

	public int random;

	private Vector3 qPosition;

#endregion
	
	void Awake () {
		random = Random.Range (1, 10);
		qPosition = new Vector3 (0.0f, 0.0f, 0.0f);
	}

	void Start () {
		DeactivateObjects();
		if (GameMaster.level == 1) {
			if (random == 1) {
				Instantiate (question.q1_1, qPosition, question.q1_1.rotation);
			} else if (random == 2) {
				Instantiate (question.q1_2, qPosition, question.q1_2.rotation);
			} else if (random == 3) {
				Instantiate (question.q1_3, qPosition, question.q1_3.rotation);
			} else if (random == 4) {
				Instantiate (question.q1_4, qPosition, question.q1_4.rotation);
			} else if (random == 5) {
				Instantiate (question.q1_5, qPosition, question.q1_5.rotation);
			} else if (random == 6) {
				Instantiate (question.q1_6, qPosition, question.q1_6.rotation);
			} else if (random == 7) {
				Instantiate (question.q1_7, qPosition, question.q1_7.rotation);
			} else if (random == 8) {
				Instantiate (question.q1_8, qPosition, question.q1_8.rotation);
			} else if (random == 9) {
				Instantiate (question.q1_9, qPosition, question.q1_9.rotation);
			} else if (random == 10) {
				Instantiate (question.q1_10, qPosition, question.q1_10.rotation);
			}
		} else if (GameMaster.level == 2) {
			if (random == 1) {
				Instantiate (question.q2_1, qPosition, question.q2_1.rotation);
			} else if (random == 2) {
				Instantiate (question.q2_2, qPosition, question.q2_2.rotation);
			} else if (random == 3) {
				Instantiate (question.q2_3, qPosition, question.q2_3.rotation);
			} else if (random == 4) {
				Instantiate (question.q2_4, qPosition, question.q2_4.rotation);
			} else if (random == 5) {
				Instantiate (question.q2_5, qPosition, question.q2_5.rotation);
			} else if (random == 6) {
				Instantiate (question.q2_6, qPosition, question.q2_6.rotation);
			} else if (random == 7) {
				Instantiate (question.q2_7, qPosition, question.q2_7.rotation);
			} else if (random == 8) {
				Instantiate (question.q2_8, qPosition, question.q2_8.rotation);
			} else if (random == 9) {
				Instantiate (question.q2_9, qPosition, question.q2_9.rotation);
			} else if (random == 10) {
				Instantiate (question.q2_10, qPosition, question.q2_10.rotation);
			}
		} else if (GameMaster.level == 3) {
			if (random == 1) {
				Instantiate (question.q3_1, qPosition, question.q3_1.rotation);
			} else if (random == 2) {
				Instantiate (question.q3_2, qPosition, question.q3_2.rotation);
			} else if (random == 3) {
				Instantiate (question.q3_3, qPosition, question.q3_3.rotation);
			} else if (random == 4) {
				Instantiate (question.q3_4, qPosition, question.q3_4.rotation);
			} else if (random == 5) {
				Instantiate (question.q3_5, qPosition, question.q3_5.rotation);
			} else if (random == 6) {
				Instantiate (question.q3_6, qPosition, question.q3_6.rotation);
			} else if (random == 7) {
				Instantiate (question.q3_7, qPosition, question.q3_7.rotation);
			} else if (random == 8) {
				Instantiate (question.q3_8, qPosition, question.q3_8.rotation);
			} else if (random == 9) {
				Instantiate (question.q3_9, qPosition, question.q3_9.rotation);
			} else if (random == 10) {
				Instantiate (question.q3_10, qPosition, question.q3_10.rotation);
			}
		}
		GameMaster.questions = GameObject.FindGameObjectsWithTag ("Questions");
	}
	
	public static void ActivateObjects () {
		GameMaster.isUIActive = true;

		if (GameMaster.level == 1) {
			foreach (GameObject lvl1 in GameMaster.level1) {
				lvl1.SetActive (true);
			}
			
			foreach (GameObject _ui in GameMaster.ui) {
				_ui.SetActive (true);
			}
		} else if (GameMaster.level == 2) {
			foreach (GameObject lvl2 in GameMaster.level2) {
				lvl2.SetActive (true);
			}
			
			foreach (GameObject _ui in GameMaster.ui) {
				_ui.SetActive (true);
			}
		} else if (GameMaster.level == 3) {
			foreach (GameObject lvl3 in GameMaster.level3) {
				lvl3.SetActive (true);
			}
			
			foreach (GameObject _ui in GameMaster.ui) {
				_ui.SetActive (true);
			}
		}
	}

	public static void DeactivateObjects () {
		GameMaster.isUIActive = false;

		if (GameMaster.level == 1) {
			foreach (GameObject lvl1 in GameMaster.level1) {
				lvl1.SetActive (false);
			}

			foreach (GameObject _ui in GameMaster.ui) {
				_ui.SetActive (false);
			}
		} else if (GameMaster.level == 2) {
			foreach (GameObject lvl2 in GameMaster.level2) {
				lvl2.SetActive (false);
			}
			
			foreach (GameObject _ui in GameMaster.ui) {
				_ui.SetActive (false);
			}
		} else if (GameMaster.level == 3) {
			foreach (GameObject lvl3 in GameMaster.level3) {
				lvl3.SetActive (false);
			}
			
			foreach (GameObject _ui in GameMaster.ui) {
				_ui.SetActive (false);
			}
		}
	}
}
