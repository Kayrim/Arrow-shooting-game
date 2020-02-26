using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Rigidbody arrowBody;
    private float lifeTime = 5f;
    private bool hitSomething = false;
    AudioManager am;

    // Start is called before the first frame update
    void Start()
    {
        arrowBody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(arrowBody.velocity);
        am = FindObjectOfType<AudioManager>();
        

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifeTime);
        if (!hitSomething)
        {
            transform.rotation = Quaternion.LookRotation(arrowBody.velocity);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag != "Arrow")
        {
            hitSomething = true;            
            Stick();
            if (collision.collider.tag == "Target")
            {
                am.Play("ScorePoint");
            }
        }
    }

    private void Stick()
    {
        arrowBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
