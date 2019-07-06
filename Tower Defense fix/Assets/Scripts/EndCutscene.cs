using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutscene : MonoBehaviour
{
    public SceneFader fader;

    public Animator animator;
    //public Animation cutscene;

    public string levelName;

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            fader.FadeTo(levelName);
    }
}
