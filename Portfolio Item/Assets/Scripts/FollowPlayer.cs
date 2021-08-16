using UnityEngine;
public class FollowPlayer : MonoBehaviour    
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate() 
    {
        Vector3 desiredPos = player.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position , desiredPos , smoothSpeed);
        transform.position = smoothPos;
    }
}