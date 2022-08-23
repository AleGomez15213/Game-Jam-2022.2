using Project.Scripts.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHandler : MonoBehaviour
{

    private InputController _input;

    private Vector3 nextTarget;
    public float nextTargetLength;


    [SerializeField]
    private AnimationCurve speedCurve = null;

    private float currentTime = 0;

    [SerializeField]
    private float duration = 1.0f;

    [SerializeField]
    private float speed = 2.0f;

    int dir = 0;//1 = up, 2 = left, 3 = down, 4 = right

    void Start()
    {
        _input = GetComponent<InputController>();

        _input.OnUpTriggered += HandleUpAction;
        _input.OnDownTriggered += HandleDownAction;
        _input.OnLeftTriggered += HandleLeftAction;
        _input.OnRightTriggered += HandleRightAction;

        StartMoving();
    }

	#region Handle Input Actions
	private void HandleDownAction() => dir = 3;

	private void HandleRightAction() => dir = 4;

	private void HandleLeftAction() => dir = 2;

	private void HandleUpAction() => dir = 1;
	#endregion

	private void OnEnable()
    {
        currentTime = 0;
    }

    public void StartMoving()
    {
        CalculateNextDirection();
        StopAllCoroutines();
        currentTime = 0;
        StartCoroutine(MoveToTarget(nextTarget));
    }

    public void CalculateNextDirection()
    {
        float _targetRotation;
        switch (dir)
        {
            case 0:
                nextTarget = transform.position + (transform.forward * nextTargetLength);
                break;
            case 1:
                _targetRotation = Mathf.Atan2(0f, 1f) * Mathf.Rad2Deg;// + _mainCamera.transform.eulerAngles.y;
                transform.rotation = Quaternion.Euler(0.0f, _targetRotation, 0.0f);
                nextTarget = transform.position + (transform.forward * nextTargetLength);

                dir = 0;
                break;
            case 2:
                _targetRotation = Mathf.Atan2(-1f, 0f) * Mathf.Rad2Deg;// + _mainCamera.transform.eulerAngles.y;
                transform.rotation = Quaternion.Euler(0.0f, _targetRotation, 0.0f);
                nextTarget = transform.position + (transform.forward * nextTargetLength);
                dir = 0;
                break;
            case 3:
                _targetRotation = Mathf.Atan2(0f, -1f) * Mathf.Rad2Deg;// + _mainCamera.transform.eulerAngles.y;
                transform.rotation = Quaternion.Euler(0.0f, _targetRotation, 0.0f);
                nextTarget = transform.position + (transform.forward * nextTargetLength);
                dir = 0;
                break;
            case 4:
                _targetRotation = Mathf.Atan2(1f, 0f) * Mathf.Rad2Deg;// + _mainCamera.transform.eulerAngles.y;
                transform.rotation = Quaternion.Euler(0.0f, _targetRotation, 0.0f);
                nextTarget = transform.position + (transform.forward * nextTargetLength);
                dir = 0;
                break;
        }
    }

    private IEnumerator MoveToTarget(Vector3 target)//called until it reaches the target in Update
    {
        //this function just moves a thing from point start to end
        while (transform.position != target)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target,
                Time.deltaTime * speed * speedCurve.Evaluate(TimeManagement()));//magic animation curve

            //set
            transform.position = pos;
            yield return null;
        }

        StartMoving();
        
    }

    private float TimeManagement()
    {
        currentTime += Time.deltaTime;//currentTime=currentTime+Time.deltaTime
        return currentTime / duration;//return values from 0 to 1
    }

   /* public void MoveToTarget(Vector3 dir)
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + dir, Time.deltaTime * speed * speedCurve.Evaluate(TimeManagement()));
        if (speedCurve.Evaluate(TimeManagement()) <= 0)
            Destroy(gameObject);
    }*/
}
