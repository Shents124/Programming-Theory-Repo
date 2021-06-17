using System;
using UnityEngine;

public class Sandwich : MonoBehaviour
{
    private float speed = 50f;
    private int dame = 5;
    private string targetTag = "Animal";
    private float topBound = 50f;
    private float rightBound = 50f;
    
    public Vector3 moveDirection;
    
    private void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
        DestroyOutOfBound();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if sandwich trigger the animal
        if (other.CompareTag(targetTag))
        {
            other.GetComponent<IDamageable>().TakeDame(dame);
            gameObject.SetActive(false);
        }
    }

    private void DestroyOutOfBound()
    {
        Vector3 currenPosition = transform.position;
        if(currenPosition.z >= topBound || currenPosition.z <= -topBound)
            gameObject.SetActive(false);
        if(currenPosition.x >= rightBound || currenPosition.x <= -rightBound)
            gameObject.SetActive(false);
    }
}

