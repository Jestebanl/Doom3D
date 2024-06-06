using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 20f;
    public float momentumDamping = 5f;

    private CharacterController myCC;//componente
    public Animator canAnim;
    private bool isWalking;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float myGravity = -10f;

    void Start()
    {
        myCC = GetComponent<CharacterController>();
    }


    void Update()
    {
        GetInput();
        MovePlayer();

        canAnim.SetBool("isWalking", isWalking);

    }

    void GetInput()
    {
        // Si estamos presionando w,a,s,d entonces nos va a dar -1 , 0 , 1 
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3(x: Input.GetAxisRaw("Horizontal"), 0f, z: Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);
            isWalking = true;
        }
        else
        {
            //Si no le estamos dando cualquier inputVector cuando el ultimo chequeo lo digire al zero
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentumDamping * Time.deltaTime);
            isWalking = false;
        }

        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);
        
    }

    void MovePlayer()
    {
        myCC.Move(motion: movementVector * Time.deltaTime);
    }

}
