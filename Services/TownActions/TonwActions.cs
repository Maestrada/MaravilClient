using BAL.Models;
using DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TownActions
{
    public class TonwActions : ITonwActions
    {
        private MaravilContext townContext;

        public TonwActions(MaravilContext context)
        {
            townContext = context;
        }
        public Town GetTownById(int townId)
        {
            return townContext.Towns.FirstOrDefault(x => x.Id == townId);
        }

        public List<Town> GetTowns( string townName)
        {
            if (string.IsNullOrEmpty(townName.Trim()))
            { 
                return townContext.Towns.ToList();
            }
            else 
            {
                return townContext.Towns.Where(x=>x.Name.Contains(townName)).ToList();
            }
        }

        public List<Town> GetTownsByStateId(int stateId)
        {
            return townContext.Towns.Where(x => x.StateId == stateId).ToList();
        }
    }
}
