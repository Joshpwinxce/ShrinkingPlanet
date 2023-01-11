using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10f;
	public float rotationSpeed = 10f;

	private float rotation;
	private Rigidbody rb;

    /*private float _startingPosition;
    private float startingPosition;
    private float turnspeed;
    public float rotatespeed = 10f;*/

    //New change
    public string horizontalAxis = "Horizontal";
    private float inputHorizontal;

    void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		rotation = Input.GetAxisRaw("Horizontal");

        inputHorizontal = SimpleInput.GetAxis(horizontalAxis); //New Change

        transform.Rotate(0f, inputHorizontal * 5f, 0f, Space.World); //New Change 
    }

	void FixedUpdate ()
	{
		rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
		Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;

        Quaternion deltaRotation = Quaternion.Euler(yRotation);
		Quaternion targetRotation = rb.rotation * deltaRotation;
		rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 100f * Time.deltaTime));

       /* if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startingPosition = touch.position.x;
                    Debug.Log("There is a Touch");
                    break;
                case TouchPhase.Moved:
                    if (startingPosition > touch.position.x)
                    {
                        transform.Rotate(Vector3.back, -turnspeed * Time.deltaTime);
                    }
                    else if (startingPosition < touch.position.x)
                    {
                        transform.Rotate(Vector3.back, rotatespeed * Time.deltaTime);
                    }
                    break;
                case TouchPhase.Ended:
                    Debug.Log("Touch Phase Ended.");
                    break;
            }
        } */
    }

}
