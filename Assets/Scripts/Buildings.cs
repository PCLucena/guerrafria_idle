using UnityEngine;
using System.Collections;

public class Buildings {

	int[] buildings;
	int[] buildingCost;
	float[] buildingInfluence;
	float influencyPerSecond;

	public Buildings() {
		buildings = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		buildingCost = new int[]{ 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
		buildingInfluence = new float[]{ 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
	}

	public void constroyBuilding(int buildingNum) {
		buildings [buildingNum]++;
		influencyPerSecond = totalInfluence ();
	}

	public int getBuildingCost(int buildingNum) {
		return buildingCost [buildingNum];
	}

	public float getBuildingInfluence(int buildingNum) {
		return buildingInfluence [buildingNum];
	}

	public float totalInfluence() {
		float total = 0;

		for (int i = 0; i < 10; i++) {
			total += buildings [i] * buildingInfluence[i];
		}

		return total;
	}

	public float getInfluencyPerSecond() {
		return influencyPerSecond;
	}
}
