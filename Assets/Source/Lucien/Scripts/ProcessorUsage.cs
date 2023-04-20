using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

//this refrences the processor usage from the target machine and uses it for generation in the object pools
public class ProcessorUsage
{
    const float sampleFrequencyMilliseconds = 1000;     //this is how long is waited to let the processor adjust

    protected object syncLock = new object();           //make sure that we are always usign the right processor
    protected PerformanceCounter performanceCounter;    //this is built into System.Diagnostics and used to refrence the CPU
    protected float lastSample;                         //this gets the smaple frequency
    protected System.DateTime lastSampleTime;           //this gets the time of the last sample so we can allow the cpu to update
    
    //see the processor usage currently from any script (for dubugging)
    public ProcessorUsage()
    {
        this.performanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
    }

    //this allows a script to see how much of the processor is in use at a time
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
        //rerturns the current usage of the processor
        return lastSample;
    }
}
