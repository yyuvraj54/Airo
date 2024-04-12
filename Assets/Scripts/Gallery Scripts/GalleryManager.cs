using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class GalleryManager : MonoBehaviour
{

    public int maxSize = 512;
    public Image PreviewArea;
    
public void PickImage( int maxSize )
{
	NativeGallery.Permission permission = NativeGallery.GetImageFromGallery( ( path ) =>
	{
		Debug.Log( "Image path: " + path );
		if( path != null )
		{
			// Create Texture from selected image
			Texture2D texture = NativeGallery.LoadImageAtPath( path, maxSize );
			if( texture == null )
			{
				Debug.Log( "Couldn't load texture from " + path );
				return;
			}

		   // Find the Renderer component of the imageView GameObject
             Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
            PreviewArea.sprite = sprite;
        
        
        

		}
	} );

	Debug.Log( "Permission result: " + permission );
}


}
