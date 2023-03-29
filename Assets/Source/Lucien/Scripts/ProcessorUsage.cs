using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class ProcessorUsage
{
    const float sampleFrequencyMilliseconds = 1000;

    protected object syncLock = new object();
    protected PerformanceCounter performanceCounter;
    protected float lastSample;
    protected System.DateTime lastSampleTime;
    
    public ProcessorUsage()
    {
        this.performanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
    }

    public float GetCurrentValue()
    {
        if((System.DateTime.UtcNow - lastSampleTime).TotalMilliseconds > sampleFrequencyMilliseconds)
        {
            lock(syncLock)
            {
                if((System.DateTime.UtcNow - lastSampleTime).TotalMilliseconds > sampleFrequencyMilliseconds)
                {
                    lastSample = performanceCounter.NextValue();
                    System.Threading.Thread.Sleep(10);
                    lastSample += performanceCounter.NextValue();
                    lastSample /= 2;
                    lastSampleTime = System.DateTime.UtcNow;
                }
            }
        }
        return lastSample;
    }
}
