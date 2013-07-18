using UnityEngine;
using System;
using System.Collections;

public interface IWwwLoader
{
	void LoadTexture(string url, Action<Texture2D> callback);
}

public class TextureLoaderContext : EZData.Context
{
	#region Property ImageUrl1
	private readonly EZData.Property<string> _privateImageUrl1Property = new EZData.Property<string>("http://forum.unity3d.com/customavatars/avatar48859_1.gif");
	public EZData.Property<string> ImageUrl1Property { get { return _privateImageUrl1Property; } }
	public string ImageUrl1
	{
	get    { return ImageUrl1Property.GetValue();    }
	set    { ImageUrl1Property.SetValue(value); }
	}
	#endregion

	#region Property Texture1
	private readonly EZData.Property<Texture2D> _privateTexture1Property = new EZData.Property<Texture2D>();
	public EZData.Property<Texture2D> Texture1Property { get { return _privateTexture1Property; } }
	public Texture2D Texture1
	{
	get    { return Texture1Property.GetValue();    }
	set    { Texture1Property.SetValue(value); }
	}
	#endregion
	
	#region Property ImageUrl2
	private readonly EZData.Property<string> _privateImageUrl2Property = new EZData.Property<string>("http://www.hitech-gamer.com/out/fck_pictures/Grafikkarten/NVidia_GTX580_WaKue_2xSLI_500b_HS.png");
	public EZData.Property<string> ImageUrl2Property { get { return _privateImageUrl2Property; } }
	public string ImageUrl2
	{
	get    { return ImageUrl2Property.GetValue();    }
	set    { ImageUrl2Property.SetValue(value); }
	}
	#endregion

	#region Property Texture2
	private readonly EZData.Property<Texture2D> _privateTexture2Property = new EZData.Property<Texture2D>();
	public EZData.Property<Texture2D> Texture2Property { get { return _privateTexture2Property; } }
	public Texture2D Texture2
	{
	get    { return Texture2Property.GetValue();    }
	set    { Texture2Property.SetValue(value); }
	}
	#endregion
	
	#region Property ImageUrl3
	private readonly EZData.Property<string> _privateImageUrl3Property = new EZData.Property<string>("http://forum.unity3d.com/customavatars/avatar48859_1.gif");
	public EZData.Property<string> ImageUrl3Property { get { return _privateImageUrl3Property; } }
	public string ImageUrl3
	{
	get    { return ImageUrl3Property.GetValue();    }
	set    { ImageUrl3Property.SetValue(value); }
	}
	#endregion

	#region Property Texture3
	private readonly EZData.Property<Texture2D> _privateTexture3Property = new EZData.Property<Texture2D>();
	public EZData.Property<Texture2D> Texture3Property { get { return _privateTexture3Property; } }
	public Texture2D Texture3
	{
	get    { return Texture3Property.GetValue();    }
	set    { Texture3Property.SetValue(value); }
	}
	#endregion
	
	private IWwwLoader _wwwLoader;
	public TextureLoaderContext(IWwwLoader wwwLoader)
	{
		_wwwLoader = wwwLoader;
	}
	
	public void LoadImage()
	{
		_wwwLoader.LoadTexture(ImageUrl1, (texture) => Texture1 = texture);
		_wwwLoader.LoadTexture(ImageUrl2, (texture) => Texture2 = texture);
		_wwwLoader.LoadTexture(ImageUrl3, (texture) => Texture3 = texture);
	}
}

public class TextureLoader : MonoBehaviour, IWwwLoader
{
	public NguiRootContext View;
	public TextureLoaderContext Context;
	
	private IEnumerator LoadTexture(WWW www, Action<Texture2D> callback)
	{
		yield return www;
		callback(string.IsNullOrEmpty(www.error) ? www.texture : null);
	}
	
	public void LoadTexture(string url, Action<Texture2D> callback)
	{
		StartCoroutine(LoadTexture(new WWW(url), callback));
	}
	
	void Awake()
	{
		Context = new TextureLoaderContext(this);
		View.SetContext(Context);
	}
}
