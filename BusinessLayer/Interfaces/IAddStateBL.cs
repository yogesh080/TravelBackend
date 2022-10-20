using CommonLayer.AddStateModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IAddStateBL
    {
        public AddStateModel AddState(AddStateModel addstatemodel);
        public List<GetStateModel> GetallState();


    }
}
