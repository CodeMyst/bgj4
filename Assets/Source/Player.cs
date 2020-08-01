using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;

    public Rigidbody2D rb;

    private bool grounded = false;

    public float dir = 1;

    public void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");

        if (x < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            dir = -1;
        }
        else if (x > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            dir = 1;
        }

        if (grounded && Input.GetAxisRaw("Jump") > 0)
        {
            rb.velocity = new Vector2(0, jumpForce);
            grounded = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "rewind")
        {
            grounded = true;
        }
    }
}
