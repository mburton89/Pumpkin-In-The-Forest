using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public static TimelineController Instance;

    public PlayableDirector timeline;

    private bool timelineSet;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;

        timelineSet = timeline != null ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timelineSet)
        {
            if (timeline != null)
            {
                timelineSet = true;
            }
        }
    }

    public void playTimeline()
    {
        if (timelineSet)
            timeline.Play();
    }

    public void pauseTimeline()
    {
        if (timelineSet)
            timeline.Pause();
    }
}
