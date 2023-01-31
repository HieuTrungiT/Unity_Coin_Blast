using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGroupEnemy : MonoBehaviour
{
    [SerializeField] float _jumpForce = 0f;
    Rigidbody2D myRb2D;
    float[] leftAndRight = new float[2] { -1f, 1f };
    private void Awake()
    {
        myRb2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {

        myRb2D.velocity = Vector2.right;

    }
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            myRb2D.velocity = new Vector2(myRb2D.velocity.x + Random.Range(-2, 2), _jumpForce);
            transform.Rotate(new Vector3(0f,0f,Random.Range(-30,30)));
        }
    }
}
