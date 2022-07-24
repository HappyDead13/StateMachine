using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracks : MonoBehaviour
{
    public Transform[] points;
    public Transform point;
    private int _currentPointIndex;

    // Start is called before the first frame update
    void Start()
    {
        points = point.GetComponentsInChildren<Transform>();
    }
    public void EnemyReachedToTarget()
    {
      // points.
        _currentPointIndex += 1;
    }
    public Vector3 WhatIsNextPoint()
    {
        if (_currentPointIndex == (points.Length - 1))
        {
            _currentPointIndex = 0;
        }
        return points[_currentPointIndex + 1].position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
