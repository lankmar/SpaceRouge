using Gameplay.Space.Generator;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Scriptables.Space
{
    [CreateAssetMenu(fileName = nameof(SpaceConfig), menuName = "Configs/Space/" + nameof(SpaceConfig))]
    public sealed class SpaceConfig : ScriptableObject
    {
        [field: SerializeField, Header("TileBase")] public TileBase BorderTileBase { get; private set; }
        [field: SerializeField] public TileBase BorderMaskTileBase { get; private set; }
        [field: SerializeField] public TileBase NebulaTileBase { get; private set; }
        [field: SerializeField] public TileBase NebulaMaskTileBase { get; private set; }

        [field: SerializeField, Min(1), Header("Map Settings")] public int WidthMap { get; private set; } = 128;
        [field: SerializeField, Min(1)] public int HeightMap { get; private set; } = 128;
        [field: SerializeField, Min(1)] public int OuterBorder { get; private set; } = 3;
        [field: SerializeField, Min(0)] public int InnerBorder { get; private set; } = 4;
        [field: SerializeField] public SmoothMapType SmoothMapType { get; private set; } = SmoothMapType.MooreNeighborhood;
        [field: SerializeField, Min(0)] public int FactorSmooth { get; private set; } = 4;
        [field: SerializeField] public RandomType RandomType { get; private set; } = RandomType.Random;
        [field: SerializeField, Range(0.01f, 1f)] public float Chance { get; private set; } = 0.475f;

        [field: SerializeField, Min(0), Header("Star Settings")] public int StarCount { get; private set; } = 20;
        [field: SerializeField] public bool AutoRadius { get; private set; } = true;
        [field: SerializeField, Min(0)] public int ManualRadius { get; private set; } = 5;

        [field: SerializeField, Min(0), Header("Star Settings")] public float ObstacleForce { get; private set; } = 1.5f;
    }
}