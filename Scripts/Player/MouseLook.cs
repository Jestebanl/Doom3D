using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float sensitivity = 1.5f;
    public float smoothing = 1.5f;

    private float xMousePos;
    private float yMousePos;
    private float smoothedMousePosX;
    private float smoothedMousePosY;

    public float currentLookingPosX;
    private float currentLookingPosY;


    private void Start()
    {
        //bloquear y ocultar el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        GetInput();
        ModifyInput();
        MovePlayer();

    }

    void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
        yMousePos = Input.GetAxisRaw("Mouse Y");
    }

    void ModifyInput()
    {
        xMousePos *= sensitivity * smoothing;
        yMousePos *= sensitivity * smoothing;
        smoothedMousePosX = Mathf.Lerp(a: smoothedMousePosX, b: xMousePos, t: 1f / smoothing);
        smoothedMousePosY = Mathf.Lerp(a: smoothedMousePosY, b: yMousePos, t: 1f / smoothing);
    }

    void MovePlayer()
    {
        currentLookingPosX += smoothedMousePosX;
        currentLookingPosY += smoothedMousePosY;
        //transform.localRotation = Quaternion.AngleAxis(currentLookingPosX, transform.up);
        //transform.localRotation = Quaternion.AngleAxis(currentLookingPosY, transform.right);
        transform.localRotation = Quaternion.Euler(-currentLookingPosY, 0f, 0f);
        Debug.Log("Angulo camara " + currentLookingPosX);
    }


}
