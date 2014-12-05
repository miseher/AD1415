using System;

namespace Preflection
{
	public class NotBlankAttribute: ValidationAttribute	{
		private string message="No puede estar vacio";
		public override string Validate (object value)
		{
			if (value == null)
				return message;

			string stringvalue = value.ToString ();
			if (stringvalue.Trim () == " ")
				return message;
			return null;
		}


	}
}

