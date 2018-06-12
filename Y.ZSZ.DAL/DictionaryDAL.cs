using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;
using Y.ZSZ.Entity;

namespace Y.ZSZ.DAL
{
    public class DictionaryDAL
    {
        public List<DictionaryDTO> GetByTypes(params string[] types)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<DictionaryEntity> dAL = new CommonDAL<DictionaryEntity>(context);
                return dAL.GetModels(s => types.Contains(s.Type)).ToList().Select(s => ToDTO(s)).ToList();

            }
        }

        private DictionaryDTO ToDTO(DictionaryEntity s)
        {
            if (s == null)
            {
                return null;
            }

            return new DictionaryDTO
            {
                Name = s.Name,
                CreateDate = s.CreateDate,
                Id = s.Id,
                type = s.Type
            };
        }
    }
}
