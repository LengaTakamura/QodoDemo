using UnityEngine;

public class Demo : MonoBehaviour
{
    Transform myTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myTransform = transform;
        myTransform.position = new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
