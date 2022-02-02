using UnityEngine;

using asim.extensions._2d;

/// <summary>
/// https://en.wikipedia.org/wiki/Barnsley_fern
/// Make Sure Camera Is in "dont clear"
/// </summary>
public class Barnsley_Fern : MonoBehaviour
{
    public Vector2 StartPointPosition = new Vector2(0, 0);
    public Vector2 StartPointSize = new Vector2(2, 2);

    Vector2 currentPoint;
    Vector2 currentSize;

    void Start()
    {
        currentPoint = StartPointPosition;
        currentSize = StartPointSize;
    }

    int dotsPerFrame = 100;
    void OnGUI()
    {
        Extension2D.SetBGColor(Color.white);
        for (int i = 0; i < dotsPerFrame; i++)
        {
            //Note that the complete fern is within the range −2.1820 < x < 2.6558 and 0 ≤ y < 9.9983.
            float x = MathExtension.Map(currentPoint.x, -2.1820f, 2.6558f, 0, Screen.width);
            float y = MathExtension.Map(currentPoint.y, 0, 9.9983f, Screen.height, 0);

            Extension2D.DrawDot(new Vector2(x,y), currentSize,Color.black,Color.black, currentSize.x);
            currentPoint = GetNextBarnsleyPoint(currentPoint);
        }
    }

    Vector2 GetNextBarnsleyPoint(Vector2 currentPoint)
    {
        float x = currentPoint.x;
        float y = currentPoint.y;
        float newX;
        float newY;

        //new points are iteratively computed by randomly applying one of the following
        //four coordinate transformations:

        float randPercent = Random.Range(0f, 1f);
        if (randPercent < 0.01f)  //f1 is calculated 1% of the time
        {
            newX = 0.00f * x + 0.00f * y + 0;
            newY = 0.00f * x + 0.16f * y + 0;
        }
        else if (randPercent < 0.01f + 0.85f) //f2 is calculated 85% of the time
        {
            newX = 0.85f * x + 0.04f * y + 0.00f;
            newY = -0.04f * x + 0.85f * y + 1.60f;
        }
        else if (randPercent < 0.93f) //f3 is calculated 7% of the time
        {
            newX = 0.20f * x + -0.26f * y + 0.00f;
            newY = 0.23f * x + 0.22f * y + 1.60f;
        }
        else //f4 is calculated 7% of the time
        {
            newX = -0.15f * x + 0.28f * y + 0.00f;
            newY = 0.26f * x + 0.24f * y + 0.44f;
        }

        return new Vector2(newX, newY);
    }
    Vector2 GetNextBarnsleyPoint2(Vector2 currentPoint)
    {
        float x = currentPoint.x;
        float y = currentPoint.y;
        float newX;
        float newY;

        //new points are iteratively computed by randomly applying one of the following
        //four coordinate transformations:

        float randPercent = Random.Range(0f, 1f);
        if (randPercent < 0.01f)  //f1 is calculated 1% of the time
        {
            newX = 0.00f * x + 0.00f * y + 0;
            newY = 0.00f * x + 0.16f * y + 0;
        }
        else if (randPercent < 0.01f + 0.85f) //f2 is calculated 85% of the time
        {
            newX = 0.85f * x + 0.04f * y + 0.00f;
            newY = -0.04f * x + 0.85f * y + 1.60f;
        }
        else if (randPercent < 0.93f) //f3 is calculated 7% of the time
        {
            newX = 0.20f * x + -0.26f * y + 0.00f;
            newY = 0.23f * x + 0.22f * y + 1.60f;
        }
        else //f4 is calculated 7% of the time
        {
            newX = -0.15f * x + 0.28f * y + 0.00f;
            newY = 0.26f * x + 0.24f * y + 0.44f;
        }

        return new Vector2(newX, newY);
    }
}
