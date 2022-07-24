using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyState
{
    private bool _enemyEyeContactToPlayer;
    [SerializeField]
    private LayerMask _obstacle;
    private float timeToFindNewPoint;
    private Vector3 _lastPosition;
    void Start()
    {
        _obstacle = LayerMask.GetMask("Default");
     
       // target = GameObject.FindGameObjectWithTag("Player").transform; //¬озможны проблемы с производительностью
       // StartCoroutine(FindNewPoint());

    }
    public override void Enter()
    {
        // StartCoroutine(FindNewPoint());
        //   StopAllCoroutines
        thisEnemy.target = GameObject.FindGameObjectWithTag("Player").transform; //¬озможны проблемы с производительностью
        thisEnemy.navMashAgent = GetComponent<NavMeshAgent>();
        thisEnemy.navMashAgent.SetDestination(thisEnemy.target.position);
        timeToFindNewPoint = 0;
    // ..   print("FindingNewPoint");
    }
    public override void Exit()
    {
       // StopCoroutine(FindNewPoint());
    }
 
    
    
        // Update is called once per frame
        public override void FixedUpdate()
    {
     //   float lastspeed;
       // lastspeed = Mathf.Lerp(,,0.3) ;
        thisEnemy.animator.SetFloat("Speed", (_lastPosition - transform.position).magnitude / Time.fixedDeltaTime);
        _lastPosition = transform.position;
      
        //  print(navMashAgent.remainingDistance);
        if (thisEnemy.navMashAgent.remainingDistance < 0.01f )
        {

            // Vector3 _destination = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)) + this.transform.position;

            thisEnemy.navMashAgent.SetDestination(thisEnemy.enemyTracks.WhatIsNextPoint());
            thisEnemy.enemyTracks.EnemyReachedToTarget();
           
         
            //  print("SetDest");
        }
      
        DrawFielOfView();


        if ((((thisEnemy.target.position - this.transform.position).magnitude < 15) & thisEnemy.TargetInFieldOfView()) || (thisEnemy.target.position - this.transform.position).magnitude < 3 )
        {
            stateMachine.ChangeState(typeof(EnemySeesThePlayerState));
        }
    //    print( Physics.Linecast(this.transform.position, target.position, _obstacle));
       }
   
    private void DrawFielOfView()
    {
        Vector3 left = this.transform.position + Quaternion.Euler(new Vector3(0, 45, 0)) * (this.transform.forward * 11f);
        Vector3 right = this.transform.position + Quaternion.Euler(-new Vector3(0, 45, 0)) * (this.transform.forward * 11f);
        Debug.DrawLine(transform.position, left, Color.red);
        Debug.DrawLine(transform.position, right,Color.red);
        //Debug.(transform.position, right, Color.red);
  //      Gizmos.DrawSphere(transform.position,3f);
    }
}
