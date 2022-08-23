using UnityEngine;
using TMPro;

public class UICounter : MonoBehaviour
{
	public TextMeshProUGUI counter;
	private int slimesEaten = 0;
	private void OnEnable() => FindObjectOfType<ChainHandler>().eatEvent += OnCounterUpdate;
	private void OnDisable() => FindObjectOfType<ChainHandler>().eatEvent -= OnCounterUpdate;

	private void OnCounterUpdate()
	{
		slimesEaten++;
		counter.text = "Slimes eaten: " + slimesEaten; 
	}
}
