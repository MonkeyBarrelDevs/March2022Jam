using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossController : MonoBehaviour
{
    [SerializeField] float[] attackDelays;
    [SerializeField] float delayTimer = 5f;
    [SerializeField] float deathPanLaziness = 25f;
    protected RandomDestinationSetter moveRandomly;
    protected AIDestinationSetter moveTowardsPlayer;
    private AttackSelection selector;
    private Animator bossAnim;
    private GameContoller gameController;
    public bool isMovingRandomly = false;
    public bool isChasingPlayer = false;
    public cameraShake cameraShake;
    [SerializeField]
    [Range(0, 50)]
    public float duration = 0.15f;
    [Range(0,50)]
    public float magnitude = 0.4f;
    [SerializeField]
    [Range(0,50)]
    public float modifier = 0.0002f;
    // Start is called before the first frame update
    void Start()
    {
        FindReferences();
        MovePhaseCheck(isMovingRandomly, isChasingPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        MovePhaseCheck(isMovingRandomly, isChasingPlayer);

        delayTimer -= Time.deltaTime;
        if (delayTimer <= 0 && selector.isActiveAndEnabled) 
        {
            int attack = selector.ChooseAttack();
            delayTimer = attackDelays[attack];
            if (attack == 2) {
                Rumble();
            }
            bossAnim.SetTrigger("attack " + attack.ToString());
        }
    }

    protected void MovePhaseCheck(bool isMovingRandomly, bool isChasingPlayer)
    {
        if (isMovingRandomly)
        {
            moveRandomly.enabled = true;
            moveTowardsPlayer.enabled = false;
        }
        else if (isChasingPlayer)
        {
            moveTowardsPlayer.enabled = true;
            moveRandomly.enabled = false;
        }
        else 
        {
            moveTowardsPlayer.enabled = false;
            moveRandomly.enabled = false;
        }
    }

    void FindReferences()
    {
        gameController = FindObjectOfType<GameContoller>();
        moveRandomly = gameObject.GetComponent<RandomDestinationSetter>();
        moveTowardsPlayer = gameObject.GetComponent<AIDestinationSetter>();
        selector = GetComponent<AttackSelection>();
        bossAnim = GetComponent<Animator>();

    }

    public void SetChasing() 
    {
        isMovingRandomly = false;
        isChasingPlayer = true;
    }

    public void SetMoveRandomly() 
    {
        isMovingRandomly = true;
        isChasingPlayer = false;
    }

    public void SetStopMovement() 
    {
        isMovingRandomly = false;
        isChasingPlayer = false;
    }

    public void Stagger() 
    {
        bossAnim.SetTrigger("Stagger");
        dg_simpleCamFollow cam = FindObjectOfType<dg_simpleCamFollow>();
        cam.laziness = deathPanLaziness;
        cam.target = transform;
    }

    public void StaggerTransition() 
    {
        gameController.GoToNextPhase();
    }

    
     private void Rumble() {
        StartCoroutine(cameraShake.Shake(duration, magnitude, modifier));
    }
}
