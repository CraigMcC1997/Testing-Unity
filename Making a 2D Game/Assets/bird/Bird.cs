using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Vector3 initialPosition;
    [SerializeField] float launchPower = 500;
    bool birdLaunched;
    float timeSittingAround;
    [SerializeField] int lives = 5;
    bool loseLive = false;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);


        if(lives <= 0)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }


        if (birdLaunched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            timeSittingAround += Time.deltaTime;
        }

        if (transform.position.y > 10 ||
            transform.position.y < -10 ||
            transform.position.x > 10 ||
            transform.position.x < -20 ||
            timeSittingAround > 2)
        {
            timeSittingAround = 0;
            transform.position = initialPosition;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0f;

            //string currentSceneName = SceneManager.GetActiveScene().name;
            //SceneManager.LoadScene(currentSceneName);
        }  
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
        loseLive = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        birdLaunched = true;
        GetComponent<LineRenderer>().enabled = false;
        loseLife();
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }

    private void loseLife()
    {
        if(loseLive)
        {
            loseLive = false;
            lives--;
        }
    }
}
