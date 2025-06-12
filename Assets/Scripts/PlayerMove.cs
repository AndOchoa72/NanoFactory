using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float PSpeed = 3f;
    [SerializeField] public bool oldMoving, isMoving = false;
    [SerializeField] private Animator animator;
    private float PSpdX, PSpdY = 0f;
    private bool MIzq = false;
    private Vector2 PSpd;
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

        PSpd = new Vector2(PSpdX, PSpdY);
        PSpd.Normalize();
        rb.velocity = PSpeed * PSpd;

        if (oldMoving != isMoving)
        {
            animator.SetBool("isMoving", isMoving);
            oldMoving = isMoving;
        }
    }
}
