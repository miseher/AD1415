using System;

namespace Preflection
{
	public class Articulo
	{
		[Entity]
		public ulong Id {get ; set ;}
		public string Nombre { get; set;}
		public Categoria Categoria { get; set;}
		public decimal Precio{ get; set; }
	

	}
}

