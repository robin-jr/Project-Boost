using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Rocket : MonoBehaviour
{
    [SerializeField] float thrust = 5f;
    [SerializeField] float rotationSpeed = 2f;
    Rigidbody rigidbody;
    bool isAlive = true;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }

        Thrust();
        Rotate();
    }
    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (!isAlive) { return; }
        switch (other.gameObject.tag)
        {
            case "Finish":
                Invoke("LoadNextScene", 1f);
                break;
            case "Friendly":
                break;
            default:
                isAlive = false;
                Invoke("Die", 1f);
                return;
        }
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }
    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        }
    }
    private void Rotate()
    {
        rigidbody.angularVelocity = Vector3.zero;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}
