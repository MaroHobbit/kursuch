using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Entity
{
    [SerializeField] private int lives = 3;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            lives -= 1;
            Debug.Log($"Worm have {lives} hp");
        }
        if (lives < 1)
            Die();
    }
}
