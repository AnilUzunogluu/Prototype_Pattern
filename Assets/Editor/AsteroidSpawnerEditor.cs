using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AsteroidSpawner))]
public class AsteroidSpawnerEditor : Editor
{
    private string path;
    private string assetPath;
    private string fileName;


    private void OnEnable()
    {
        path = Application.dataPath + "/Asteroid";
        assetPath = "Assets/Asteroid/";
        fileName = "asteroid_" + System.DateTime.Now.Ticks.ToString();
    }

    public override void OnInspectorGUI()
    {
        AsteroidSpawner asteroidSpawner = (AsteroidSpawner) target;
        DrawDefaultInspector();

        if (GUILayout.Button("Create Asteroid"))
        {
            asteroidSpawner.CreateAsteroid();
        }

        if (GUILayout.Button("Save Asteroid"))
        {
            System.IO.Directory.CreateDirectory(path);
            Mesh mesh = asteroidSpawner.asteroid.GetComponent<MeshFilter>().sharedMesh;
            AssetDatabase.CreateAsset(mesh, assetPath + mesh.name + ".asset");
            AssetDatabase.SaveAssets();

            PrefabUtility.SaveAsPrefabAsset(asteroidSpawner.asteroid, assetPath + fileName + ".prefab");
        }
    }
}
