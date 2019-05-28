using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadAssetBundles : MonoBehaviour
{
    AssetBundle assetBundle;
    public string path;
    //public string assetName;
    IEnumerator coroutine;
    AssetBundle bundle;

  UnityEngine.Object Tree;
  UnityEngine.Object Skeleton;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownloadAndCache());
      

    }

    public void loadTree()
    {
        Tree = Instantiate(bundle.LoadAsset("Tree"));
        Destroy(Skeleton);
        
        
    }

    public void loadSkeleton()
    {
        Skeleton = Instantiate(bundle.LoadAsset("Skeleton"));
        Destroy(Tree);
    }

    IEnumerator DownloadAndCache()
    {
        // Wait for the Caching system to be ready
        while (!Caching.ready)
            yield return null;

        // Load the AssetBundle file from Cache if it exists with the same version or download and store it in the cache
        using (WWW www = WWW.LoadFromCacheOrDownload(path,1))
        {
            yield return www;
            if (www.error != null)
                throw new Exception("WWW download had an error:" + www.error);
            bundle = www.assetBundle;

        } // memory is freed from the web stream (www.Dispose() gets called implicitly)
    }


}
