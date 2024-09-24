using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shop.Domain.Order_Aggregate.Enums
{
	public enum OrderStatus
	{
		Pending,//در انتظار
		Finally,// نهایی
		Shipping,// ارسال با حمل و نقل
		Rejected//رد شد
	}
}
