using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float score = 0;
    [SerializeField] private float scoreScale = 2;
    [SerializeField] private TextMeshProUGUI scoretext;
    private GameManager gameManager;
    public Vector3 collisionForce;
    public Animator animator;
    public GameObject GameObject;
    private MeshRenderer mesh;
    private AudioSource audio;
 //   private bool NoCollision = false;
    void Start()
    {
        mesh = GameObject.GetComponent<MeshRenderer>();
        gameManager = FindAnyObjectByType<GameManager>();
        //animator = gameManager.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        gameObject.transform.rotation = Quaternion.identity;
        score += Time.deltaTime;
        scoretext.text = ((int)(score / scoreScale)).ToString();
        if(transform.position.y < -1)
            gameManager.EndGame();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if(GameObject.GetComponent<MeshCollider>().isTrigger == false)
            {
                audio.Play();
                collision.gameObject.GetComponent<Rigidbody>().AddForce(collisionForce);
                DisplayEndAnimation();
                gameManager.EndGame();
            }
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            mesh.enabled = false;
        }
    }



    public void DisplayEndAnimation()
    {
        animator.SetBool("IsRunning", false);
        animator.SetBool("IsDeath", true);
        
    }

    public void DeactivateCollision()
    {
        GameObject.GetComponent<MeshCollider>().isTrigger = true;
    }

    public void activateCollision()
    {
        GameObject.GetComponent<MeshCollider>().isTrigger = false;
    }
}
