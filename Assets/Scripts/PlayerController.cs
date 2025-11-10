using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timerText;

    Rigidbody2D rb;
    Vector2 move;
    bool jump = false;

    int score = 0;

    AudioSource src;
    public AudioClip jumpSound;
    public AudioClip crystalSound;

    public float Timer = 30;

    public int ylimit = 0;

    public LayerMask ground;


    //HEY I CHANGE THIS

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            ScreenCapture.CaptureScreenshot("screenshot.png");
        }

        Timer -= Time.deltaTime;
        timerText.text = "Time Left: " + Timer.ToString("0.");
        if(Timer < 0){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
        }

        if(transform.position.y < ylimit){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
        }

        var feet = new Vector2(transform.position.x, transform.position.y - 1f);
        var dimensions = new Vector2(0.5f, 0.1f);
        var grounded = Physics2D.OverlapBox(feet, dimensions, 0, ground);


        move.x = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && grounded){
            jump = true;
        }
        scoreText.text = "Score: " + score;
    }

    void FixedUpdate()
    {
        rb.AddForce(move * 8);
        if(jump){
            jump = false;
            src.PlayOneShot(jumpSound);
            rb.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Crystal")){
            src.PlayOneShot(crystalSound);
            score++;
            Destroy(collision.gameObject);
        }
    }

    public int GetScore(){
        return score;
    }
}
