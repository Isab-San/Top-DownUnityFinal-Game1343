using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    //public HealthBar healthbar;

    /*public float speed = 3;

    Animator playerAnim;

    private Vector3 target;
    public GameObject player;
    public SpriteRenderer playerSprite;

    private const float m_xOffset = 90f;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
        //playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * h * Time.deltaTime * speed);
        transform.Translate(Vector3.up * v * Time.deltaTime * speed);

        playerAnim.SetFloat("speed", Mathf.Abs(h));

        //playerSprite.flipX = h < 0;
    }

    private void FixedUpdate()
    {
        var mousePositon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var direction = mousePositon - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + m_xOffset, Vector3.forward);
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            GameManager.instance.playerHealth -= 1;
            //HealthBarScript.SetHealth(GameManager.instance.playerHealth);

            if(GameManager.instance.playerHealth == 0)
            {
                SceneManager.LoadScene("GameOverScene");
                GameManager.instance.playerHealth = 5;
                
            }
        }
    }

    [SerializeField] private float speed = 1f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 mousePosition;

    //public int maxHealth = 100;
    //public int currentHealth;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}

