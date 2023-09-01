using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransfer.Models;

namespace DataTransfer.Stores
{
    public class SignupStore
    {
        // TODO : LoginVM.cs 데이터를 타 뷰모델(SignupVM.cs, TestVM.cs)로 전송할 수 있도록 모델 구현 (2023.08.30 jbh)
        public Account CurrentAccount { get; set; }
    }
}
