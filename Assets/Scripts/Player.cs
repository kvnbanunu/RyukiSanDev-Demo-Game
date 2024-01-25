using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 10;
    private float horizontal;
    private float boundary = 10;
    public GameObject restartButton;
    public GameObject exitButton;
    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManagerScript.gameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontal);
        if (transform.position.x > boundary)
        {
            transform.position = new Vector3(-boundary, transform.position.y);
        }
        if (transform.position.x < -boundary)
        {
            transform.position = new Vector3(boundary, transform.position.y);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
        restartButton.SetActive(true);
        exitButton.SetActive(true);
        gameManagerScript.gameRunning = false;
    }
}
