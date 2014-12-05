using System;

namespace Preflection
{
	public class EntityAttribute: Attribute {
		public EntityAttribute(){
			Console.WriteLine("Entity Attribute");
		}

		public string TableName{ get; set;}
	
	}
}

