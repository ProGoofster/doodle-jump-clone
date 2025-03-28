using System;
using System.CodeDom.Compiler;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject course;
    public GameObject bounds;
    public float moveSpeed = 10f;
    private Rigidbody2D rb;
    private float moveX;
    public float jumpForce = 9f;
    public float springForce = 15f;
    public int score = 0;

    public AudioClip jump;
    public AudioClip breakPlatform;
    public AudioClip spring;
    public AudioClip die;


    private GameObject[] playerVisuals;


    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        playerVisuals = new GameObject[transform.childCount];
        int index = 0;
        for (int i = 0; i < transform.childCount; i++) {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.name.StartsWith("PlayerVisuals")) {
                playerVisuals[index++] = child;
            }
        }
        Array.Resize(ref playerVisuals, index);
    }
    void LateUpdate() {
        foreach (GameObject playerVisual in playerVisuals) {
            if (moveX > 0) {
                playerVisual.transform.localScale = new Vector3(Mathf.Abs(playerVisual.transform.localScale.x), playerVisual.transform.localScale.y, playerVisual.transform.localScale.z);
            } else if (moveX < 0) {
                playerVisual.transform.localScale = new Vector3(-Mathf.Abs(playerVisual.transform.localScale.x), playerVisual.transform.localScale.y, playerVisual.transform.localScale.z);
            }
        }
    }
    void Update() {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
    }

    void FixedUpdate() {
        Vector2 velocity = rb.linearVelocity;
        velocity.x = moveX;
        rb.linearVelocity = velocity;

        bounds.transform.position = new Vector3(bounds.transform.position.x, this.transform.position.y, bounds.transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Vector2 velocity = rb.linearVelocity;
        // check if player is coming in from the top
        // reversed comparison because we're checking from the player
        if (collision.relativeVelocity.y >= 0) {
            if (collision.gameObject.tag == "Platform") {
                velocity.y = jumpForce;
                AudioSource.PlayClipAtPoint(jump, transform.position, 2.0f);
            }

            if (collision.gameObject.tag == "Spring") {
                velocity.y = springForce;
                AudioSource.PlayClipAtPoint(spring, transform.position, 2.0f);
            }

            rb.linearVelocity = velocity;

            if (collision.transform.parent.gameObject.tag == "Breaking") {
                collision.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(breakPlatform, transform.position, 2.0f);
            }

            foreach (GameObject playerVisual in playerVisuals) {
                Animator animator = playerVisual.GetComponent<Animator>();
                if (animator != null) {
                    animator.Play("Jump");
                }
            }
        }


    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "RightBound") {
            this.transform.position = new Vector3(this.transform.position.x - 20, this.transform.position.y, this.transform.position.z);
        }

        if (collision.gameObject.name == "LeftBound") {
            this.transform.position = new Vector3(this.transform.position.x + 20, this.transform.position.y, this.transform.position.z);
        }

        if (collision.gameObject.name == "Main Camera") {
            Debug.Log("Game Over");
            AudioSource.PlayClipAtPoint(die, transform.position, 2.0f);
            this.gameObject.SetActive(false);
            StartCoroutine(SwitchToMainMenuAfterAudio());
        }

        if (collision.gameObject.tag == "CourseSegment" && !collision.GetComponent<CourseGenerator>().GetCollided()) {
            score++;
        }
    }

    private IEnumerator SwitchToMainMenuAfterAudio() {
        yield return new WaitForSeconds(die.length);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
