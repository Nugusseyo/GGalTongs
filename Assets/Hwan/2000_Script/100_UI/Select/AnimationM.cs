using UnityEngine;

public class AnimationM : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
    }
}
