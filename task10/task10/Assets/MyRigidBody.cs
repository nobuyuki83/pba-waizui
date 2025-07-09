using UnityEngine;
using Unity.Mathematics;

public class MyRigidBody : MonoBehaviour
{

    // float3 cog;
    float3x3 inertia_tensor;
    public float timeStep = 0.01f;
    float3 omega = new float3(0.0f, 1.0f, 0.02f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60; // set target frame rate
        Mesh mesh = GetComponent<MeshFilter>().mesh;     
        int[] tri2vtx = mesh.triangles;    
        Vector3[] vertices = mesh.vertices; // Get the vertices of the mesh
        var volume_cog = VolumeCenterOfGravityForTriangleMesh(tri2vtx, vertices);
        Vector3 cog = volume_cog.Item2;
        for (int i = 0; i < vertices.Length; i++) {
            vertices[i] -= cog; // move the mesh to the center of gravity
        }
        mesh.vertices = vertices; // update the mesh vertices
//        Debug.Log($"Volume: {volume_cog.Item1}, Center of Gravity: {volume_cog.Item2}");
        inertia_tensor = InertiaTensorForTriangleMesh(tri2vtx, vertices);
        Debug.Log($"Inertia Tensor: {inertia_tensor}");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 30; i++)
        {
            Quaternion rot = this.transform.rotation;
            this.transform.rotation = rot * Quaternion.AngleAxis(math.length(omega) * timeStep * 180.0f / Mathf.PI, Vector3.Normalize(omega));
            // ----------------
            // write a few line of code below to update the angular velocity at the reference configuration `omega` using forward time integration

            // omega += ???

            // end of edit
            // ----------------
        }
        //
        var energy = 0.5f * math.dot(omega, math.mul(inertia_tensor, omega));
        var momentum = this.transform.rotation * math.mul(inertia_tensor, omega);
        Debug.Log($"Frame: {Time.frameCount}, Energy: {energy}, Momentum: {momentum}");
    }


    static (float, Vector3) VolumeCenterOfGravityForTriangleMesh(int[] tri2vtx, Vector3[] vtx2xyz) {
        float volume = 0;        
        Vector3 cog = Vector3.zero;
        for (int i_tri = 0; i_tri < tri2vtx.Length/3; i_tri++) {
            int i0 = tri2vtx[i_tri * 3 + 0];
            int i1 = tri2vtx[i_tri * 3 + 1];
            int i2 = tri2vtx[i_tri * 3 + 2];
            Vector3 v0 = vtx2xyz[i0];
            Vector3 v1 = vtx2xyz[i1];
            Vector3 v2 = vtx2xyz[i2];
            float volume_tet = Vector3.Dot(Vector3.Cross(v0,v1),v2) / 6.0f;
            volume += volume_tet;
            cog += (v0 + v1 + v2) / 4.0f * volume_tet;
        }
        cog /= volume;
        return (volume, cog);
    }

    static float3x3 OuterProduct(float3 a, float3 b) {
        return new float3x3(
            a[0] * b[0], a[0] * b[1], a[0] * b[2],
            a[1] * b[0], a[1] * b[1], a[1] * b[2],
            a[2] * b[0], a[2] * b[1], a[2] * b[2]);            
    }

    static float3x3 InertiaTensorForTriangleMesh(int[] tri2vtx, Vector3[] vtx2xyz) {
        float3x3 res = float3x3.zero;
        for (int i_tri = 0; i_tri < tri2vtx.Length/3; i_tri++) {
            int i0 = tri2vtx[i_tri * 3 + 0];
            int i1 = tri2vtx[i_tri * 3 + 1];
            int i2 = tri2vtx[i_tri * 3 + 2];
            float3 p0 = vtx2xyz[i0];
            float3 p1 = vtx2xyz[i1];
            float3 p2 = vtx2xyz[i2];
            float volume = math.dot(p0, math.cross(p1, p2))/6.0f;
            float3 pa = p0 + p1 + p2;
            // -----------------
            // write some code below
            res += (math.dot(pa* 0.25f, pa*0.25f)*float3x3.identity - OuterProduct(pa * 0.25f, pa * 0.25f)) * volume; // comment out, since this is a approximation where mass is centered at the cog of tetrahedron
            // end of edit
            // ------------------
        }
        return res;
    }
}
