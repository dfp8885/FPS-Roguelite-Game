using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{

	public Slider slider;

	public void SetMaxHP(int hitPoints)
	{
		slider.maxValue = hitPoints;
		slider.value = hitPoints;
	}

    public void SetHP(int hitPoints)
	{
		slider.value = hitPoints;
	}
}
