using BAL.Models;
using DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.StatesActions
{
    public class StateActions : IStateActions
    {
        private MaravilContext stateContext;
        public StateActions(MaravilContext context)
        {
            stateContext = context;
        }
        public State GetStateById(int stateId)
        {
            return stateContext.States.FirstOrDefault(x => x.Id == stateId);
        }

        public List<State> GetStates(string stateName)
        {
            if (string.IsNullOrEmpty(stateName.Trim()))
            {
                return stateContext.States.ToList();
            }
            else
            {
                return stateContext.States.Where(x=>x.Name.Contains(stateName)).ToList();
            }
        }
    }
}
