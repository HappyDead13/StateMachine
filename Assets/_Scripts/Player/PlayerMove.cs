using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Joystick joystick;
   // private L
    private Rigidbody _rb;
    private Transform _camera;
   // public Transform CameraPoint;
    private Transform model;
    private Vector3 _moveDirection;
    private Animator _modelAnimator;
    public ParticleSystem hitParticles;
    public float speed;
    private PlayerData _playerData;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerData = GetComponent<PlayerData>();
        this.joystick = _playerData.joystick;
        _camera = _playerData.CameraPoint;
        this.model = _playerData.model;
        _modelAnimator = model.GetComponent<Animator>();
       
    }//
    public Vector3 GetMoveDirection()
    {
        return _moveDirection;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // CameraPoint = 
        _moveDirection = (_camera.forward * joystick.Vertical + _camera.right * joystick.Horizontal);
        // _rb.AddForce(_rb.velocity.magnitude < 5 ? _moveDirection * 20: _moveDirection*10) ;
        // this.transform.Translate(_moveDirection/100);
        this.transform.position += _moveDirection* speed*Time.fixedDeltaTime;
        Quaternion q = Quaternion.FromToRotation(Vector3.forward, _moveDirection.normalized);
        if (_moveDirection.magnitude > 0)
        {
            model.rotation = Quaternion.FromToRotation(Vector3.forward, _moveDirection.normalized);
            model.rotation = Quaternion.Euler(new Vector3(0, q.eulerAngles.y, 0));
        }
     
        _modelAnimator.speed = _moveDirection.magnitude * speed/4;
    }
    public void GetAttack(GameObject AttackedEntity, Vector3 AttackDirection)
    {
        _rb.AddForce(AttackDirection.normalized*5000);
        hitParticles.Play();
    }
}
