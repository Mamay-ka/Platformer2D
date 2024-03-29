using System;
using UnityEngine;

namespace Gameplay.Enemy.Behaviour
{
    [Serializable]
    public sealed class EnemyBehaviourConfig
    {
        [field: SerializeField] public EnemyState StartEnemyState { get; private set; } = EnemyState.PassiveRoaming;
        [field: SerializeField] public float PlayerDetectionRadius { get; private set; }
        [field: SerializeField] public float CallToArmsRadius { get; private set; }
        [field: SerializeField] public float ApproachDistance { get; private set; }
        [field: SerializeField] public float TimeToPickNewAngle { get; private set; }
        [field: SerializeField, Min(1)] public float FiringAngle { get; private set; }
    }
}