using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SugarMeterScript : MonoBehaviour {

    private Text sugarMeter;
    private int sugar;

	// Use this for initialization
	void Start () {
        sugarMeter = GetComponentInChildren<Text>();
        updateSugarMeter();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Changesugar(int value)
    {
        sugar += value;
        if(sugar <0)
        {
            sugar = 0;
        }
        updateSugarMeter();
    }
    public int getSugarAmount()
    {
        return sugar;
    }
    void updateSugarMeter()
    {
        sugarMeter.text = sugar.ToString();
    }
}
