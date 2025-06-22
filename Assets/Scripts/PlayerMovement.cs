using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    private Vector2 screenBounds;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Calculate screen bounds in world units
        Camera cam = Camera.main;
        Vector3 screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
        screenBounds = new Vector2(screenTopRight.x - 0.5f, screenTopRight.y - 0.5f); // Subtract margin based on player size
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;

        // Clamp position to screen bounds
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -screenBounds.x, screenBounds.x);
        clampedPos.y = Mathf.Clamp(clampedPos.y, -screenBounds.y, screenBounds.y);
        transform.position = clampedPos;
    }
}
