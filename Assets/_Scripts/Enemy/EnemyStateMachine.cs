using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.UI;

public class EnemyStateMachine : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField]
    private Enemy thisEnemy;
   // [SerializeField]
   // private Text _text;
    private EnemyStateMachine sm;
    [SerializeField]
    private NavMeshAgent navMashAgent;
    public EnemyState CurrentState { get; private set; }
    public void Initialize(System.Type startingState)
    {
        sm = this.GetComponent<EnemyStateMachine>();
        CurrentState = this.gameObject.AddComponent(startingState) as EnemyState;
        CurrentState.thisEnemy = thisEnemy;
       // CurrentState.navMashAgent = this.navMashAgent;
        CurrentState.stateMachine = sm;
        CurrentState.Enter();
      //  _text.text = startingState.ToString();
    }

    public void ChangeState(System.Type newState)
    {
        CurrentState.Exit();

        this.CurrentState.enabled = false;
        if (this.GetComponent(newState))
        {
            CurrentState = this.GetComponent(newState) as EnemyState;
            CurrentState.enabled = true;
        }
        else
        {
            CurrentState = this.gameObject.AddComponent(newState) as EnemyState;
        }

        // CurrentState.navMashAgent = this.navMashAgent;
        CurrentState.thisEnemy = thisEnemy;
        CurrentState.stateMachine = sm;
       // _text.text = newState.ToString();
        CurrentState.Enter();
    }
}
