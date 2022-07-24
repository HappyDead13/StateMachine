using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyStateMachine stateMachine;
    public Enemy thisEnemy;

    public virtual void Enter()
    {

    }
    public virtual void Exit()
    {

    }
    public virtual void FixedUpdate()
    { 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
