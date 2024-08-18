using E_RandevuDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_RandevuApplication.Services;

public  interface IJwtProvider
{
    string CreateToken(AppUser user);
}
