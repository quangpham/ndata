using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class NguiDataContext : MonoBehaviour
{
	protected EZData.Context _context;
		
	public EZData.Property<T> FindProperty<T>(string path, NguiBaseBinding binding)
	{
		if (_context == null)
		{
			return null;
		}
		try
		{
			return _context.FindProperty<T>(binding.GetFullCleanPath(path), binding);
		}
		catch(Exception ex)
		{
			Debug.LogError("Failed to find property " + path + "\n" + ex);
			return null;
		}
	}
	
	public EZData.Property<int> FindEnumProperty(string path, NguiBaseBinding binding)
	{
		if (_context == null)
		{
			return null;
		}
		try
		{
			return _context.FindEnumProperty(binding.GetFullCleanPath(path), binding);
		}
		catch(Exception ex)
		{
			Debug.LogError("Failed to find enum property " + path + "\n" + ex);
			return null;
		}
	}
	
	public System.Delegate FindCommand(string path, NguiBaseBinding binding)
	{
		if (_context == null)
		{
			return null;
		}
		try
		{
			return _context.FindCommand(binding.GetFullCleanPath(path), binding);
		}
		catch(Exception ex)
		{
			Debug.LogError("Failed to find command " + path + "\n" + ex);
			return null;
		}
	}
	
	public EZData.Collection FindCollection(string path, NguiBaseBinding binding)
	{
		if (_context == null)
		{
			return null;
		}
		try
		{
			return _context.FindCollection(binding.GetFullCleanPath(path), binding);
		}
		catch(Exception ex)
		{
			Debug.LogError("Failed to find collection " + path + "\n" + ex);
			return null;
		}
	}
}
