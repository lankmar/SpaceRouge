using Gameplay.GameEvent;
using UnityEngine;

namespace Scriptables.GameEvent
{
    [CreateAssetMenu(fileName = nameof(CometConfig), menuName = "Configs/Comet/" + nameof(CometConfig))]
    public sealed class CometConfig : ScriptableObject
    {
        [field: SerializeField] public CometView CometView { get; private set; }
        [field: SerializeField, Min(1)] public int CometCount { get; private set; } = 1;
        [field: SerializeField, Min(0)] public float CheckRadius { get; private set; } = 5;
        [field: SerializeField, Min(0.1f)] public float Size { get; private set; } = 1f;
        [field: SerializeField, Min(0.1f)] public float Damage { get; private set; } = 1f;
        [field: SerializeField, Min(0.1f)] public float LifeTimeInSeconds { get; private set; } = 10.0f;
        [field: SerializeField, Min(0)] public float Offset { get; private set; } = 10;
        [field: SerializeField, Min(0)] public float MinSpeed { get; private set; } = 10;
        [field: SerializeField, Min(0)] public float MaxSpeed { get; private set; } = 50;
    }
}