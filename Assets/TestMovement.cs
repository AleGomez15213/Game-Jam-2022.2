using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
	private float moveSpeed = 3f;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        var force = new Vector3(30f, transform.position.y, transform.position.z);
    }
}
