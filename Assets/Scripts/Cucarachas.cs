using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucarachas : MonoBehaviour
{
  public float speed = 7f;  // Speed of forward movement
    public float oscillationAmplitude = 2f;  // Amplitude of the left-right movement
    public float oscillationFrequency = 2f;  // Frequency of the left-right movement

    private Vector3 startPosition;

    void Start()
    {
        // Store the initial position of the cockroach
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the cockroach forward continuously
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Calculate the new x position using a sine wave for oscillation
        float newX = startPosition.x + Mathf.Sin(Time.time * oscillationFrequency) * oscillationAmplitude;

        // Apply the new position
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    
    }

