﻿using NorthwindLibrary;
using System.Collections.Generic;

namespace CachingSolutionsSamples
{
	public interface ICategoriesCache
	{
		IEnumerable<Category> Get(string forUser);
		void Set(string forUser, IEnumerable<Category> categories);
	}
}
