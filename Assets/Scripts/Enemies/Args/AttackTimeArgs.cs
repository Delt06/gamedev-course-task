using System;

namespace Enemies.Args
{
    public class AttackTimeArgs : EventArgs
    {
        public float AttackTime { get; set; }

        public AttackTimeArgs(float attackTime)
        {
            AttackTime = attackTime;
        }
    }
}