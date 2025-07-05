using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    public float speedIncrease = 0.5f;
    private Rigidbody2D rb;
    private Vector2 initialVelocity;

    public AudioSource SomDaBola;

    public Sprite spriteNormal;
    public Sprite spriteTriste;

    private SpriteRenderer spriteRenderer;
    private Coroutine tristezaCoroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialVelocity = new Vector2(speed, speed);
        spriteRenderer.sprite = spriteNormal;
        LaunchBall();
    }

    void LaunchBall()
    {
        float xDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        float yDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(xDirection, yDirection) * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        SomDaBola.Play();

        Vector2 direction = rb.velocity.normalized;
        float currentSpeed = rb.velocity.magnitude;
        float newSpeed = currentSpeed + speedIncrease;
        rb.velocity = direction * newSpeed;

        if (collision.gameObject.CompareTag("Player1") ||
            collision.gameObject.CompareTag("Player2") ||
            collision.gameObject.CompareTag("Teto") ||
            collision.gameObject.CompareTag("Piso"))
        {
            // Se já estiver em uma corrotina de tristeza, para ela
            if (tristezaCoroutine != null)
            {
                StopCoroutine(tristezaCoroutine);
            }

            // Inicia nova corrotina para ficar triste por 1 segundo
            tristezaCoroutine = StartCoroutine(FicarTristePorUmSegundo());
        }
    }

    IEnumerator FicarTristePorUmSegundo()
    {
        spriteRenderer.sprite = spriteTriste;
        yield return new WaitForSeconds(1f);
        spriteRenderer.sprite = spriteNormal;
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x) < 0.1f && Mathf.Abs(transform.position.y) < 0.1f)
        {
            rb.velocity = initialVelocity;
        }
    }
}
