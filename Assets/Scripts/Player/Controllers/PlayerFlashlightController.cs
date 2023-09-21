using Kosciach;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers
{
    public class PlayerFlashlightController : PlayerControllerBase
    {
        [Header("====Settings====")]
        [SerializeField] LayerMask _rayMask;
        [Range(25, 90)]
        [SerializeField] int _fov = 25;
        [Range(1, 25)]
        [SerializeField] float _lookDistance = 1;
        [SerializeField] float _density;



        private MeshFilter _meshFilter;


        private new void Awake()
        {
            base.Awake();
            _meshFilter = GetComponent<MeshFilter>();
        }
        private void LateUpdate()
        {
            CreateMesh();
        }



        private void CreateMesh()
        {
            Mesh mesh = new Mesh();
            int defaultWorldAngle = 90;
            float currentAngle = transform.rotation.eulerAngles.z + defaultWorldAngle + _fov / 2;


            Vector3[] vertices = new Vector3[_fov*((int)_density+1) + 1 + 1];
            Vector2[] uvs = new Vector2[vertices.Length];
            int[] triangles = new int[_fov * ((int)_density+1) * 3];


            vertices[0] = Vector3.zero;

            for (int i = 0; i < _fov*_density + 1; i++)
            {
                Vector3 rayDir = KosciachUtilities.GetVectorFromAngleDeg(currentAngle);
                Debug.DrawRay(transform.position, rayDir * _lookDistance, Color.blue, 0.001f);

                RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDir, _lookDistance, _rayMask);
                if (hit) vertices[i + 1] = transform.InverseTransformPoint(hit.point);
                else vertices[i + 1] = transform.InverseTransformPoint(transform.position + rayDir * _lookDistance);


                currentAngle -= 1f/_density;
            }

            for (int i = 0; i < _fov*_density; i++)
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
}