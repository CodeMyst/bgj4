using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
