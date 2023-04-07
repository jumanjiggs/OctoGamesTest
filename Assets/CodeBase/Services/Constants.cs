using UnityEngine;

namespace CodeBase.Services
{
    public static class Constants 
    {
        public static readonly int Move = Animator.StringToHash("Move");
        public static readonly int Attack = Animator.StringToHash("Attack");
        public const string Character = "Character";
        public const float Radius = 1f;
        public const float Distance = 1f;
    }
}