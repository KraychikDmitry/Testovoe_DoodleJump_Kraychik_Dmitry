using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformBase : MonoBehaviour
{
    protected float jumpForce = 8f;
    protected virtual void JumpForcePlayer(Collision2D collision)
    {
        Rigidbody2D playerRB = collision.transform.GetComponent<Rigidbody2D>();
        playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            JumpForcePlayer(collision);
        }
    }

    protected virtual void OnBecameInvisible()
    {
        Camera Cam = Camera.main;
        Vector3 ViewPort = Cam.WorldToViewportPoint(transform.position);

        if (ViewPort.y < 0)
        {
            transform.parent.GetComponent<Generator>().MovePlatform(transform);
        }
    }
}
