using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comming : MonoBehaviour
{
    public GameObject MonsterSoundObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Destroy(MonsterSoundObject);
            }

        }
    }

}

