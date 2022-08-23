using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int slimesEaten = 0;

	private void OnEnable() => FindObjectOfType<ChainHandler>().eatEvent += OnSlimeEaten;
	private void OnDisable() => FindObjectOfType<ChainHandler>().eatEvent -= OnSlimeEaten;
	public void OnSlimeEaten()
    { 
        slimesEaten++;
        Debug.Log(slimesEaten);
    }
}
