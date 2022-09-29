using BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TownActions
{
    public interface ITonwActions
    {
        public List<Town> GetTowns(string stateName);
        public List<Town> GetTownsByStateId(int stateId);
        public Town GetTownById(int townId);
    }
}
