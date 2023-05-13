using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;


public class EnemyScript : MonoBehaviour
{
    Animator enemyAnim;

    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 1;

    //AudioSource aS;

    public SpriteRenderer enemySprite;
    //public float speed = 0;

    // Start is called before the first frame update

    [SerializeField]
    CinemachineVirtualCamera vc;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        enemyAnim= GetComponentInChildren<Animator>();
        //aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        direction.Normalize();
        movement = direction;

        /*float h = Input.GetAxis("Horizontal");
        enemyAnim.SetFloat("speed", Mathf.Abs(h));*/

        /*Vector2 playerDirection = (player.position - transform.position).normalized;

        RaycastHit2D[] hits = new RaycastHit2D[3];
        Vector2 rayStart = (transform.position + playerDirection) * rb.velocity.magnitude * Time.deltaTime;*/

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            
            SoundManager.instance.PlaySound(0);
            //screenshake
            vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 3;
            StartCoroutine(TurnOffShake());
            GameManager.instance.enemyHealth -= 1;
            if(GameManager.instance.enemyHealth == 0)
            {
                //play death anim
                
                SoundManager.instance.PlaySound(1);
                GameManager.instance.score++;
                Destroy(gameObject);
                GameManager.instance.enemyHealth = 2;
            }
        }
    }

    public IEnumerator TurnOffShake()
    {
        yield return new WaitForSeconds(0.5f);
        vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }
}
