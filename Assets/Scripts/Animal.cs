using System;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Transform playerTransform;

    private Rigidbody _animalRb;
    
    // Start is called before the first frame update
    void Start()
    {
        _animalRb = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        // Look at player
        this.transform.LookAt(playerTransform);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        // Add velocity
        _animalRb.velocity = direction * speed;
    }
}
