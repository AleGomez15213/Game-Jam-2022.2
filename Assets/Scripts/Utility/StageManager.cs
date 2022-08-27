using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageManager : MonoBehaviour
{
    public int slimesEaten = 0;
    private float currentTime = 0f;
    public float startingTime = 30f;

    public TMP_Text timer;
    public event Action timeUpEvent;

    private void OnEnable() => FindObjectOfType<ChainHandler>().eatEvent += OnSlimeEaten;
	private void OnDisable() => FindObjectOfType<ChainHandler>().eatEvent -= OnSlimeEaten;

    public void OnSlimeEaten()
    { 
        slimesEaten++;
    }

	private void Start()
	{
        currentTime = startingTime;
	}

	private void Update()
    {
        timer.text = Mathf.RoundToInt(currentTime).ToString();
        if (currentTime <= 0)
        {
            timer.text = "Time's Up";
            if (timeUpEvent != null)
                timeUpEvent();
        } else {
            currentTime -= Time.deltaTime;
        }
    }
}
