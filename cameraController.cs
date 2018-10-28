using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public Transform player;

    private float offset;
    
    
    
    

    void Start()
    {
        transform.position = player.position;
        offset = transform.position.x - player.position.x;
        
        

    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x + offset, -4, -10);
    }
}
