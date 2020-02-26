using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Camera cam;
    public GameObject arrow;
    public Transform arrowSpawnPoint;
    public float startTime = 0f;
    public float shootForce = 1f;
    public float chargeSpeed = 5000f;
    float maxForce = 100f;
    float minForce = 10f;
    public ChargeBar chargeBar;
    public AudioManager am;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (startTime < maxForce)
            {
                startTime += Time.deltaTime * chargeSpeed;
                Debug.Log(startTime);
                chargeBar.setSlider(startTime);
            }
            else
            {
                startTime = maxForce;
                chargeBar.setSlider(startTime);
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (startTime < minForce)
            {
                chargeBar.resetSlider();
                startTime = minForce;
                Debug.Log("Arrow shot at mininmum Force");
                am.Play("BowShot");
                float delta = startTime - Time.deltaTime;
                GameObject go = Instantiate(arrow, arrowSpawnPoint.transform.position, Quaternion.identity);
                Rigidbody rb = go.GetComponent<Rigidbody>();

                float adjustestedForce = shootForce * delta;                
                rb.velocity = cam.transform.forward * adjustestedForce;
                startTime = 0;
            }
            else
            {
                chargeBar.resetSlider();
                float delta = startTime - Time.deltaTime;
                am.Play("BowShot");
                GameObject go = Instantiate(arrow, arrowSpawnPoint.transform.position, Quaternion.identity);
                Rigidbody rb = go.GetComponent<Rigidbody>();
                float adjustestedForce = shootForce * delta;
                rb.velocity = cam.transform.forward * adjustestedForce;
                startTime = 0;
            }
        }
    }
}
