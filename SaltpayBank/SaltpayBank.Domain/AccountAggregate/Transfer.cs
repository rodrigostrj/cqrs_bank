using SaltpayBank.Domain.AccountAggregate.ValueObjects;
using SaltpayBank.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Domain.AccountAggregate
{
    public class Transfer : BaseEntity
    {
        public int Id { get; set; }
        public Account OriginAccount { get; set; }
        public Account DestinyAccount { get; set; }
        public Money MoneyToTransfer { get; set; }
        public DateTime DateTransfer { get; set; }
    }
}
