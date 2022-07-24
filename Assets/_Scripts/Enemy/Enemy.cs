using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyStateMachine enemyStateMachine;
    // Start is called before the first frame update
   public EnemyState Patrol;
   // public Scrip Patrol;
    public Transform target;
    public Transform eyePoint;
    public PlayerMove playerMove;
    public float fieldOfView = 90;
    public float lenghtOfView = 10;
   // [SerializeField] 
  //  private bool targetInFieldOfView;
    [SerializeField]
    private GameObject _signalGameObject;
    private LayerMask _obstacle;
    public EnemyTracks enemyTracks;
   // public Transform target;
    public GameObject entity2;
    public NavMeshAgent navMashAgent;
    public float signalGoVertivalOffset;
    public Animator animator;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; //¬озможны проблемы с производительностью
        playerMove = target.GetComponent<PlayerMove>();
       // Patrol = new EnemyPatrolState();
        enemyStateMachine.Initialize(typeof(EnemyPatrolState));
        _obstacle = LayerMask.GetMask("Default");
    }
    public GameObject GetGameObject(EnemySeesThePlayerState state)
    {
        return _signalGameObject;
    }
    public GameObject GetGameObject(EnemyAttackState state)
    {
        return _signalGameObject;
    }
    public void SetSpeed(float speed)
    {
        navMashAgent.speed = speed;
    }
    public void SetSpeed()
    {
        navMashAgent.speed = 1.75f;
    }
    public bool TargetInFieldOfView()
    {
        Debug.DrawLine(eyePoint.position, target.position);
        bool targetInFieldOfView;
        // print(Vector3.Angle(this.transform.forward, target.position - this.transform.position));
        if (!(Vector3.Angle(this.transform.forward, target.position - this.transform.position) > fieldOfView/2) && !Physics.Linecast(eyePoint.position, target.position, _obstacle) && ((target.position - eyePoint.position).magnitude < lenghtOfView) || ((target.position - eyePoint.position).magnitude < 2))
        {
            //  print(targetInFieldOfView);
            targetInFieldOfView = true;
        }
        else
        {
            // print(targetInFieldOfView);
            targetInFieldOfView = false;

        }
     //   print(targetInFieldOfView);
        return targetInFieldOfView;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // TargetInFieldOfView();
    }
}
