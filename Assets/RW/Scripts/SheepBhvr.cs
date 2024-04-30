using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBhvr : MonoBehaviour
{
    public float speed = 1f; 
    public float gotHayDestroyDelay = 0.5f;
    private bool hit_by_hay = false;
    public float drop_destroy_delay = 3.5f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); 
    }


    private void HitByHay()
    {
        hit_by_hay = true; 
        speed = 0f; 
        Destroy(gameObject, gotHayDestroyDelay); 
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Hay") && !hit_by_hay) 
        {
            Destroy(other.gameObject); 
            HitByHay(); 
        } else if (other.CompareTag("DropSheep"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Collider>().isTrigger = false;
            Destroy(gameObject, drop_destroy_delay); 
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        other.GetComponent<Collider>().isTrigger = false;
        other.GetComponent<Rigidbody>().isKinematic = false;


    }

}
