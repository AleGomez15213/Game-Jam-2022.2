using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class DetectSlime : MonoBehaviour
{
	public bool isBeingFollowed;
	private bool isFollowing;

	private Transform target;
	private NavMeshAgent navMeshAgent;
	private DetectSlime detectionScript;

	public List<Transform> targets { get; private set; }

	private void Start()
	{
		targets = new List<Transform>();
		navMeshAgent = GetComponentInParent<NavMeshAgent>();
		isFollowing = false;
		isBeingFollowed = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Slime")&& !targets.Contains(other.transform))
		{
			targets.Add(other.transform);
			isFollowing = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Slime") && targets.Contains(other.transform))
		{
			if (targets.Count >= 2)
				ChooseTarget();
			targets.Remove(other.transform);
			if (targets.Count == 0)
				isFollowing = false;
		}
	}

	private void ChooseTarget()
	{
		target = targets.FirstOrDefault();
		isBeingFollowed = true;
		foreach (Transform potentialTarget in targets)
		{
			if (potentialTarget.name == "Player")
				target = potentialTarget;
		}
	}

	private void Update()
	{
		if (!isFollowing)
		{
			navMeshAgent.ResetPath();
			target = null;
		}

		if (target != null)
			detectionScript = target.GetComponentInChildren<DetectSlime>();
		if (targets.Count != 0 && target == null)
		{
			ChooseTarget();
		}
		else if (isFollowing && target != null)
		{
			navMeshAgent.SetDestination(target.position);
		}
	}
}
