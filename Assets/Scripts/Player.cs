using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IMovable
{
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D playerRB;
    public bool isButtonInput;
    public float horizntalMovement;

    public UIManager UI;

    void Start()
    {
        isButtonInput = false;
        playerRB = transform.GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        playerRB.velocity = new Vector2(horizntalMovement * movementSpeed, playerRB.velocity.y);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        if (!isButtonInput)
        {
            horizntalMovement = Input.GetAxis("Horizontal");
        }

        if (horizntalMovement > 0)
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        else if (horizntalMovement < 0)
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
    }

    private void OnBecameInvisible()
    {
        Camera Cam = Camera.main;
        Vector3 ViewPort = Cam.WorldToViewportPoint(transform.position);

        if (ViewPort.y < 0)
        {
            UI.OpenGameOverCanvas();
        }
    }
}
