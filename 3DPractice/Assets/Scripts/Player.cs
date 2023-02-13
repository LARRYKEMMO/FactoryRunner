using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float score = 0;
    [SerializeField] private float scoreScale = 2;
    [SerializeField] private TextMeshProUGUI scoretext;
    private GameManager gameManager;
    public Vector3 collisionForce;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        score += Time.deltaTime;
        scoretext.text = ((int)(score / scoreScale)).ToString();
        if(transform.position.y < -1)
            FindAnyObjectByType<GameManager>().EndGame();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(collisionForce);
            gameManager.EndGame();
        }

    }
}
