using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace ServiceWCF
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Servicewcf" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Servicewcf.svc or Servicewcf.svc.cs at the Solution Explorer and start debugging.
	public class Servicewcf : IService1
	{
		public float GetPrice(string id)
		{
			Thread.Sleep(5000);
			switch (id)
			{
				case "chaussure":
					return 20f;
				case "voiture":
					return 20000f;
				default:
					return 0f;
			}
		}
		public string GetData(int value)
		{
			return $"You entered: {value}";
		}

		public CompositeType GetDataUsingDataContract(CompositeType composite)
		{
			if (composite == null)
			{
				throw new ArgumentNullException("composite");
			}
			if (composite.BoolValue)
			{
				composite.StringValue += "Suffix";
			}
			return composite;
		}
	}
}
