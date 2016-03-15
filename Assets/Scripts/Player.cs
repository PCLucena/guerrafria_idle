using UnityEngine;
using System.Collections;

public class Player {
	
	public float playerInfluence = 0;

	public void addInfluence(float influence) {
		playerInfluence += influence;
	}

	public void removeInfluence(int influence) {
		playerInfluence -= influence;
	}

	public float getInfluence() {
		return playerInfluence;
	}
}
