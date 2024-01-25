using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float force = 20;
    public float torque = 1;
    private Rigidbody enemyRB;
    private float destroyBoundary = -5.5f;
    public GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        enemyRB.AddTorque(torque, torque, torque); // Spin Enemy
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyRB.AddForce(Vector3.down * force); // Push enemy down

        // Destroy if off screen
        if (transform.position.y < destroyBoundary)
        {
            Destroy(gameObject);
            gameManagerScript.UpdateScore(1); // Send a point to GameManager
            force++;
        }
    }
    public void resetForce()
    {
        force = 20;
    }
}
