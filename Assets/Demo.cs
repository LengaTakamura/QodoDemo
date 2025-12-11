using UnityEngine;

public class Demo : MonoBehaviour
{
    Transform myTransform;

    public float Speed = 10f;
    public int health = 100;

    Rigidbody myRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myTransform = transform;
        myTransform.position = new Vector3(0, 5, 0);
        health -= 10;
        Debug.Log("Health: " + health);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.AddForce(0, -9.81f, 0);
        myTransform.position = new Vector3(0, 5, 0);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected with " + collision.gameObject.name);
        collision.gameObject.SetActive(true);
    }
}
