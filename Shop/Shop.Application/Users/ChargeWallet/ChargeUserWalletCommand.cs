using Common.L2.Application;
using Shop.L1.Domain.User_Aggregate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Users.ChargeWallet
{
	public class ChargeUserWalletCommand : IBaseCommand
	{
		public ChargeUserWalletCommand(long userId, int price, string description, bool isFinally, WalletType type)
		{
			UserId = userId;
			Price = price;
			Description = description;
			IsFinally = isFinally;
			Type = type;
		}
		public long UserId { get; private set; }
		public int Price { get; private set; }
		public string Description { get; private set; }
		public bool IsFinally { get; private set; }
		public WalletType Type { get; private set; }
	}
}
