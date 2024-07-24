using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    float viewRadius;
    float viewAngle;
    float meshResolution;

    LayerMask obstacleMask;

    SpriteMask viewSpriteMask;

    MeshFilter viewMeshFilter;
    Mesh viewMesh;

    struct viewCastInfo
    {
        public bool hit;
        public Vector3 point;
        public float dist;
        public float angle;

        public viewCastInfo(bool _hit, Vector3 _point, float _dist, float _angle)
        {
            hit = _hit;
            point = _point;
            dist = _dist;
            angle = _angle;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        viewRadius = 10;
        viewAngle = 360;
        meshResolution = 4; //number of raycasts per degree (mayor performance control)

        obstacleMask = LayerMask.GetMask("Obstacles");

        //keep up to date
        viewSpriteMask = transform.Find("ViewMask").GetComponent<SpriteMask>();

        Texture2D emptyTexture = new Texture2D(Mathf.RoundToInt(viewRadius) * 200, Mathf.RoundToInt(viewRadius) * 200);

        viewSpriteMask.sprite = Sprite.Create(emptyTexture, new Rect(0, 0, emptyTexture.width, emptyTexture.height), Vector2.zero);
        viewSpriteMask.sprite.name = "View Mask";

        viewSpriteMask.transform.Translate(new Vector3(-viewRadius, -viewRadius, 0));
        
        drawFieldOfView();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        drawFieldOfView();
    }

    Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
		if (!angleIsGlobal) {
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
	}

    viewCastInfo ViewCast(float globalAngle)
    {
        Vector3 dir = DirFromAngle(globalAngle, true);
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, dir, viewRadius, obstacleMask);

        if(hit){
            return new viewCastInfo(true, hit.point, hit.distance, globalAngle);
        }else{
            return new viewCastInfo(false, transform.position + dir * viewRadius, viewRadius, globalAngle);
        }
    }

    void drawFieldOfView()
    {
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
		float stepAngleSize = viewAngle / stepCount;

        List<Vector3> viewPoints = new List <Vector3> ();

        for(int i  = 0; i <= stepCount; i++){
            float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
            viewCastInfo newViewcast = ViewCast(angle);
            viewPoints.Add(newViewcast.point);
        }

        int vertexCount = viewPoints.Count + 1;
        
        Vector2[] vertices = new Vector2[vertexCount];
        //needs to contain vertex index in clockwise order. Ie = [0,1,2,0,2,3]
        ushort[] triangles = new ushort[(vertexCount - 2) * 3];

        //the mesh will be a child of player
        vertices [0] = new Vector3(viewRadius * 100, viewRadius * 100, 0); //set origin of mesh to center of Rect
        for (int i = 0; i < vertexCount - 1; i++){

            //player coordinates
            vertices[i+1] = (transform.InverseTransformPoint(viewPoints[i]) + new Vector3(viewRadius, viewRadius)) * 100;//Shift and scale to Rect coordinates

            //clamp values to prevent floating point errrors
            vertices[i+1][0] = Mathf.Clamp(vertices[i+1][0], 0, viewRadius * 200);
            vertices[i+1][1] = Mathf.Clamp(vertices[i+1][1], 0, viewRadius * 200);

            if(i<vertexCount-2){
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = (ushort)(i + 1);
                triangles[i * 3 + 2] = (ushort)(i + 2);
            }
        }
        viewSpriteMask.sprite.OverrideGeometry(vertices, triangles);
    }
}
