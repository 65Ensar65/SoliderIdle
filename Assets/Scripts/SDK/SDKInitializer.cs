using System;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using FlurrySDK;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SDKInitializer : MonoBehaviour
{
#if UNITY_ANDROID
    private string FLURRY_API_KEY = "YS379S3JPG43SQ7FBHK6";
#elif UNITY_IPHONE
    private string FLURRY_API_KEY = "YS379S3JPG43SQ7FBHK6";
#else
    private string FLURRY_API_KEY = null;
#endif
    private void Awake()
    {
        FB.Init(InitCallback);
    }

    private void Start()
    {
        new Flurry.Builder()
            .WithCrashReporting(true)
            .WithLogEnabled(true)
            .WithLogLevel(Flurry.LogLevel.VERBOSE)
            .Build(FLURRY_API_KEY);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void InitCallback ()
    {
        if (FB.IsInitialized) 
        {
            FB.ActivateApp();
        } 
        else 
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }
}
