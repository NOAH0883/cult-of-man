using UnityEngine;
using static UnityEngine.UI.Image;

public class playerController : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    Rigidbody rb;
    Vector3 movement;
    [SerializeField] float interactionRadius;
    [SerializeField] LayerMask interactionLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        InteractionCheck();
    }

    void Movement()
    {
        float movementx = Input.GetAxisRaw("Horizontal");
        float movementz = Input.GetAxisRaw("Vertical");

        movement = new Vector3 (movementx, 0f, movementz).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    void InteractionCheck()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Collider[] hitCollider = Physics.OverlapSphere(transform.position, interactionRadius, interactionLayer);
            foreach (var collider in hitCollider)
            {
                
                TestInteraction testInteraction = collider.GetComponent<TestInteraction>();
                testInteraction.Interact();

            }
        }
        
       


        //sphere raycast 
        //check if it interacts with a object on the interaction layer 
        // allow player to interact with it
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
