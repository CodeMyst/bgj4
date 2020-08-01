using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;

    public Rigidbody2D rb;

    private bool grounded = false;

    public float dir = 1;

    public GameObject bulletPrefab;
    public float bulletSpeed = 5;
    public float bulletCooldown = 1;
    private float bulletTimer = 0;

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

        if (bulletTimer >= bulletCooldown && Input.GetMouseButton(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var target = mousePos - transform.position;
            target.Normalize();
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(target, Vector3.forward));
            bullet.GetComponent<Rigidbody2D>().velocity = target * bulletSpeed;
            bulletTimer = 0f;
        }

        bulletTimer += Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "rewind")
        {
            grounded = true;
        }

        if (col.gameObject.tag == "spike")
        {
            Time.timeScale = 0f;
        }
    }
}
