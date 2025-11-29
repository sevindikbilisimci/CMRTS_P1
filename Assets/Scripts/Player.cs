using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed = 3f;
    public float walkSpeed = 3f;
    public float runSpeed = 10f;
    CharacterController controller;

    public Transform cameraTransform;
    public float rotationSpeed = 10f;

    public float jumpHeight = 2000f;
    Vector3 velocity;
    public float gravity = -9.81f;


    [SerializeField] Animator animator; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 finalMove = Vector3.zero;

        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 yon = new Vector3 (h, 0f  ,v).normalized;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }

        if (yon.x != 0f || yon.z != 0f)
        {
            animator.SetBool("isWalking", true);

            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            camForward.y = 0f;
            camRight.y = 0f;

            Vector3 moveDir = (camForward * yon.z + camRight * yon.x).normalized;

            Quaternion targetRotation = Quaternion.LookRotation(moveDir);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            finalMove = moveDir * moveSpeed * Time.deltaTime;

        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // 🟢 Zıplama kontrolü
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // zemine sabitleme
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // 🟣 Yerçekimi uygulama
        velocity.y += gravity * Time.deltaTime;

        // 🟡 Hareketleri uygula
        controller.Move(finalMove + velocity * Time.deltaTime);


    }
}
