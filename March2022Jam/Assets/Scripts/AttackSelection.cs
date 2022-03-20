using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSelection : MonoBehaviour
{
    [SerializeField] private int battlePhase;
    public bool trackerOut;
    public bool orbitalsOut;
    AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        trackerOut = false;
        orbitalsOut = false;
        audioManager = GetComponent<AudioManager>();

    }

    private void Update()
    {
        
    }

    public int ChooseAttack()
    {
        int attackIndex = PickAttack();
        while ((orbitalsOut && attackIndex == 1) || (trackerOut && attackIndex == 4)){
            attackIndex = PickAttack();
        }
        if (attackIndex == 1)
            orbitalsOut = true;
        if (attackIndex == 4)
        Debug.Log("Attack " + attackIndex.ToString());
        PickSound(attackIndex);
        return attackIndex;
    }

    private void PickSound(int index) {
        switch (index) {
            case 0: // Spiral
                audioManager.Play("SpiralAttack");
                return;
            case 1: // Orbital
                audioManager.Play("Orbital");
                return;
            case 2: // Beam
                audioManager.Play("BeamAttack");
                return;
            case 3: // Sweep
                audioManager.Play("Sweep");
                return;
            case 4: // Tracker
                audioManager.Play("Tracker");
                return;
        }
    }

    private int PickAttack()
    {
        switch (battlePhase)
        {
            case 1:
                return Random.Range(0, 3);
            case 2:
                return Random.Range(0, 4);
            case 3:
                return Random.Range(0, 5);
        }
        return -1;
    }
}
