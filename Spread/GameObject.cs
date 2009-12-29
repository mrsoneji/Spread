using System;
using System.Collections.Generic;

namespace Spread
{
	public class GameObject: System.Object 
	{
		string _name;
		
		public GameObject(string name)
		{
			_name = name;
		}

		public string name{
			get { return _name; }
			set{ _name = value; }
		}
		
		public virtual void Update()
		{
		}
	}
}