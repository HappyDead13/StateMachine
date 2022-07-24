using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrack : MonoBehaviour
{
   // [ExecuteInEditMode]
    [SerializeField]
    private EnemyTracks en;
  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.DrawLine(en.points[i].position, en.points[i+1].position,Color.red, 1f);
        //    Debug.DrawLine(new Vector3(10,10,1), new Vector3(0, 0, 1), Color.red, 1f);
        }
    }
}
