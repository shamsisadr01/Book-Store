using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.L1.Domain;

namespace Shop.L1.Domain.Order_Aggregate.Events
{
	public class OrderFinalized : BaseDomainEvent
	{
		public OrderFinalized(long id)
		{
			Id = id;
		}

		public long Id { get; set; }

	}
}
