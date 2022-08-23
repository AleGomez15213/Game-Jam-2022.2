using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePickup : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Collector"))
		{
			ChainHandler.Instance.GrowChain();
			Destroy(gameObject); // Might want to design a pooling system for removed pickups if optimization becomes a problem
		}
	}
}
