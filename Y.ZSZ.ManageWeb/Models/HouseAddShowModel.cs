using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Y.ZSZ.DTO;

namespace Y.ZSZ.ManageWeb.Models
{
    public class HouseAddShowModel
    {
        public List<RegionDTO> RegionDTOs { get; set; }

        public List<DictionaryDTO> DictionaryDTOs { get; set; }
        public List<CommunityDTO> CommunityDTOs { get; set; }
    }
}