using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaltpayBank.Application.Models
{
    public class TransferDTO
    {
        public DateTime TransferDate { get; set; }
        public decimal TransferAmount { get; set; }
        public decimal AmountBeforeTransfer { get; set; }
    }
}
