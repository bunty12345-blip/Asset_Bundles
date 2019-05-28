
using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateAssetBundles : Editor
{
    private const string V = "C:/Users/KIIT/Desktop/AssetBundle";

    [MenuItem("Assets/Create Asset Bundle")]
    static void ExportBundle()
    {
        BuildPipeline.BuildAssetBundles(V, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
  
    }

}
