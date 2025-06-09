using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

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

        PSpdX = Input.GetAxisRaw("Horizontal");
        if (PSpdX > 0.5f)
        {
            MIzq = false;
            isMoving = true;
        }
        if (PSpdX < -0.5f)
        {
            MIzq = true;
            isMoving = true;
        }
        sr.flipX = MIzq;

        PSpdY = Input.GetAxisRaw("Vertical");
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
