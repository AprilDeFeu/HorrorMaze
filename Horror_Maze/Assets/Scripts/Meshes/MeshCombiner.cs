using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    public Material mat;
    int num = 0;
    void Start()
    {
        Invoke("CombineMeshes", 0.1f);
    }
    public void CombineMeshes ()
    {
        MeshFilter[] filters = transform.GetComponentsInChildren<MeshFilter>();
        Mesh finalMesh = new Mesh();
        CombineInstance[] combiners = new CombineInstance[filters.Length];


        Debug.Log(name + " is combining " + filters.Length +" meshes.");

        for (int i = 0; i < filters.Length; i++)
        {
            if (filters[i].transform == transform) continue;
            combiners[i].subMeshIndex = 0;
            combiners[i].mesh = filters[i].sharedMesh;
            combiners[i].transform = filters[i].transform.localToWorldMatrix;
        }
        finalMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        finalMesh.CombineMeshes(combiners);
        finalMesh.Optimize();
        GetComponent<MeshFilter> ().sharedMesh = finalMesh;
        GetComponent<MeshRenderer>().material = mat;
        GetComponent<MeshCollider>().sharedMesh = finalMesh;


        var maze = GameObject.FindGameObjectWithTag("Maze");

        for (int i = 0; i < maze.transform.childCount; i++)
        {
            Destroy(maze.transform.GetChild(i).gameObject);
        }
    }

}
