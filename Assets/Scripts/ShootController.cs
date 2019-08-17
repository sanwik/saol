using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Camera camera;
    public bool hasClickedOnce = false;
    public AudioSource shotSound;
    public GameObject bulletClone;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Input.mousePosition.y);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !hasClickedOnce && Input.mousePosition.y < 310)
        {   
            Debug.Log("Left " + Input.mousePosition);
            Shoot();
            hasClickedOnce = true;
        }
    }

    void Shoot()
    {   

        var mousePos = Input.mousePosition;
        mousePos.z = 99; // select distance = 10 units from the camera
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        bulletClone = Instantiate(bulletPrefab, transform.position, transform.rotation);
        shotSound.Play(0);

    }

}