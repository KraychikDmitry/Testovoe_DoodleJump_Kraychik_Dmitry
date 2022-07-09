using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : PlatformBase, IMovable
{
    [SerializeField] private float movementSpeed = 1;
    public bool isUpDown;
    public float wayPointDestiantion = 4;
    private Rigidbody2D platformRB;
    private List<Vector3> wayPoints = new();
    
    private int i = 0;

    private void Start()
    {
        platformRB = transform.GetComponent<Rigidbody2D>();
        SetWayPoints();
    }

    private void SetWayPoints()
    {
        wayPoints.Clear();
        if (isUpDown)
        {
            wayPoints.Add(new Vector3(transform.position.x, transform.position.y - wayPointDestiantion, transform.position.z));
            wayPoints.Add(transform.position);
        }
        else
        {
            wayPoints.Add(new Vector3(transform.position.x - wayPointDestiantion, transform.position.y, transform.position.z));
            wayPoints.Add(transform.position);
        }
    }

    public void Move()
    {
        Vector3 movePosition = Vector3.MoveTowards(transform.position, wayPoints[i], movementSpeed / 100);
        platformRB.MovePosition(movePosition);
        if (Vector3.Distance(transform.position, wayPoints[i]) <= 0.001)
        {
            i = (i == 1) ? 0 : 1;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected override void OnBecameInvisible()
    {
        Camera Cam = Camera.main;
        Vector3 ViewPort = Cam.WorldToViewportPoint(transform.position);

        if (ViewPort.y < 0)
        {
            transform.parent.GetComponent<Generator>().MovePlatform(transform);
            SetWayPoints();
        }
    }
}
