namespace LB.SuperUI.Helpers.Observer 
{
    using UnityEngine;
    using UnityEngine.UI;

    public static class CanvasUtilities
    {
        public static Vector2 GetCanvasSize(CanvasScaler canvasScaler)
        {
            Vector2 screenSize = new(Screen.width, Screen.height);
            Vector2 referenceResolution = canvasScaler.referenceResolution;
            float matchWidthOrHeight = canvasScaler.matchWidthOrHeight;

            float logWidth = Mathf.Log(screenSize.x / referenceResolution.x, 2);
            float logHeight = Mathf.Log(screenSize.y / referenceResolution.y, 2);
            float logWeightedAverage = Mathf.Lerp(logWidth, logHeight, matchWidthOrHeight);
            float scaleFactor = Mathf.Pow(2, logWeightedAverage);

            return new Vector2(screenSize.x / scaleFactor, screenSize.y / scaleFactor);
        }
    }
}



