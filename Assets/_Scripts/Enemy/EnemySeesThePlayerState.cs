using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeesThePlayerState : EnemyState
{
    // Start is called before the first frame update
    public float _timeToDetect = 5;
    private float _timeAfterDetect;
    private float _rotateAngleY;
    private Vector3 _rotateEulerVector3;
    private bool _enemyEyeContactToPlayer;
    [SerializeField]
    private LayerMask _obstacle;
    public GameObject SignalGO;
    private SignalFeeling _sf;
    private GameObject go;


 void Start()
    {
     
    }
    public override void Enter()
    {
        // target = GameObject.FindGameObjectWithTag("Player").transform; //¬озможны проблемы с производительностью
        // print(entity.target.position);

        //  navMashAgent.SetDestination(this.transform.position);
        //   target = GameObject.FindGameObjectWithTag("Player").transform; //¬озможны проблемы с производительностью
        thisEnemy.animator.SetBool("Searching", true);
        go = Instantiate(thisEnemy.GetGameObject(this),(this.transform.position+Vector3.up * thisEnemy.signalGoVertivalOffset),Quaternion.identity,this.transform);
        _sf = go.GetComponent<SignalFeeling>();
        _sf.SetNewColor(Color.yellow);
        _timeAfterDetect = 0f;
        _obstacle = LayerMask.GetMask("Default");
        //  navMashAgent.isStopped = true;


        thisEnemy.navMashAgent.SetDestination(this.transform.position);
        print(this.transform.position);


    }
    public override void Exit()
    {
        thisEnemy.animator.SetBool("Searching", false);
        thisEnemy.navMashAgent.SetDestination(thisEnemy.target.position);
       // print(target.position);
        Destroy(go);
        _sf = null;
    }
    // Update is called once per frame
   public override void FixedUpdate()
    {
        if (!thisEnemy.TargetInFieldOfView())
        {
            _timeAfterDetect -= Time.deltaTime;
            //stateMachine.ChangeState(typeof(EnemyPatrolState));
        }
        if (thisEnemy.TargetInFieldOfView())
        {
            _timeAfterDetect += Time.deltaTime;
        }
        //   _timeAfterDetect += Time.deltaTime;
        _sf.SetNewFeelValue(_timeAfterDetect/_timeToDetect);
        if (_timeAfterDetect > _timeToDetect)
        {
            stateMachine.ChangeState(typeof(EnemyAttackState)) ;
        }
        if (_timeAfterDetect<=0)
        {
            thisEnemy.navMashAgent.SetDestination(thisEnemy.target.position);
            stateMachine.ChangeState(typeof(EnemyPatrolState));
        }
       
        RotateToTarget();
     
       
    }
    private void RotateToTarget()
    {
        _rotateAngleY = Quaternion.FromToRotation(Vector3.forward, thisEnemy.target.position - transform.position).eulerAngles.y;
        _rotateEulerVector3 = new Vector3(0, _rotateAngleY, 0);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation,Quaternion.Euler(_rotateEulerVector3),0.14f);
    }
    
}
