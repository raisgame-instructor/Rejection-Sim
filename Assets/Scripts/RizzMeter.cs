using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RizzMeter : MonoBehaviour
{
    public Slider Rizzmeter;
    public float CurrentValue;

    //on update we want the bar to go down by a very small amount every frame
    void Update()
    {
        ConstantUpdateRizz();
    }

    private void ConstantUpdateRizz()
    {
        CurrentValue = CurrentValue - 0.005f;
        Rizzmeter.value = CurrentValue;
    }
    //will happen when you pick up items
    public void PosUpdateRizz()
    {
        CurrentValue = CurrentValue + 15f;
        Rizzmeter.value = CurrentValue;
    }
    //to be triggered at the end of every conversation
    public void NegUpdateRizz()
    {
        CurrentValue = CurrentValue - 20f;
        Rizzmeter.value = CurrentValue;
    }
    //at the end of every conversation we want the bar to go down by a drastic amount
}
