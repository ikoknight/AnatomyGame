using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bone")
        {
            Destroy(other.gameObject);
        }
    }
}
