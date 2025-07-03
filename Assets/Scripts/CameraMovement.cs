using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private int speed = 5;
    private Vector3 direction;

    public float rotationSpeed; //speed of camera rotation
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        // get user input
        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = Vector3.back;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            direction = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            direction = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            direction = Vector3.down;
        }
        else
        {
            direction = Vector3.zero;
        }

        //move camera
        Vector3 newPos = speed * Time.deltaTime * direction + transform.localPosition;

        transform.localPosition = newPos;
        CamOrbit(); //get camera rotation

    }

    private void CamOrbit() //camera rotation function
    {
        if ((Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0) && Input.GetKey(KeyCode.Mouse2)) //ensures that this only gets called when mouse movement is not 0
        {
            //get inputs
            float verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            float horizontalInput = Input.GetAxis("Mouse X") * -rotationSpeed * Time.deltaTime;

            //rotate
            transform.Rotate(Vector3.right, verticalInput);
            transform.Rotate(Vector3.up, horizontalInput, Space.World);

        }
    }
}
