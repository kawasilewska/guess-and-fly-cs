using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Login : MonoBehaviour {

#region Variables

	public static string email = "";
	public static string password = "";
	
	private string secretKey = "ibmiwm"; // Edit this value and make sure it's the same as the one stored on the server
	private string loginURL = "http://localhost/edmuch/unity/login.php";

	public InputField IFEmail = null;
	public InputField IFPassword = null;
	public Text textInfo = null;

#endregion

	void Start () {
		IFEmail.ActivateInputField ();
		IFEmail.Select ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (IFEmail.isFocused) {
				IFPassword.ActivateInputField ();
				IFPassword.Select ();
			} else if (IFPassword.isFocused) {
				IFEmail.ActivateInputField ();
				IFEmail.Select ();
			}
		}

		if (Input.GetKeyDown(KeyCode.Return)) {
			LogIn ();
		}
	}

	IEnumerator LoginAccount () {
		email = IFEmail.text;
		password = IFPassword.text;

		string hash = MD5.Md5Sum(email + password + secretKey);

		WWWForm Form = new WWWForm ();
		Form.AddField("email", email);
		Form.AddField("password", password);
		Form.AddField("hash", hash);

		WWW LoginAccountWWW = new WWW (loginURL, Form);
		yield return LoginAccountWWW;
		if (LoginAccountWWW.error != null) {
			textInfo.text = "Brak połączenia z serwerem";
		} else {
			if (LoginAccountWWW.text == "Success") {
				FadeInOut.LoadLevel("Menu", 1, 1, Color.black);
				//Application.LoadLevel("Menu");
			} else if (LoginAccountWWW.text == "EmptyFields") {
				textInfo.text = "Proszę uzupełnić wszystkie pola";
			} else if (LoginAccountWWW.text == "WrongPassword") {
				textInfo.text = "Podano błędne hasło";
			} else if (LoginAccountWWW.text == "NoSuchEmail") {
				textInfo.text = "Konto o podanym adresie email nie istnieje";
			} else if (LoginAccountWWW.text == "NoRights") {
				textInfo.text = "Nie posiadasz uprawnień do gry";
			} else {
				textInfo.text = "Nieznany błąd logowania, proszę spróbować ponownie";
			}
		}
	}
	//function to be called on button click
	public void LogIn () {
		StartCoroutine ("LoginAccount");
	}

}
