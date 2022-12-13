using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace FrogLoom
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 5)]
        float moventSpeed;

        [SerializeField]
        Transform enemy;

        [SerializeField]
        GameObject endPoint;
        [SerializeField]
        GameObject startingPoint;

        private TweenParams Loop = new TweenParams().SetLoops(-1);

        internal float endPointXPos;
        internal float StartPointXPos;

        public float radius;
        [Range(0, 360)]
        public float angle;

        public GameObject playerRef;

        public LayerMask targetMask;
        public LayerMask obstructionMask;

        public bool canSeePlayer;
        private bool movingRight;

        private void Awake()
        {
        //    Sequence EnemyMovement = DOTween.Sequence();
        //    EnemyMovement.Append(enemy.DOMove(endPoint.transform.position, moventSpeed, false)).Append(enemy.DOLocalRotate(new Vector3(180, 0, 0), 1, RotateMode.Fast))
        //    .Append(enemy.DOMove(startingPoint.transform.position, moventSpeed, false)).Append(enemy.DOLocalRotate(new Vector3(0, 0, 0), 1, RotateMode.Fast)).SetAs(Loop).SetId("enemyMovement");
        }
        private void Start()
        {
            //GetMovingPositions();
            playerRef = GameObject.FindGameObjectWithTag("Player");
            StartCoroutine(FOVRoutine());
            //StartCoroutine(AttackTimer());

        }


        private void Update()
        {
            //if (movingRight)
            //{
            //    enemy.transform.position = enemy.transform.position + new Vector3(endPointXPos, 0f, 0f) * moventSpeed * Time.deltaTime;
            //}
            //else if (!movingRight)
            //{
            //    enemy.transform.position = enemy.transform.position + new Vector3(StartPointXPos, 0f, 0f) * moventSpeed * Time.deltaTime;
            //}
            if (canSeePlayer)
            {
                Debug.Log("CanSeePlayer");
                moventSpeed = 2;
                //StartCoroutine(AttackTimer());
                GetMovingPositions();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            //if(other.tag == "endPoint" && movingRight)
            //{
            //    enemy.transform.rotation = new Quaternion(180, 0f, 0f, moventSpeed);
            //    movingRight = false;
            //}
            //else if (other.tag == "StartingPoint" && !movingRight)
            //{
            //    enemy.transform.rotation = new Quaternion(-180, 0f, 0f, moventSpeed);
            //    movingRight = true;
            //}
        }

        //IEnumerator AttackTimer()
        //{
        //    WaitForSeconds checkTimer = new WaitForSeconds(0.1f);
        //    DOTween.Pause("enemyMovement");
        //    yield return checkTimer;
        //}
        private void GetMovingPositions()
        {
            endPointXPos = playerRef.transform.position.x;
            enemy.transform.position = enemy.transform.position + new Vector3(endPointXPos, 0f, 0f) * moventSpeed * Time.deltaTime;
        }

        private IEnumerator FOVRoutine()
        {
            WaitForSeconds wait = new WaitForSeconds(0.2f);

            while (true)
            {
                yield return wait;
                FieldOfViewCheck();
            }
        }

        private void FieldOfViewCheck()
        {
            Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

            if (rangeChecks.Length != 0)
            {
                Transform target = rangeChecks[0].transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                if (Vector3.Angle(-transform.up, directionToTarget) < angle / 2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);

                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                        canSeePlayer = true;
                    else
                        canSeePlayer = false;
                }
                else
                    canSeePlayer = false;
            }
            else if (canSeePlayer)
                canSeePlayer = false;
        }
    }
}