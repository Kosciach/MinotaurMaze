using Kosciach;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerFlashlightController : PlayerControllerBase
{
    [Header("====Settings====")]
    [SerializeField] LayerMask _rayMask;
    [Range(25, 90)]
    [SerializeField] int _fov = 25;
    [Range(1, 25)]
    [SerializeField] int _lookDistance = 1;
    [Range(4, 50)]
    [SerializeField] int _rayCount = 4;



    private MeshFilter _meshFilter;


    private void Awake()
    {
        OnAwake();
        _meshFilter = GetComponent<MeshFilter>();

        CreateMesh();
    }
    private void Update()
    {
        //CreateMesh();
    }

    private void CreateMesh()
    {
        Mesh mesh = new Mesh();
        float angleBetweenRays = _fov / (_rayCount / 2);
        float rayHalfOffsetToLeft = (_rayCount + 1) / 2;
        int defaultWorldAngle = 90;
        float currentAngle = defaultWorldAngle + angleBetweenRays * rayHalfOffsetToLeft;

        _rayCount += _rayCount % 2 == 0 ? 1 : 0;


        Vector3[] vertices = new Vector3[_rayCount+1];
        Vector2[] uvs = new Vector2[vertices.Length];
        int[] triangles = new int[(_rayCount-1) * 3];

        vertices[0] = Vector3.zero;

        for (int i=0; i<_rayCount; i++)
        {
            Vector3 rayDir = KosciachUtilities.GetVectorFromAngleDeg(currentAngle);
            Debug.DrawRay(transform.position, rayDir * _lookDistance, Color.blue, 100);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDir, _lookDistance, _rayMask);
            if(hit)
            {
                Debug.Log("Add vertices from point");
                vertices[i + 1] = hit.point;
            }
            else
            {
                Debug.Log("Add vertices from calculation");
                vertices[i + 1] = transform.position + rayDir * _lookDistance;
            }


            currentAngle -= angleBetweenRays;
        }

        for(int i=0; i<_rayCount-1; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }

        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        _meshFilter.mesh = mesh;
    }
}
