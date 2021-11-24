using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Hand : MonoBehaviour
{
    Animator animator;
    Rig rig;

    [SerializeField]
    float startTime = 0.25f;
    [SerializeField]
    float endTime = 0.55f;

    float percentComplete
    {
        get {
            AnimatorStateInfo currentAnimation = animator.GetCurrentAnimatorStateInfo(0);
            float percent = currentAnimation.normalizedTime % 1;

            percent -= startTime;
            percent /= endTime - startTime;

            if (percent <= 0 || percent >= 1)
                return 0;

            percent *= 2; //0 -> 2

            return (percent > 1) ? 2 - percent : percent;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rig = GetComponentInChildren<Rig>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.weight = percentComplete;
    }
}
