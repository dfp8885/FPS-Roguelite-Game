using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTimer : MonoBehaviour
{
    public Text shieldBreakTimer;

    public void SetTimer(float seconds) {
        if (seconds < 0){
            shieldBreakTimer.text = "OK!";
        }
        else {
            shieldBreakTimer.text = string.Format("{0:00}", seconds);
        }

    }
}
