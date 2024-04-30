using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDropper : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        other.GetComponent<Collider>().isTrigger = false;
        other.GetComponent<Rigidbody>().isKinematic = false;
    
    
    }
}
