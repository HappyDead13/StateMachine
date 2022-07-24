using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private PlayerMove player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     transform.parent.position = Vector3.Lerp(this.transform.position, target.position+player.GetMoveDirection()*0, 0.05f);
    }
}
