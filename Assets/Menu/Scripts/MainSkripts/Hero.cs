using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : Entity
{
    
    public AudioSource jumpSound;
    public AudioSource damageSound;
    public AudioSource scorePickupSound;

    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private int score = 0;

    public GameObject GameMenu; // Ссылка на объект канваса для меню паузы
    private bool isPaused = false;

    public GameObject SceneManager;
    public Text Score;
    public Image[] HeartsBar;

    private bool isGrounded = false;
    private float previousY;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    public static Hero Instance { get; set; }


    private void Start()
    {
        

        previousY = transform.position.y;
    }

    private States State
    {
        get { return (States)anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int)value); }
    }


    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        // Проверяем нажатие кнопки ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Переключаем состояние паузы
            isPaused = !isPaused;

            // Если игра на паузе, активируем канвас и останавливаем время
            if (isPaused)
            {
                Time.timeScale = 0; // Останавливаем время
                if (GameMenu != null)
                {
                    GameMenu.SetActive(true);
                }
            }
            else
            {
                // Если игра не на паузе, деактивируем канвас и возобновляем время
                Time.timeScale = 1; // Возобновляем время
                if (GameMenu != null)
                {
                    GameMenu.SetActive(false);
                }
            }
        }
        if (lives == 0)
        {
            damageSound.Play();
            Die();
            SceneManager.SetActive(true);
        }

        if (isGrounded)
            State = States.idle;

        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Gem"))
        {
            scorePickupSound.Play();
            score += 1;
            Score.text = score.ToString();

        }
        if (other.tag == "HeartGem")
        {
            scorePickupSound.Play();
            score += 1;
            Score.text = score.ToString();
            lives += 1;
            if (lives > 5)
                lives = 5;
            HeartsBar[lives - 1].enabled = true;

            Debug.Log($"hero have {lives} hp");
        }
        if (other.tag == "Portal")
        {
            Debug.Log($"hero collide with {other.tag}");
        }
    }

    private void Run()
    {
        if (isGrounded)
            State = States.run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        jumpSound.Play();
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        isGrounded = collider.Length > 0;

        float currentY = transform.position.y;
        int h = 0;
        if (currentY != previousY)
        {
            if (currentY < previousY)
               h = 1;
            previousY = currentY;
        }


        if (!isGrounded && (h == 0))
            State = States.up;
        if (!isGrounded && (h == 1))
            State = States.down;


    }



    public override void GetDamage()
    {
        damageSound.Play();
        lives -= 1;
        HeartsBar[lives].enabled = false;
        Debug.Log($"hero have {lives} hp");
    }
}

public enum States
{
    idle,
    run,
    up,
    down
}