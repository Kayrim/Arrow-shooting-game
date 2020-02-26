using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    public float moveSpeed = 10f;
    private Vector3 _inputs = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        float hmove = Input.GetAxisRaw("Horizontal");
        // Decided to only input horizontal for now - float vmove = Input.GetAxisRaw("Vertical");

        Vector3 playDirection = new Vector3(hmove,0, 0); //Could add the Z if I want more movement later
        playDirection.Normalize();

        rb.velocity = transform.TransformDirection(playDirection)*moveSpeed*Time.fixedDeltaTime;
    }
}
