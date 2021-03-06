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

    public int ChooseAttack()
    {
        int attackIndex = orbitalsOut ? PickAttack() : 1;
        while (orbitalsOut && attackIndex == 1){
            attackIndex = PickAttack();
        }
        if (attackIndex == 1)
            orbitalsOut = true;
        Debug.Log("Attack " + attackIndex.ToString());
        PickSound(attackIndex);
        return attackIndex;
    }

    private int PickAttack()
    {
        Debug.Log(battlePhase);
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

    // order of the attacks
    private void PickSound(int index) {
        switch (index) {
            case 0: // Spiral
                audioManager.Play("SpiralAttack");
                return;
            case 1: // Orbital
                audioManager.Play("Orbital");
                return;
            case 2: // Beam
                //audioManager.Play("BeamAttack");
                return;
            case 3: // Sweep
                //audioManager.Play("Sweep");
                return;
            case 4: // Tracker
                audioManager.Play("Tracker");
                return;
        }
    }
}
