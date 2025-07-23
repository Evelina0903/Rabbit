using UnityEngine;

[CreateAssetMenu(menuName = "Chunks/Biome")]
public class BiomeInfo : ScriptableObject
{
    public string BiomeName;
    public Chunk[] Chunks;
}
