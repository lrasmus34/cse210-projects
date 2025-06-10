using System;

public class Breathing : Activity
{
    public static int _count { get; private set; } = 0; //log of how many times breathing activity was performed
    public Breathing() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing")
    { }

    public void RunBreathing()
    {
        _count++;

        Start();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int breathTime = 5; //default duration for inhale/exhale

        while (DateTime.Now < endTime)
        {
            int timeLeft = (int)(endTime - DateTime.Now).TotalSeconds;

            //Breathe in
            Console.Write("\nBreathe in... ");
            AnimationHelper.Countdown(Math.Min(breathTime, timeLeft));
            timeLeft = (int)(endTime - DateTime.Now).TotalSeconds;
            if (timeLeft <= 0) break;

            //Breathe out
            Console.Write("Now breathe out... ");
            AnimationHelper.Countdown(Math.Min(breathTime, timeLeft));
        }

        End();
    }
}