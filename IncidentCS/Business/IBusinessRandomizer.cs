using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentCS
{
	public interface IBusinessRandomizer
	{
		string CompanyType { get; }

		string Company { get; }

		string Phone { get; }
	}
}
