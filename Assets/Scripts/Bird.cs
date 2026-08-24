using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    [SerializeField] private float flapForce = 7f;
    [SerializeField] private GameObject explosionEffect;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    private bool hasExploded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (hasExploded) return;

        if (GameManager.Instance.State == GameManager.GameState.Menu)
        {
            bool clickedUI = Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject();

            if (!clickedUI && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
            {
                GameManager.Instance.StartGame();
            }
            return;
        }

        if (GameManager.Instance.State != GameManager.GameState.Playing) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Flap();
        }

        if (transform.position.y < -6f)
        {
            Explode();
        }
    }

    private void Flap()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, flapForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }

    private void Explode()
    {
        if (hasExploded) return;
        hasExploded = true;

        spriteRenderer.enabled = false;
        col.enabled = false;
        rb.simulated = false;

        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        GameManager.Instance.GameOver();
    }
}