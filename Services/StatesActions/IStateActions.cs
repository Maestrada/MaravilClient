using BAL.Models;
using DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.StatesActions
{
    public interface IStateActions
    {       
        public List<State> GetStates(string stateName);
        public State GetStateById(int stateId);
        
    }
}
