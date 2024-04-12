// NativePhotoLibrary.cs
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class NativePhotoLibrary : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern IntPtr _GetAllPhotos();

    public static List<string> GetAllPhotos()
    {
        List<string> photoPaths = new List<string>();

        IntPtr photoPathsPtr = _GetAllPhotos();
        string[] photoPathsArray = Marshal.PtrToStringAnsi(photoPathsPtr).Split('|');
        foreach (string path in photoPathsArray)
        {
            photoPaths.Add(path);
        }

        return photoPaths;
    }
}
