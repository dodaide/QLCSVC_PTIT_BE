using Application.DTOs.AreaCampusDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AreaDTO
{
    public class AreaUpdateDTO
    {
        public AreaUpdateMasterDTO Area { get; set; }
        public List<AreaCampusSaveDTO> Details { get; set; }
    }
}
