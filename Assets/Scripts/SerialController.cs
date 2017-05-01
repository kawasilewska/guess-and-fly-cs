using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using System;
using System.Collections.Generic;

public class SerialController : MonoBehaviour {

#region Variables
	
	public static int x_param_OUT = 0;
	public static int y_param_OUT = 0;
	public static int z_param_OUT = 0;
	public static int p_param_OUT = 0;
	
	private static bool isRunning = false;
	private static SerialPort serialPort;
	private static string serialPortName = null;

	private Thread readThread;
	private int baudRate = 19200;

	public Text textInfo = null;
	public Text textInfo2 = null;
	public Button loginButton = null;

#endregion

	void Awake () {
		readThread = new Thread(readData);
	}

	void Start () {
		searchSerialPorts ();


		if (serialPortName != "")
		{
			Debug.LogError(serialPortName);
			serialPort = new SerialPort(serialPortName, baudRate);
			serialPort.Open();
			isRunning = true;
			readThread.Start ();
		}
	}

	void Update() {
		searchSerialPorts ();
		if (serialPortName == "") {
			textInfo.text = "Nie podłączono eDmuchawki!";
			loginButton.interactable = false;
		} else {
			textInfo.text = ""; 
			loginButton.interactable = true;
		}
	}

	void OnApplicationQuit () {
		isRunning = false;
		Thread.Sleep(100);
		readThread.Abort ();
		serialPort.Close ();
	}

#region Searching eDmuchawka device

	private void searchSerialPorts () {
		String comPortName = "";
		List<string> names = comPortNames("0403", "6015");
		if (names.Count > 0) {
			if (SerialPort.GetPortNames() != null) {
				foreach (String s in SerialPort.GetPortNames()) {
					if (names.Contains(s)) {
						comPortName = s;
					}
				} 
				serialPortName = comPortName;
			} else {
				textInfo.text = "Nie podłączono eDmuchawki!";
				textInfo2.text = "";
				serialPortName = null;
			}
		}
	}

	List<string> comPortNames (String VID, String PID) {
		String pattern = String.Format("^VID_{0}.PID_{1}", VID, PID);                                           
		System.Text.RegularExpressions.Regex _rx = 
			new System.Text.RegularExpressions.Regex(pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
		List<string> comPorts = new List<string>();
		comPorts.Clear();
		Microsoft.Win32.RegistryKey rk1 = Microsoft.Win32.Registry.LocalMachine;
		
		Microsoft.Win32.RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
		
		foreach (String s3 in rk2.GetSubKeyNames()) {
			Microsoft.Win32.RegistryKey rk3 = rk2.OpenSubKey(s3);
			foreach (String s in rk3.GetSubKeyNames()) {
				if (_rx.Match(s).Success) {
					Microsoft.Win32.RegistryKey rk4 = rk3.OpenSubKey(s);
					foreach (String s2 in rk4.GetSubKeyNames()) {
						Microsoft.Win32.RegistryKey rk5 = rk4.OpenSubKey(s2);
						Microsoft.Win32.RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
						comPorts.Add((string)rk6.GetValue("PortName"));
					}
				}
			}
		}
		return comPorts;
	}

#endregion

	public static void readData () {

		while (isRunning) {
			try {
				x_param_OUT = Convert.ToInt32(serialPort.ReadLine().Remove(0, 2));
				y_param_OUT = Convert.ToInt32(serialPort.ReadLine().Remove(0, 2));
				z_param_OUT = Convert.ToInt32(serialPort.ReadLine().Remove(0, 2));
				p_param_OUT = Convert.ToInt32(serialPort.ReadLine().Remove(0, 2));
			} catch (Exception e) {
				Debug.LogError ("Wystąpił błąd z odczytem danych z urządzenia " + e);
			}
		}
	}

}
