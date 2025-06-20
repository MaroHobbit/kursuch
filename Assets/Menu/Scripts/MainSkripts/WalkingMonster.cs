using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMonster : Entity
{
    [SerializeField] private int lives = 3;
    private bool isCollidingHorizontal = false;
    private float speed = 3.5f;
    private Vector3 dir;
    private SpriteRenderer sprite;

    private void Start()
    {
        dir = transform.right;
    }

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            lives -= 1;
            Debug.Log($"WalkingMonster have {lives} hp");
            if (lives < 1)
                Die();
        }

        foreach (ContactPoint2D contact in collision.contacts)
        {
            // Проверяем, есть ли контакт справа или слева от вашего объекта.
            if (contact.normal.x != 0)
            {
                isCollidingHorizontal = true;
                break; // Мы нашли соприкосновение, больше не нужно проверять.
            }
        }
    }

    private void Move()
    {


        if (isCollidingHorizontal == true)
        {
            dir *= -1f;
            isCollidingHorizontal = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime * speed);

        sprite.flipX = dir.x > 0.0f;
    }

    
}
