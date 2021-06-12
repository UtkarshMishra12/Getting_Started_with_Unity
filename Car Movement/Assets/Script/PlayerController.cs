using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 20.0f;
    [SerializeField]
    private float turnSpeed = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float HorizantalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        
        //Move Vehicle Fowrard
        transform.Translate(Vector3.forward * speed * Time.deltaTime * VerticalInput);
        //Move right and left
        transform.Rotate(Vector3.up * turnSpeed *Time.deltaTime * HorizantalInput);
    }
}
