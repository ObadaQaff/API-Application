using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Usrs
{
    public class UserMapperProfile
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

    }
}
