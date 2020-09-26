using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;
    Rigidbody rb_cube;
    private bool left = false;
    private bool right = false;

    private void OnMouseDown()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Update()
    {
        left = Input.GetKeyDown("a");
        right = Input.GetButtonDown("D");
    }

    private void FixedUpdate()
    {
        if (left)
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
            for (int i=0; i<destroyedVersion.transform.childCount; i++)
            {
                GameObject child = destroyedVersion.transform.GetChild(i).gameObject;
                Rigidbody childCube = child.GetComponent<Rigidbody>();
                childCube.velocity = new Vector3(0, 0, 10);

            }
        }
    }
}
