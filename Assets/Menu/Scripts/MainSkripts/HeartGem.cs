using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartGem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Hero"))
        {
            Destroy(this.gameObject);
        }
    }
}
