using System;
using System.Collections.Generic;
using System.Text;

namespace SaltpayBank.Application.Models
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerator<AccountDTO> AccountList { get; set; }
    }
}
