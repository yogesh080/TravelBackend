﻿using CommonLayer.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interfaces
{
    public interface IUserRL
    {
        public UserDataModel Register(UserDataModel usermodel);

    }
}
