using System;
using Gtk;


namespace Preflection
{
	public class Categoria
	{   

		[Entity(TableName ="category")]
		public Categoria(ulong id, string nombre){
			this.id=id;
			this.nombre = nombre;
		}

		[Id]
		private ulong id;
		//[Column
		private string nombre;

		public ulong Id{
			get{return id;}
			set{ id = value;}

		}

		//[NotBlank]
		public string Nombre{
			get{return nombre;}
			set{ nombre = value;}


		}



	}
}

