using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    public Transform tf;

    private float speed = 5f;


    public void SetTarget(Vector3 position)
    {
        //rb.velocity = (position - tf.position) * speed;
        //Vector3.MoveTowards(transform.position, position,speed *Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Constant.TAG_BOT))
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator DeActive(float s)
    {
        yield return new WaitForSeconds(s);
        gameObject.SetActive(false);   
    }
}
