using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorProgressBar : MonoBehaviour
{
	public Slider slider;
	public int reqFloorProgress = 50;

	public static bool floorComplete = false;

	int bossFloorReq = 1;
	int curFloorProgress = 0;

	void Start() {
		if (TileGeneration.BossFloor) {
			reqFloorProgress = bossFloorReq;
		}
		slider.maxValue = reqFloorProgress;

		slider.value = 0;
	}

    private void FixedUpdate() {
		if (curFloorProgress >= reqFloorProgress && !floorComplete) {
			floorComplete = true;
		}
    }

    public void addFloorProgress(int amount) {
		curFloorProgress+= amount;
		slider.value = curFloorProgress;
	}

	public void progressReset() {
		floorComplete = false;
	}
}
