using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour {
	[SerializeField]
	Text score;

	Player player;
	Buildings buildings;

	void Awake() {
		player = new Player ();
		buildings = new Buildings ();
		PlayerPrefs.SetFloat ("focusTime", Time.time);
		Debug.Log("Awake");
	}

	void Start () {
		
	}

	void Update () {
		score.text = "Influency: " + (int)player.getInfluence();
		player.addInfluence (Time.deltaTime * buildings.getInfluencyPerSecond());
		Debug.Log("Tempo real = " + Time.time);
	}

	public void onClick() {
		player.addInfluence (1);
	}

	public void onBuy(int nome) {
		if (player.getInfluence () >= buildings.getBuildingCost (nome)) {
			player.removeInfluence (buildings.getBuildingCost (nome));
			buildings.constroyBuilding (nome);

		}
	}

	void OnApplicationFocus(bool focusStatus) {
		
		if (!focusStatus) {
			PlayerPrefs.SetFloat ("focusTime", Time.time);
			Debug.Log("(if) Tempo quando parou = " + PlayerPrefs.GetFloat ("focusTime"));

		} else {
			Debug.Log ("(else) Tempo quando parou = " + PlayerPrefs.GetFloat ("focusTime"));

			player.addInfluence ((Time.time - PlayerPrefs.GetFloat ("focusTime")) * buildings.getInfluencyPerSecond ());
		
		}
	}

	void OnApplicationQuit() {
		
	}
}
