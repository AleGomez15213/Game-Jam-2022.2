using System;
using System.Collections.Generic;
using UnityEngine;

public class ChainHandler : MonoBehaviour
{
    public static ChainHandler Instance { get; private set; }
    public GameObject slimePrefab;

    public event Action eatEvent;

    public float bodySpeed = 5;
    public int gapBetweenBodyParts = 5;

    public List<GameObject> parts = new List<GameObject>();
    private List<Vector3> positionHistory = new List<Vector3>();

    private void Awake()
    { 
        Instance = this;
    }

    private void Update()
    {
        positionHistory.Insert(0, transform.position);
        int index = 1;
        foreach (GameObject bodyPart in parts)
        {
            Vector3 point  = positionHistory[Mathf.Min(index * gapBetweenBodyParts, positionHistory.Count - 1)];
            Vector3 moveDirection = point - bodyPart.transform.position;
            bodyPart.transform.position += moveDirection * bodySpeed * Time.deltaTime;
            bodyPart.transform.LookAt(point);
            index++;
        }
    }
    public void GrowChain()
    {
        GameObject bodyPart = Instantiate(slimePrefab, transform.position, Quaternion.identity, transform);
		parts.Add(bodyPart);
        
        if (eatEvent != null)
            eatEvent();
    }
}
