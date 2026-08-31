using UnityEngine;

public class Entity : MonoBehaviour
{
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public StateMachine stateMachine { get; private set; }

    [Header("Collision Detection")]
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask groundLayerMask;
    [field: SerializeField] public bool groundDetected { get; private set; }
    [field: SerializeField] public bool wallDetected { get; private set; }

    protected virtual void Awake()
    {
        stateMachine = new StateMachine();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {

    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
    }

    protected void Flip()
    {
        transform.rotation = transform.rotation.y == 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(Vector2.zero);
    }

    protected void HandleCollisionDetection()
    {
        groundDetected = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayerMask);
        wallDetected = Physics2D.Raycast(transform.position, transform.right, wallCheckDistance, groundLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
        Gizmos.DrawLine(transform.position, transform.position + transform.right * wallCheckDistance);
    }
}
