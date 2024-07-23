using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Manages the location of the firepoint. Changes it based on animation.
 */
public class FirePointManager : MonoBehaviour
{
    /** positionList Order:
     *          Whenever aplicable, follow the index of animation states when adding this. 
            1.) BackR, 2.) BackL, 3.) FrontL, 4.) FrontR
     */
    [SerializeField]
    [Tooltip ("Whenever aplicable, follow the index of animation states when adding this.")]
    private List<Vector2> positionList;

    private Transform fpTransform;
    private void Awake()
    {
        fpTransform = this.transform;
    }
    public void ChangeFirePointLocation(int index)
    {
        fpTransform.localPosition = positionList[index];
    }
}
