using UnityEngine;

public static class TimeController 
{
    public static void StopTime()
    {
        //slowdownFactor =  0.005f;
        Time.timeScale = 0.005f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    public static void RunTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
}
