using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonStatisticsAPI.DataModels.DTOs
{
    public class UserDto: BaseDto
    {
        public string Login { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
    }
}
