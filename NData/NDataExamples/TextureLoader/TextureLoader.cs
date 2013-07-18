using UnityEngine;
using System;
using System.Collections;

public interface IWwwLoader
{
	void LoadTexture(string url, Action<Texture2D> callback);
}

public class TextureLoaderContext : EZData.Context
{
	#region Property ImageUrl
	private readonly EZData.Property<string> _privateImageUrlProperty = new EZData.Property<string>("http://forum.unity3d.com/customavatars/avatar48859_1.gif");
	public EZData.Property<string> ImageUrlProperty { get { return _privateImageUrlProperty; } }
	public string ImageUrl
	{
	get    { return ImageUrlProperty.GetValue();    }
	set    { ImageUrlProperty.SetValue(value); }
	}
	#endregion
	
	
	#region Property ImageTexture
	private readonly EZData.Property<Texture2D> _privateImageTextureProperty = new EZData.Property<Texture2D>();
	public EZData.Property<Texture2D> ImageTextureProperty { get { return _privateImageTextureProperty; } }
	public Texture2D ImageTexture
	{
	get    { return ImageTextureProperty.GetValue();    }
	set    { ImageTextureProperty.SetValue(value); }
	}
	#endregion
	
	
	private IWwwLoader _wwwLoader;
	public TextureLoaderContext(IWwwLoader wwwLoader)
	{
		_wwwLoader = wwwLoader;
	}
	
	public void LoadImage()
	{
		_wwwLoader.LoadTexture(ImageUrl, (texture) => ImageTexture = texture);
	}
}

public class TextureLoader : MonoBehaviour, IWwwLoader
{
	public NguiRootContext View;
	public TextureLoaderContext Context;
	
	
	
	public void LoadTexture(string url, Action<Texture2D> callback)
	{
		StartCoroutine(LoadTexture(new WWW(url), callback));
	}
	
	private IEnumerator LoadTexture(WWW www, Action<Texture2D> callback)
	{
		yield return www;
		callback(string.IsNullOrEmpty(www.error) ? www.texture : null);
	}
	
	void Awake()
	{
		Context = new TextureLoaderContext(this);
		View.SetContext(Context);
		Context.LoadImage();
	}
}
