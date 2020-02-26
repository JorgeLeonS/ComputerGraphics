using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
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
            new Vector3(-1, -1, 1),
            new Vector3(1, -1, 1),
            new Vector3(1, 1, 1),
            new Vector3(-1, 1, 1),
            new Vector3(1, -1, -1),
            new Vector3(1, 1, -1),
            new Vector3(-1, -1, -1),
            new Vector3(-1, 1, -1)
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

    List<Vector3> Rotate(Vector3[] points, float deg){
        List<Vector3> outPoints = new List<Vector3>();

        for(int i = 0; i < points.Length; i ++){
            Vector3 p1 = points[i];
            Vector4 h1 = new Vector4(p1.x, p1.y, p1.z, 1);

            float rad = deg * Mathf.Deg2Rad;
            Matrix4x4 rotMat = Matrix4x4.identity;

            rotMat[0, 0] = Mathf.Cos(rad);
            rotMat[0, 1] = -Mathf.Sin(rad);
            rotMat[1, 0] = Mathf.Sin(rad);
            rotMat[1, 1] = Mathf.Cos(rad);
            
            Vector4 h1r = rotMat * h1;

            Vector3 newPoint = new Vector3(h1r.x, h1r.y, h1r.z);
            outPoints.Add(newPoint);
            print("Old point: "+points[i]);
            print("New point: "+newPoint);
        }
        return outPoints;
    } 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f")){
            
            MeshFilter mf = gameObject.GetComponent<MeshFilter>();
            mf.mesh.vertices = Rotate(mf.mesh.vertices, -30.0f).ToArray();

        }
        if(Input.GetKey("g")){
            //Same as above, just another degree
            MeshFilter mf = gameObject.GetComponent<MeshFilter>();
            mf.mesh.vertices = Rotate(mf.mesh.vertices, 45.0f).ToArray();
        }
    }
}