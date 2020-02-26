using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalCube : MonoBehaviour
{
    // Start is called before the first frame update

    private struct LocalMesh{
        public List<Vector3> points;
        public List<int> faces;

        public LocalMesh(List<Vector3> p, List<int> f){
            this.points = p;
            this.faces = f;
        }
    }
    LocalMesh myMesh;
    List<Vector3> vertices;
    List<int> index;

    void Start()
    {
        List<Vector3> vertices = new List<Vector3>{
            new Vector3(0.67832f,	-6.11971f,	-2.99274f),
            new Vector3(4.01266f,	-6.11971f,	-2.99274f),
            new Vector3(4.01266f,	-2.78537f,	-2.99274f),
            new Vector3(0.67832f,	-2.78537f,	-2.99274f),
            new Vector3(4.01266f,	-6.11971f,	-6.32708f),
            new Vector3(4.01266f,	-2.78537f,	-6.32708f),
            new Vector3(0.67832f,	-6.11971f,	-6.32708f),
            new Vector3(0.67832f,	-2.78537f,	-6.32708f)
        };
        
        List<int> index = new List<int>{
            0, 1, 2, 0, 2, 3, //FRONT
            1, 4, 5, 1, 5, 2, //RIGHT
            4, 6, 7, 4, 7, 5, //LEFT
            6, 0, 3, 6, 3, 7, //BACK
            3, 2, 5, 3, 5, 7, //TOP
            1, 0, 6, 1, 6, 4 //BOTTOM

        };

        myMesh = new LocalMesh(vertices, index);
        //triangleMesh.vertices = points;
        //triangleMesh.triangles = indices;

        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
        mr.sharedMaterial = new Material(Shader.Find("Standard"));
        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        // mf.mesh = triangleMesh;
        mf.mesh.vertices = myMesh.points.ToArray();
        mf.mesh.triangles = myMesh.faces.ToArray();
        // mf.mesh.RecalculateNormals();
    }
}