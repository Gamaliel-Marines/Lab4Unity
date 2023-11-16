
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script allows this GameObject to follow another GameObject (the player) with a specified offset.
/// </summary>
public class FollowPlayer : MonoBehaviour
{
    public GameObject player;  // Reference to the player GameObject that this object will follow.
    private Vector3 offset = new Vector3(0, 6, -7);  // The offset relative to the player's position.

    /// <summary>
    /// This method is called before the first frame update.
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// This method is called once per frame, but it's executed after the Update() methods of all other objects.
    /// </summary>
    void LateUpdate()
    {
        // Set the position of this object to the player's position plus the defined offset.
        transform.position = player.transform.position + offset;
    }
}
