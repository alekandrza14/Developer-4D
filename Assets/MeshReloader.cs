using UnityEngine;

public class MeshReloader : MonoBehaviour
{
    [SerializeField] private Mesh mesh;
    void Start()
    {
        Mesh newmesh = new Mesh() {
            vertices = mesh.vertices,
            normals = mesh.normals,
            triangles = mesh.triangles,
            uv = mesh.uv,
            name = mesh.name
        }; 
        GetComponent<MeshCollider>().sharedMesh = newmesh;
    }
}
