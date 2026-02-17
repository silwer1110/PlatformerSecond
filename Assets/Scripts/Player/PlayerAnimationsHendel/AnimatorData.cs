using UnityEngine;

public static class AnimatorData
{
    public static class Params
    {
        public static readonly int Speed = Animator.StringToHash(nameof(Speed));
         
        public static readonly int EnemyOnRadius = Animator.StringToHash(nameof(EnemyOnRadius));
        public static readonly int EnemyOutOfRadius = Animator.StringToHash(nameof(EnemyOutOfRadius));

        public static readonly int PlayerOutOfRadius = Animator.StringToHash(nameof(PlayerOutOfRadius));
        public static readonly int PlayerOnRadius = Animator.StringToHash(nameof(PlayerOnRadius));
    }
}