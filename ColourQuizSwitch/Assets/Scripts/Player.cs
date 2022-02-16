using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public bool hasMoved = true;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorPink;
    public Color colorMagenta;

    void Start()
    {
        SetRandomColor();
        hasMoved = true;
    }

    // Update is called once per frame
    void Update()
    {
        //might change to ontouch
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
            hasMoved = false;
        }
        // To allow the ball to keep bouncing at start ONLY when the player has not touched the play button or "bounce buttun"
        if((transform.position.y <= -4.4)&& hasMoved == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }

        Debug.Log(col.tag);

        if((col.tag != currentColor)&&(col.tag != "Star"))
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (col.tag == "LevelComplete")
        {
            Debug.Log("LevelComplete");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        
        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
            case 3:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
        }
    }

}
