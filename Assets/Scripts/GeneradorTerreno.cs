
using UnityEngine;

public class GeneradorTerreno : MonoBehaviour
{   //He utilizado este script para generar parte del terreno de forma aleatoria
    private float perlinNoise = 0f;
    private float refinamiento = 0.01f;
    private float alturaMedia = 0.25f;
    public Terrain terreno;
    void Start()
    {
        float[,] alturas = terreno.terrainData.GetHeights(0, 0, terreno.terrainData.heightmapResolution, terreno.terrainData.heightmapResolution);
        
        for (int i = 0; i < alturas.GetLength(0); i++)
        {
            for (int j = 0; j < alturas.GetLength(1); j++)
            {
                perlinNoise = Mathf.PerlinNoise(i * refinamiento, j * refinamiento) * alturaMedia;
                alturas[i, j] = perlinNoise;
                

            }
        }
        //Esta línea, modifica el terreno cuando se ejecuta este Script, debe permanecer comentada,
        //de lo contrario, el terreno se modificará cada vez que se inicie el programa
        //terreno.terrainData.SetHeights(0, 0, alturas);
        


    }

}
