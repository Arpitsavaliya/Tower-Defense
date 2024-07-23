using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * TurretAnimation: Dedicated on controlling the turret's animations. Shooting and Idle states exist. 
 * TODO: Make this and EnemyAnimation into a polymorphized script. They have the same functions...
 */
[RequireComponent(typeof(Animator))]
public class TurretAnimation : MonoBehaviour
{
    // -- DEPENDENCY: Animator Component. -- //
    private Animator turretAnim;
    // -- DEPENDENCY: Optional FirePointManager Component. -- //
    [SerializeField]
    private FirePointManager firePointManager;
    private void Awake()
    {
        turretAnim = GetComponent<Animator>();
    }
    /** PlayShootingAnimation
     * @params _direction: Direction in which the bullet is shooting. 
     */
    public void PlayShootingAnimation(Vector2 _direction)
    {
        Vector2 normDir = _direction.normalized;
        float step = 90; // - As enemies only have 4 animation states (diagonals), angles are between 90°.
        float currAngle = Vector2.SignedAngle(Vector2.right, normDir); // Gets signed angle of normDir. (in relation to x).
        if (currAngle < 0) currAngle += 360; // - Need to keep it in the positive range (0 - 360).
        float stepCount = currAngle / step; // - Limit angle to a range of (0 - 3)
        // -- > Play SHOOTING Animation. <--
        int index = Mathf.FloorToInt(stepCount);
        TurretAnimationStates currState = (TurretAnimationStates)index; // - Int 0 - 3 rounded down.
        turretAnim.Play(currState.ToString()); //Plays animation based on enum's name. 
        if (firePointManager != null)
        {
            firePointManager.ChangeFirePointLocation(index);
        }
    }
}
public enum TurretAnimationStates
{
    // Shooting Animations; --
    Shoot_BackR, //Cuadrant 1 (0 - 90)
    Shoot_BackL, //Cuadrant 2 (90 - 180)
    Shoot_FrontL, //Cuadrant 3 (180 - 270)
    Shoot_FrontR //Cuadrant 4 (270 - 360)
}
