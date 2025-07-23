using UnityEngine;

[CreateAssetMenu(menuName = "Chunks/Transition")]
public class BiomeTransition : ScriptableObject
{
    public BiomeInfo OutboundBiome;
    public BiomeInfo InboundBiome;
    public Chunk TransitionChunk;
}
