using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TriangleMesh : MonoBehaviour
{
    public Vector3 a = Vector3.zero;
    public Vector3 b = Vector3.right;
    public Vector3 c = Vector3.up;

    [SerializeField] Material mat1;

    private void Awake()
    {
        var mf = GetComponent<MeshFilter>();
        var mr = GetComponent<MeshRenderer>();

        // Unlit Material 생성
        
        Material mat = new Material(Shader.Find("Unlit/Color"));
        if (mat1 == null) mat.color = Color.red;
        else mat.color = mat1.color;
        mr.sharedMaterial = mat;

        // Mesh 생성
        Mesh mesh = new Mesh();
        mesh.name = "ProceduralTriangle";

        // 정점
        mesh.vertices = new Vector3[] { a, b, c };

        // 앞/뒤 면 삼각형
        mesh.triangles = new int[]
        {
            0, 1, 2, // 앞면
            0, 2, 1  // 뒷면
        };

        // 모든 정점 Normal 같은 방향
        mesh.normals = new Vector3[]
        {
            Vector3.forward, Vector3.forward, Vector3.forward
        };

        mf.sharedMesh = mesh;
    }
}
