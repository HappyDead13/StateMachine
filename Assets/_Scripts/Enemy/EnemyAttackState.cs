using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private SignalFeeling _sf;
    private GameObject go;
    private float _timeToLossOfInterest = 5f;
    private bool _corutineIsWorking = false;
    private float _timeAfterLoss = 5f;
    // Start is called before the first frame update
    public override void Enter()
    {
        // target = GameObject.FindGameObjectWithTag("Player").transform; //¬озможны проблемы с производительностью
        // print(entity.target.position);
        thisEnemy.animator.SetBool("Run", true);
        go = Instantiate(thisEnemy.GetGameObject(this), (this.transform.position + Vector3.up * thisEnemy.signalGoVertivalOffset), Quaternion.identity, this.transform);
        _sf = go.GetComponent<SignalFeeling>();
        _sf.SetNewColor(Color.red);
        _timeAfterLoss = 0f;
        thisEnemy.SetSpeed(3f);


    }
    public override void Exit()
    {
        thisEnemy.animator.SetBool("Run", false);
        Destroy(go);
        _sf = null;
        thisEnemy.SetSpeed();
    }
    // Update is called once per frame
    private IEnumerator EndAttack()
    {
        _corutineIsWorking = true;
        yield return new WaitForSeconds(0.75f);
        thisEnemy.animator.SetBool("Attack", false);
       
        thisEnemy.playerMove.GetAttack(this.gameObject, this.transform.forward + this.transform.up);
        print((thisEnemy.target.position - this.transform.position).magnitude);
        yield return new WaitForSeconds(1f);
        _corutineIsWorking = false;

    }
    public override void FixedUpdate()
    {
   
     
        if(!thisEnemy.TargetInFieldOfView())
        {
            if (_timeAfterLoss < _timeToLossOfInterest)
            {
                _timeAfterLoss += Time.deltaTime;
            }
            else
            {
                stateMachine.ChangeState(typeof(EnemySeesThePlayerState));
            }
          
        }
      //  print((entity.target.position - this.transform.position).magnitude);
        if ((thisEnemy.target.position - this.transform.position).magnitude < 2)
        {
        
          
            if (!_corutineIsWorking)
            {
                thisEnemy.animator.SetBool("Attack", true);
                StartCoroutine(EndAttack());
            }
           
            //target.GetComponent<Rigidbody>().AddForce((this.transform.forward+ this.transform.up) *1000);
          
           // thisEnemy.animator.SetBool("Attack", false);

        }
        
        else
        {
            thisEnemy.navMashAgent.SetDestination(thisEnemy.target.position);
        }
    }
}
