using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Transform tf;
    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] private float moveSpeed;
    [SerializeField] private LayerMask layerMask;

    public Transform attackPoint;
    public Vector3 targetAttack;
    public float attackRange = 4f;

    public Bullet weaponBullet;
    //private var hammer;
    private GameObject bullet;
    private bool canAttack;
    private bool isMoving;
    private bool isAttack;
    private void Awake()
    {
        isMoving = false;
        canAttack = false;
    }

    void Update()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);
        if (rb.velocity.magnitude <= 0f)
        {
            isMoving = false;
            Target();
            ChangeAnim(Constant.ANIM_IDLE);
            if (Vector3.Distance(targetAttack, tf.position) < attackRange)
            {

                tf.LookAt(targetAttack);
            }
            else
            {
                
            }

            if (Input.GetMouseButtonDown(0))
            {
                Throw();
            }
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            isMoving = true;
            canAttack = true;
            ChangeAnim(Constant.ANIM_RUN);

        }

    }

    public override void OnInit()
    {
        base.OnInit();
    }


    public override void AttackRange()
    {
        base.AttackRange();
    }

    public override void ChangeSize()
    {
        base.ChangeSize();
    }


    public void Throw()
    {
        ChangeAnim(Constant.ANIM_ATTACK);
        //var hammer = Instantiate(weaponPrefab, attackPoint.position, attackPoint.rotation).GetComponent<Hammer>();
        ////hammer.rb.velocity = Vector3.forward * 5f;
        //hammer.SetTarget(Vector3.zero);
        Debug.Log(targetAttack);
        //weaponBullet.SetTarget(targetAttack);
        bullet = ObjectPool.instance.GetPooledObject();
        if(bullet != null)
        {
            bullet.transform.position = attackPoint.position;
            //StartCoroutine(Delay(0.2f));
        }
    }



    public void Target()
    {
        Collider[] hitColliders = Physics.OverlapSphere(tf.position, attackRange,layerMask);
        for(int i = 0; i < hitColliders.Length; i++)
        {
            GameObject hitCollider = hitColliders[i].gameObject;
            if (hitCollider.CompareTag(Constant.TAG_BOT))
            {
                targetAttack = hitCollider.transform.position;
            }
        }
    }

    public void ResetAttack()
    {
        ChangeAnim(Constant.ANIM_IDLE);
        isAttack = false;
    }


    IEnumerator Delay(float s)
    {
        yield return new WaitForSeconds(s);
        bullet.GetComponent<Rigidbody>().velocity = (targetAttack - attackPoint.position);
        bullet.SetActive(true);

    }
}
