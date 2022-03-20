using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private Transform playerTransform;
    public Animator spiralAnim;
    public Animator orbitalAnim;
    public Animator beamAnim;
    public Animator sweepAnim;
    public GameObject trackerAttackObject;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void OrbitalAttack()
    {
        orbitalAnim.SetTrigger("ActivateAttack");
    }

    public void SpiralAttack()
    {
        spiralAnim.SetTrigger("ActivateAttack");
    }

    public void BeamAttack()
    {
        beamAnim.SetTrigger("ActivateAttack");
    }

    public void SweepAttack() 
    {
        sweepAnim.SetTrigger("ActivateAttack");
    }

    public void TrackerAttack() 
    {
        Instantiate(trackerAttackObject, transform);
    }

    private void Target(Transform attackTransform)
    {
        Vector2 direction = playerTransform.position - attackTransform.position;
        attackTransform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }
}
