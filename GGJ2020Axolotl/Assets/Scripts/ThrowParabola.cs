using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowParabola : MonoBehaviour
{
    //need to know the actual enum
    //public enum Part part;

    float objectT = 0; //timer for that object

    public Transform Ta, Tb; //transforms that mark the start and end
    public float h; //desired parabola height

    public GameObject thrown;
    Vector3 a, b; //Vector positions for start and end

    public float distance = 10;

    public LineRenderer lr;

    Coroutine throwCo =null;

    public float throwSpeed = 1;


    
    private void Awake()
    {
        
    }
    void GetLine()
    {
        lr.positionCount = 21;
        lr.SetPositions(GetTrajectory().ToArray());
    }

    Vector3 SetDistance()
    {
        Vector3 dist = (Ta.forward * distance)+ Ta.position;

        return new Vector3(dist.x, Tb.position.y, dist.z);
    }


    Tween t;

    public void ThrowObject(GameObject _go)
    {
        t?.Kill();

        _go.transform.DOLocalPath(GetTrajectory().ToArray(), throwSpeed);
;    }


    public List<Vector3> GetTrajectory()
    {
        float count = 20;
       
        Vector3 lastP = a;
        List<Vector3> pos = new List<Vector3>();
        for (float i = 0; i < count ; i++)
        {
            Vector3 p = SampleParabola(a, b, h, i / count);
            pos.Add(p);
            lastP = p;
        }
        return pos;
    }

    void Update()
    {
        if (Ta  && Tb ) {
            a = Ta.position; //Get vectors from the transforms
            b = Tb.position;

            Tb.position = SetDistance(); 
            GetLine();
        }

        
    }
    

    #region Parabola sampling function
    /// <summary>
    /// Get position from a parabola defined by start and end, height, and time
    /// </summary>
    /// <param name='start'>
    /// The start point of the parabola
    /// </param>
    /// <param name='end'>
    /// The end point of the parabola
    /// </param>
    /// <param name='height'>
    /// The height of the parabola at its maximum
    /// </param>
    /// <param name='t'>
    /// Normalized time (0->1)
    /// </param>S
    Vector3 SampleParabola(Vector3 start, Vector3 end, float height, float t)
    {
        if (Mathf.Abs(start.y - end.y) < 0.1f)
        {
            //start and end are roughly level, pretend they are - simpler solution with less steps
            Vector3 travelDirection = end - start;
            Vector3 result = start + t * travelDirection;
            result.y += Mathf.Sin(t * Mathf.PI) * height;
            return result;
        }
        else
        {
            //start and end are not level, gets more complicated
            Vector3 travelDirection = end - start;
            Vector3 levelDirecteion = end - new Vector3(start.x, end.y, start.z);
            Vector3 right = Vector3.Cross(travelDirection, levelDirecteion);
            Vector3 up = Vector3.Cross(right, travelDirection);
            if (end.y > start.y) up = -up;
            Vector3 result = start + t * travelDirection;
            result += (Mathf.Sin(t * Mathf.PI) * height) * up.normalized;
            return result;
        }
    }
    #endregion

}
