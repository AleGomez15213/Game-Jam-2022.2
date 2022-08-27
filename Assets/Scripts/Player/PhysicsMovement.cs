using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhysicsMovement : MonoBehaviour
{
	public InputAction move;
	public Rigidbody rb;

	public Camera gameCamera;

	public float moveSpeed = 5f;
	public float steerSpeed = 180f;
	private float steerDirection;

	private Vector3 force;

	private void OnEnable()
	{
		move.Enable();
	}

	private void OnDisable()
	{
		move.Disable();
	}

	private void Update()
	{
		Vector3 rayOrigin = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
		RaycastHit ray;
		bool rayDidHit = Physics.Raycast(transform.position, Vector3.down, out ray, 1f);
		if (rayDidHit)
		{
			
		}

		var angle = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, steerDirection * steerSpeed * Time.deltaTime, 0f));
		transform.rotation = angle;

	}
}
