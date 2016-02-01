using System;
using Cirrious.MvvmCross.Plugins.File;
using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid;
using System.IO;

namespace Testes.MvvmValidation
{
	public class WRService : MvxFileStore
	{
		public WRService ()
		{
		}

		private Context _context;

		private Context Context
		{
			get
			{
				if (_context == null)
				{
					_context = Mvx.Resolve<IMvxAndroidGlobals>().ApplicationContext;
				}
				return _context;
			}
		}

		protected override string FullPath(string path)
		{
			if (PathIsAbsolute(path)) return path;

			return Path.Combine(Context.FilesDir.Path, path);
		}

		private bool PathIsAbsolute(string path)
		{
			return path.StartsWith("/");
		}
	}
}

