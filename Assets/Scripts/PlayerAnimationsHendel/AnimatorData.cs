using UnityEngine;

public static class AnimatorData
{
    public static class Params
    {
        public static readonly int Speed = Animator.StringToHash(nameof(Speed));
        public static readonly int DistanceToTarget = Animator.StringToHash(nameof(DistanceToTarget));
    }
}