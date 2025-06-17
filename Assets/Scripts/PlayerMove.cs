using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float PSpeed = 3f;
    [SerializeField] public bool oldMoving, isMoving = false;
    [SerializeField] private Animator animator;
    private float PSpdX, PSpdY = 0f;
    private bool MIzq = false;
    private Vector3 PSpd;
    Rigidbody2D rb;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMov();
    }

    void HandleMov()
    {
        isMoving = false;

        PSpdX = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            PSpdX = 1f;
            MIzq = false;
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            PSpdX = -1f;
            MIzq = true;
            isMoving = true;
        }
        sr.flipX = MIzq;

        PSpdY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            PSpdY = 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            PSpdY = -1f;
        }

        if (PSpdY != 0f) { isMoving = true; }

        PSpd = new Vector3(PSpdX, PSpdY, 0f).normalized;
        //    PSpd.Normalize();
        //    rb.velocity = PSpeed * PSpd;
        transform.position += PSpeed * Time.deltaTime * PSpd;

        if (oldMoving != isMoving)
        {
            animator.SetBool("isMoving", isMoving);
            oldMoving = isMoving;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Started! " + collision.collider.name);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision OnGoing! " + collision.collider.name);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Ended! " + collision.collider.name);
    }

}
