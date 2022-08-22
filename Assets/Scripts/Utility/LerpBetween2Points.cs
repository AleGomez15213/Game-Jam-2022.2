using System.Collections;
using UnityEngine;

namespace Jam.Utility
{
    public class LerpBetween2Points : MonoBehaviour
    {
        [SerializeField]
        private Transform a;

        [SerializeField]
        private Transform b;

        [SerializeField]
        private AnimationCurve speedCurve = null;

        private float currentTime = 0;

        [SerializeField]
        private float duration = 1.0f;

        [SerializeField]
        private float speed = 2.0f;

        private bool AtB = true;
        private bool move = false;

        
        
      
        private void OnEnable()
        {
            currentTime = 0;
        }


        public void StartMovingA()
        {
            StopAllCoroutines();
            currentTime = 0;
            StartCoroutine(MoveToTarget(a));
        }

        public void StartMovingB()
        {
            StopAllCoroutines();
            currentTime = 0;
            StartCoroutine(MoveToTarget(b));
        }

        private IEnumerator MoveToTarget(Transform target)//called until it reaches the target in Update
        {
            //this function just moves a thing from point A to B
            while (transform.position != target.position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target.position,
                    Time.deltaTime * speed * speedCurve.Evaluate(TimeManagement()));//magic animation curve

                //set
                transform.position = pos;
                yield return null;
            }
            AtB = !AtB;
        }

        private float TimeManagement()
        {
            currentTime += Time.deltaTime;//currentTime=currentTime+Time.deltaTime
            return currentTime / duration;//return values from 0 to 1
        }

        public void MoveToTarget(Vector3 dir)
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position + dir, Time.deltaTime * speed * speedCurve.Evaluate(TimeManagement()));
            if (speedCurve.Evaluate(TimeManagement()) <= 0)
                Destroy(gameObject);
        }
    }
}