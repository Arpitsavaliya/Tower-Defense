using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * EnemyAnimation: Dedicated on controlling the enemy's animations.
 */
[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    // -- DEPENDENCY: Animator Component. -- //
    private Animator enemyAnim;
    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();
    }
    public void SetRunningAnimations(Vector2 _direction)
    {
        Vector2 normDir = _direction.normalized;
        float step = 90; // - As enemies only have 4 animation states (diagonals), angles are between 90°.
        float currAngle = Vector2.SignedAngle(Vector2.right, normDir); // Gets signed angle of normDir. (in relation to x).
        if (currAngle < 0) currAngle += 360; // - Need to keep it in the positive range (0 - 360).
        float stepCount = currAngle / step; // - Limit angle to a range of (0 - 3)
        EnemyAnimationStates currState = (EnemyAnimationStates) Mathf.FloorToInt(stepCount); // - Int 0 - 3 rounded down.
        enemyAnim.Play(currState.ToString()); //Plays animation based on enum's name. 
    }
}
// --  These are the same names as the animation states on the Enemy Animators. --
//      -- They should also share these names to avoid reference errors! --
public enum EnemyAnimationStates
{
    Run_BackRight, //Cuadrant 1 (0 - 90)
    Run_BackLeft, //Cuadrant 2 (90 - 180)
    Run_FrontLeft, //Cuadrant 3 (180 - 270)
    Run_FrontRight //Cuadrant 4 (270 - 360)

}
