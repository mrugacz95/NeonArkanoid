﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Movement Speed
    public float speed = 100.0f;
    public AudioClip impact;
    AudioSource audioSource;
    Vector2 startPosition;
    void startMovement()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
    void Start()
    {
        startPosition = transform.position;
        startMovement();
        audioSource = GetComponent<AudioSource>();
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        audioSource.PlayOneShot(impact);
        if (col.gameObject.name == "racket")
        {
            float x = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            if (GameObject.FindWithTag("block") == null)
            {
                Debug.Log("Koniec");
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        transform.position = startPosition;
        startMovement();
    }
}
