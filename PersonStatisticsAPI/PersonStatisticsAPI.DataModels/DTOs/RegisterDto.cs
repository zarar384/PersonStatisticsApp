using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonStatisticsAPI.DataModels.DTOs
{
    public class RegisterDto : BaseDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public PersonDto personDto { get; set; }
    }
}
