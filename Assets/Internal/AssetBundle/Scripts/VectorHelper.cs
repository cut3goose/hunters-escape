using UnityEngine;

public static class VectorHelper
{
    public static float GetVectorsDistance(Vector3 firstPosition, Vector3 secondPosition)
    {
        Vector3 distanceBetweenPoints;
        
        distanceBetweenPoints.x = GetPointsDistance(firstPosition.x, secondPosition.x);
        distanceBetweenPoints.z = GetPointsDistance(firstPosition.z, secondPosition.z);

        var distance = GetHypotenuse(distanceBetweenPoints.x, distanceBetweenPoints.z);

        return Mathf.Abs(distance);
    }

    public static float GetPointsDistance(float firstPoint, float secondPoint)
    {
        var maxPoint = Mathf.Max(firstPoint, secondPoint);
        var minPoint = Mathf.Min(firstPoint, secondPoint);

        var distance = maxPoint - minPoint;

        return distance;
    }

    public static Vector3 GetRandomVectorInRange(Vector3 firstVector, Vector3 secondVector)
    {
        var x = GetRandomNumberInRange(firstVector.x, secondVector.x);
        var y = GetRandomNumberInRange(firstVector.y, secondVector.y);
        var z = GetRandomNumberInRange(firstVector.z, secondVector.z);
        
        var randomVector = new Vector3(x, y, z);
        return randomVector;
    }

    #region Auxiliary Actions

    private static float GetHypotenuse(float firstSide, float secondSide)
    {
        var firstSideSquared = Mathf.Pow(firstSide, 2f);
        var secondSideSquared = Mathf.Pow(secondSide, 2f);

        var squaredHypotenuse = firstSideSquared + secondSideSquared;
        var hypotenuse = Mathf.Sqrt(squaredHypotenuse);

        return hypotenuse;
    }
    
    private static float GetRandomNumberInRange(float firstNumber, float secondNumber)
    {
        var randomValue = Random.Range(firstNumber, secondNumber);
        return randomValue;
    }

    #endregion
}
