using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector] public float _speed;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        Vanish();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_speed,_rb.linearVelocity.y);
    }

    private void Vanish()
    {
        if (transform.position.x < -61 || transform.position.x > 62)
        {
            Destroy(gameObject);
        }
    }

}
