using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
	public DetectSlime detection;
    private Transform target;
	private NavMeshAgent navMeshAgent;
	private bool isFollowing;

	private void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		isFollowing = false;
	}

	private void Update()
	{

	}
}
