using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData : MonoBehaviour
{
    public Transform[] enemiesTransforms;
    public Joystick joystick;
 //   private Rigidbody _rb;
    public Transform _camera;
    public Transform CameraPoint;
    public Transform model;
  
    public ParticleSystem hitParticles;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //_rb = this.GetComponent<Rigidbody>();
        Application.targetFrameRate=120;       // _modelAnimator = model.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
