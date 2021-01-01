using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorProgressBar : MonoBehaviour
{
	public Slider slider;

	public int reqFloorProgress= 50;
	int curFloorProgress = 0;

	void Start() {
		slider.maxValue = reqFloorProgress;
		slider.value = 0;
	}

	public void addFloorProgress(int amount) {
		curFloorProgress+= amount;
		slider.value = curFloorProgress;
	}
}
