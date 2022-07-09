using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : PlatformBase
{
    protected override void OnCollisionEnter2D(Collision2D collision) { }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.velocity.y <= 0f)
            Destroy(gameObject);
    }
}
