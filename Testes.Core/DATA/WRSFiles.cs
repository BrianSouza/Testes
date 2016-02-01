using System;
using Cirrious.MvvmCross.Plugins.File;
using Cirrious.CrossCore;
using System.IO;
using System.Text;

namespace Testes.Core.DATA
{
	public class WRSFiles 
	{
		public static bool Save(string escrever)
		{
			try {
				var fileService = Mvx.Resolve<IMvxFileStore>();
				fileService.WriteFile("Teste.txt",escrever);
				return true;
			} catch (Exception ex) {
				throw new Exception("Não foi possível salvar o arquivo");
			}

		}
		public static void Delete()
		{
			var fileService = Mvx.Resolve<IMvxFileStore>();
			if(fileService.Exists ("Teste.txt"))
				fileService.DeleteFile ("Teste.txt");
		}

		public static string Ler()
		{
			var fileService = Mvx.Resolve<IMvxFileStore> ();
			string sRetorno = string.Empty;
			if (fileService.Exists ("Teste.txt")) {
				if (fileService.TryReadTextFile ("Teste.txt", out sRetorno))
					return sRetorno;
				else
					throw new Exception ("Erro ao ler arquivo");
			}
			else
				throw new Exception ("Erro ao ler arquivo");
		}

	}
}

