using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject thingToFollow;
    
    // Camera should follow the position of the car

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = this.thingToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
