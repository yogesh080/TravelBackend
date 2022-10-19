using BusinessLayer.Interfaces;
using CommonLayer.AddStateModel;
using RepoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class AddStateBL : IAddStateBL
        
    {
        private readonly IAddStateRL stateRL;
        public AddStateBL(IAddStateRL stateRL)
        {
            this.stateRL = stateRL;
        }

        public  AddStateModel AddState( AddStateModel addstatemodel)
        {
            try
            {
                return stateRL.AddState(addstatemodel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
