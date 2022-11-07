using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] public Rigidbody rb;
    public Weapon weapon;

    public bool isDead;

    private string currentAnimName;
    public void Start()
    {

    }
    public virtual void OnInit()
    {

    }
    public virtual void ChangeSize()
    {

    }
    public virtual void AttackRange()
    {
        
    }
    public void OnHit(bool hit)
    {
        
    }


    protected void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }
}
