using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using static NativeGallery;
public class AccessMedia : MonoBehaviour
{
    // Start is called before the first frame update
    
  async void  Start(){
    
        // Request permission to read images
        NativeGallery.Permission permission = await NativeGallery.RequestPermissionAsync(NativeGallery.PermissionType.Read, NativeGallery.MediaType.Image);

        if (permission == NativeGallery.Permission.Granted)
        {
            Debug.Log("Permission to access images granted!");

          
        }
        else if (permission == NativeGallery.Permission.Denied)
        {
            Debug.Log("Permission to access images denied.");
        }
      
    }


}
