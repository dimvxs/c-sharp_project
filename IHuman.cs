using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace hw
{
    public interface IHuman
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        void CreateAccount();
        bool SignIn();
    }
}