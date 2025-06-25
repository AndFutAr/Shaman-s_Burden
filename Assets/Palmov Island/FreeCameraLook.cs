using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float lookSpeed = 3f;
    public float verticalAngleLimit = 89f;

    private float rotationX = 0f;
    private float rotationY = 0f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 currentRotation = mainCamera.transform.eulerAngles;
        rotationY = currentRotation.y;
        rotationX = currentRotation.x;
    }

    void Update()
    {
        // Вращение камеры мышью
        rotationY += Input.GetAxis("Mouse X") * lookSpeed;
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -verticalAngleLimit, verticalAngleLimit);

        mainCamera.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);

        // Движение на WASD
        Vector3 moveDirection = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        ).normalized;

        if (moveDirection != Vector3.zero)
        {
            Vector3 worldDirection = mainCamera.transform.TransformDirection(moveDirection);
            worldDirection.y = 0;
            transform.position += worldDirection * moveSpeed * Time.deltaTime;
        }
    }
}