using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Vector6
{
    public float x, y, z, w, h, p;
    public Vector6(float x1, float y1, float z1, float w1, float h1, float p1)
    {
        x = x1;
        y = y1;
        z = z1;
        w = w1;
        h = h1;
        p = p1;
    }
}
public enum Shape
{
   shape3D, cube5D,clone5D, plane3D, shape4D, shapecube5D, hyperbola5D, hyperCurveCube5D, cubeND, slice4Dcube,free5D
}
[ExecuteAlways]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class MultyObject : MonoBehaviour
{

   public MultyTransform instance;
    MeshCollider meshCollider;
    TerrainCollider terrainCollider;
    Terrain terrain;
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;
    SphereCollider sphereCollider;
    [Header("Transform W")]
    public float W_Position;
    public float W_Count_Slice;
    public float W_Scale = 1;
    [Header("Transform H")]
    public float H_Position;
    public float H_Scale = 1;
    [Header("Transforms N")]
    public float[] N_Positions;
    public float[] N_Scales;
    [Header("Shape")]
    public Shape shape;
    public Mesh[] shapes3D;
    [SerializeField] Mesh[] shapes3Dcol;
    public shapeSettings shapeSettings;
    [SerializeField] GameObject[] Slices;
    [Header("Save prametrs")]
    public Vector3 scale3D = Vector3.one;
    GameObject[] childs;
   

    int w;
    void Start()
    {
        if (FindObjectsByType<MultyTransform>(sortmode.main).Length == 0)
        {


            GameObject g = new("4D Controler")
            {

            };


            g.AddComponent<MultyTransform>();
        }

        if (GetComponent<button6>()) shape = Shape.free5D;
        if (scale3D.x == 1 || scale3D.y == 1 || scale3D.z == 1) scale3D = transform.localScale;
        startPosition = new Vector6(transform.position.x, transform.position.y, transform.position.z, W_Position, H_Position, 0);
        startScale = new Vector6(scale3D.x, scale3D.y, scale3D.z, W_Scale, H_Scale, 0);
        List<GameObject> countcild = new();
        float c = transform.childCount;
        for (int i = 0; i < c; i++)
        {
            countcild.Add(transform.GetChild(i).gameObject);
        }
        childs = countcild.ToArray();

        if (shape == Shape.shapecube5D)
        {
            shapes3Dcol = new Mesh[shapes3D.Length];
            for (int i = 0; i < shapes3D.Length; i++)
            {
                shapes3Dcol[i] = new()
                {
                    vertices = shapes3D[i].vertices,
                    triangles = shapes3D[i].triangles,
                    normals = shapes3D[i].normals,
                    uv = shapes3D[i].uv,
                    name = i.ToString()
                };

            }
        }
        if (!instance)
        {
            instance = FindFirstObjectByType<MultyTransform>();

        }
        meshCollider = GetComponent<MeshCollider>();
        
        meshRenderer = GetComponent<MeshRenderer>();
        terrainCollider = GetComponent<TerrainCollider>();
        terrain = GetComponent<Terrain>();
        boxCollider = GetComponent<BoxCollider>();
        sphereCollider = GetComponent<SphereCollider>();
        InvokeRepeating(nameof(ProjectionUpdate), 0.001f, 0.02f + Random.Range(0.01f, 0.02f));
        

        //  if (mover.Get4DCam())   if (mover.Get4DCam()._wRotation.x != 0) Swap();
        // if (VarSave.GetBool("H_Roataton")) SwapH();
    }
    private void Update()
    {


    }
        // Update is called once per frame\
        [Header("Debug prametrs")]
    public Vector6 startPosition;
    public Vector6 startScale;
    public float w5 = 0;
    public float w6 = 0;
    public float h5 = 0;
    public float h6 = 0;

  public  Vector3 testScale;
   public bool saved;
    public void ProjectionUpdate()
    {
        if (instance)
        {
           


                w5 = W_Position;
                w6 = W_Scale; 
                h5 = H_Position;
                h6 = H_Scale;

                testScale  = new Vector3(scale3D.x, scale3D.y, scale3D.z);

             
        }
        if (shape == Shape.plane3D)
        {
          if (!GetComponent<HyperbolicPoint>())  transform.localScale = new Vector3(100000, testScale.y, 100000);
        }
        if (shape == Shape.shape3D)
        {

            if (!GetComponent<HyperbolicPoint>()) transform.localScale = new Vector3(testScale.x, testScale.y, testScale.z);
        }
        if (instance)
        {
            if (shape == Shape.cube5D)
            {

                if (!GetComponent<HyperbolicPoint>()) transform.localScale = new Vector3(testScale.x, testScale.y, testScale.z);
            }
            if (shape == Shape.cube5D|| shape == Shape.free5D)
            {
                if (shapeSettings != null)
                {
                    if (shapeSettings.W_materials.Length != 0)
                    {



                        int w2 = (int)((((instance.W_Position - w5) * shapeSettings.W_materials.Length) / (w6 / 2)) - (w6 / 2));

                        if (w2 > -1 && w2 < shapeSettings.W_materials.Length)
                        {

                            if (meshRenderer)
                            {
                                meshRenderer.material = shapeSettings.W_materials[w2];
                            }


                        }
                    }
                }
              if(shape != Shape.free5D)  if (!GetComponent<HyperbolicPoint>()) transform.localScale = new Vector3(testScale.x, testScale.y, testScale.z);
                if (instance.W_Position + w6 > w5 && instance.W_Position - w6 < w5 &&
                    instance.H_Position + h6 > h5 && instance.H_Position - h6 < h5)
                {
                    if (meshRenderer)
                    {
                        if (shape != Shape.free5D) meshRenderer.enabled = true;
                        if (shape == Shape.free5D) meshRenderer.enabled = false;
                    }
                    if (meshCollider)
                    {
                        if (shape != Shape.free5D) meshCollider.enabled = true;
                        if (shape == Shape.free5D) meshCollider.enabled = false;
                    }
                    if (terrain)
                    {
                        terrain.enabled = true;
                    }
                    if (terrainCollider)
                    {
                        terrainCollider.enabled = true;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = true;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = true;
                    }
                    if (childs.Length > 0) foreach (GameObject child in childs)
                    {
                            if (child != null) child.SetActive(true);
                    }
                }
                else
                {
                  if(childs.Length > 0)  foreach (GameObject child in childs)
                    {
                     
                    }
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = false;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = false;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = false;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = false;
                    }
                    if (terrain)
                    {
                        terrain.enabled = false;
                    }
                    if (terrainCollider)
                    {
                        terrainCollider.enabled = false;
                    }
                }

            }
          
            if (shape == Shape.slice4Dcube)
            {
                for (int i =0; i< Slices.Length; i++) {
                   
                    if (instance.W_Position + w6 > w5 + (i*W_Count_Slice) && instance.W_Position - w6 < w5 + (i * W_Count_Slice) &&
                        instance.H_Position + h6 > h5 && instance.H_Position - h6 < h5)
                    {
                        GameObject slice = Slices[i];
                            slice.SetActive(true);
                      
                     
                    }
                    else
                    {
                        GameObject slice = Slices[i];
                        slice.SetActive(false);
                       
                    }
                }
            }
          
            if (shape == Shape.shapecube5D)
            {
                if (shapeSettings != null)
                {
                    if (shapeSettings.W_materials.Length != 0)
                    {



                        int w2 = (int)((((instance.W_Position - w5) * shapeSettings.W_materials.Length) / (w6 / 2)) - (w6 / 2));

                        if (w2 > -1 && w2 < shapeSettings.W_materials.Length)
                        {

                            if (meshRenderer)
                            {
                                meshRenderer.material = shapeSettings.W_materials[w2];
                            }


                        }
                    }
                }
                transform.localScale = new Vector3(testScale.x, testScale.y, testScale.z);
                w = (int)(((instance.W_Position - w5) * shapes3D.Length) / (w6 / 2));




                if (w > -1 && w < shapes3Dcol.Length)
                {

                    if (GetComponent<MeshFilter>())
                    {
                        GetComponent<MeshFilter>().sharedMesh = shapes3Dcol[w];
                    }


                }



                if (instance.W_Position > w5 && instance.W_Position - w6 < w5 &&
                    instance.H_Position + h6 > h5 && instance.H_Position - h6 < h5)
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = true;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = true;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = true;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = true;
                    }
                    if (terrain)
                    {
                        terrain.enabled = true;
                    }
                    if (terrainCollider)
                    {
                        terrainCollider.enabled = true;
                    }
                }
                else
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = false;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = false;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = false;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = false;
                    }
                    if (terrain)
                    {
                        terrain.enabled = false;
                    }
                    if (terrainCollider)
                    {
                        terrainCollider.enabled = false;
                    }
                }

            }
            if (shape == Shape.shape4D)
            {
                if (shapeSettings != null)
                {
                    if (shapeSettings.W_materials.Length != 0)
                    {



                        int w2 = (int)((((instance.W_Position - w5) * shapeSettings.W_materials.Length) / (w6 / 2)) - (w6 / 2));

                        if (w2 > -1 && w2 < shapeSettings.W_materials.Length)
                        {

                            if (meshRenderer)
                            {
                                meshRenderer.material = shapeSettings.W_materials[w2];
                            }


                        }
                    }
                }
                transform.localScale = new Vector3(testScale.x, testScale.y, testScale.z);
                w = (int)(((instance.W_Position - w5) * shapes3D.Length) / (w6 / 2));




                if (w > -1 && w < shapes3D.Length)
                {

                    if (GetComponent<MeshFilter>())
                    {
                        GetComponent<MeshFilter>().sharedMesh = shapes3D[w];
                    }


                }



                if (instance.W_Position > w5 && instance.W_Position - w6 < w5)
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = true;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = true;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = true;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = true;
                    }
                    if (terrain)
                    {
                        terrain.enabled = true;
                    }
                    if (terrainCollider)
                    {
                        terrainCollider.enabled = true;
                    }
                }
                else
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = false;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = false;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = false;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = false;
                    }
                    if (terrain)
                    {
                        terrain.enabled = false;
                    }
                    if (terrainCollider)
                    {
                        terrainCollider.enabled = false;
                    }
                }

            }
            if (shape == Shape.clone5D)
            {
                if (shapeSettings != null)
                {
                    if (shapeSettings.W_materials.Length != 0)
                    {



                        int w2 = (int)((((instance.W_Position - w5) * shapeSettings.W_materials.Length) / (w6 / 2)) - (w6 / 2));

                        if (w2 > -1 && w2 < shapeSettings.W_materials.Length)
                        {

                            if (meshRenderer)
                            {
                                meshRenderer.material = shapeSettings.W_materials[w2];
                            }


                        }
                    }
                }
                float h = h6 - Mathf.Abs(H_Position - instance.H_Position);
             //   Vector3 v3 = testScale;

                float w = w6 - Mathf.Abs(w5 - instance.W_Position);
                float s = ((w / w6) + (h / h6)) / 2;
                transform.localScale = new Vector3(s * testScale.x, s * testScale.y, s * testScale.z);
                if (instance.W_Position + w6 > w5 && instance.W_Position - w6 < w5 &&
                   instance.H_Position + h6 > h5 && instance.H_Position - h6 < h5)
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = true;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = true;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = true;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = true;
                    }
                    if (terrain)
                    {
                        terrain.enabled = true;
                    }
                    if (terrainCollider)
                    {
                        terrainCollider.enabled = true;
                    }
                    foreach (GameObject child in childs)
                    {
                        child.SetActive(true);
                    }
                }
                else
                {
                    foreach (GameObject child in childs)
                    {
                    }
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = false;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = false;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = false;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = false;
                    }
                    if (terrain)
                    {
                        terrain.enabled = false;
                    }
                    if (terrainCollider)
                    {
                        terrainCollider.enabled = false;
                    }
                }
            }
            if (shape == Shape.hyperbola5D)
            {
                if (shapeSettings != null)
                {
                    if (shapeSettings.W_materials.Length != 0)
                    {



                        int w2 = (int)((((instance.W_Position - w5) * shapeSettings.W_materials.Length) / (w6 / 2)) - (w6 / 2));

                        if (w2 > -1 && w2 < shapeSettings.W_materials.Length)
                        {

                            if (meshRenderer)
                            {
                                meshRenderer.material = shapeSettings.W_materials[w2];
                            }


                        }
                    }
                }
                float h = h6 + Mathf.Abs(H_Position - instance.H_Position) * Mathf.Abs(H_Position - instance.H_Position);
              //  Vector3 v3 = testScale;

                float w = w6 + Mathf.Abs(w5 - instance.W_Position) * Mathf.Abs(W_Position - instance.W_Position);
                float s = ((w / w6) + (h / h6)) / 2;
                transform.localScale = new Vector3(s * testScale.x, s * testScale.y, s * testScale.z);
                if (instance.W_Position + w6 > w5 && instance.W_Position - w6 < w5 &&
                    instance.H_Position + h6 > h5 && instance.H_Position - h6 < h5)
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = true;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = true;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = true;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = true;
                    }
                    if (terrain)
                    {
                        terrain.enabled = true;
                    }
                    if (terrainCollider)
                    {
                        terrainCollider.enabled = true;
                    }
                }
                else
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = false;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = false;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = false;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = false;
                    }
                    if (terrain)
                    {
                        terrain.enabled = false;
                    }
                    if (terrainCollider)
                    {
                        terrainCollider.enabled = false;
                    }
                }
            }
            if (shape == Shape.hyperCurveCube5D && shapeSettings != null)
            {
                float h = (h6 - Mathf.Abs(H_Position - instance.H_Position)) / h6;
              //  Vector3 v3 = testScale;

                float w = (w6 - Mathf.Abs(w5 - instance.W_Position)) / w6;
                transform.localScale = new Vector3(
                     testScale.x * shapeSettings.WX_scale.Evaluate(w) * shapeSettings.HX_scale.Evaluate(h),
                     testScale.y * shapeSettings.WY_scale.Evaluate(w) * shapeSettings.HY_scale.Evaluate(h),
                     testScale.z * shapeSettings.WZ_scale.Evaluate(w) * shapeSettings.HZ_scale.Evaluate(h));
                if (instance.W_Position + w6 > w5 && instance.W_Position - w6 < w5 &&
                    instance.H_Position + h6 > h5 && instance.H_Position - h6 < h5)
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = true;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = true;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = true;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = true;
                    }
                    if (terrain)
                    {
                        terrain.enabled = true;
                    }
                    if (terrainCollider)
                    {
                        terrainCollider.enabled = true;
                    }
                }
                else
                {
                    if (meshRenderer)
                    {
                        meshRenderer.enabled = false;
                    }
                    if (meshCollider)
                    {
                        meshCollider.enabled = false;
                    }
                    if (boxCollider)
                    {
                        boxCollider.enabled = false;
                    }
                    if (sphereCollider)
                    {
                        sphereCollider.enabled = false;
                    }
                    if (terrain)
                    {
                        terrain.enabled = false;
                    }
                    if (terrainCollider)
                    {
                        terrainCollider.enabled = false;
                    }
                }
            }
            if (meshCollider)
            {

                meshCollider.sharedMesh = GetComponent<MeshFilter>().sharedMesh;

            }
        }
    }
}
