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

        // Unlit Material ����
        
        Material mat = new Material(Shader.Find("Unlit/Color"));
        if (mat1 == null) mat.color = Color.red;
        else mat.color = mat1.color;
        mr.sharedMaterial = mat;

        // Mesh ����
        Mesh mesh = new Mesh();
        mesh.name = "ProceduralTriangle";

        // ����
        mesh.vertices = new Vector3[] { a, b, c };

        // ��/�� �� �ﰢ��
        mesh.triangles = new int[]
        {
            0, 1, 2, // �ո�
            0, 2, 1  // �޸�
        };

        // ��� ���� Normal ���� ����
        mesh.normals = new Vector3[]
        {
            Vector3.forward, Vector3.forward, Vector3.forward
        };

        mf.sharedMesh = mesh;
    }
}
