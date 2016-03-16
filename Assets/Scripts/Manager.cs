using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Manager : MonoBehaviour {
	[SerializeField]
	Text score;

	Player player;
	Buildings buildings;
    Boolean offFocus;

	void Awake() {
		player = new Player ();
		buildings = new Buildings ();


        int inf = PlayerPrefs.GetInt("influence");
        if(inf > 0) player.setInfluence(inf);


        int buildingsCount = PlayerPrefs.GetInt("buildings");
        if( buildingsCount>0 ) buildings.setBuildingNum(0, buildingsCount);

        offFocus = true;

        Debug.Log("Awake");
	}

	void Start () {
		
	}

	void Update () {
        if (!offFocus)
        {
            player.addInfluence(Time.deltaTime * buildings.getInfluencyPerSecond());

            score.text = "Influency: " + (int)player.getInfluence();
        }
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

            Debug.Log("OUT");

            offFocus = true;
            PlayerPrefs.SetString("focusTime", DateTime.Now.ToString());

		} else {

            Debug.Log("IN");

            offFocus = false;
            String date = PlayerPrefs.GetString("focusTime");
            
            if(date != "defaultValue")
            {
                TimeSpan ts = DateTime.Now - Convert.ToDateTime(date) ;
                Debug.Log( ts.TotalSeconds );

                player.addInfluence((float) ts.TotalSeconds * buildings.getInfluencyPerSecond());
            }
            
        }
	}

	void OnApplicationQuit() {
        PlayerPrefs.SetString("focusTime", DateTime.Now.ToString());
        PlayerPrefs.SetInt("buildings",buildings.getBuildingNum(0));//<<<<<<<<<<

        PlayerPrefs.SetInt("influence", (int) player.getInfluence() );

    }
}
