
using Microsoft.Extensions.Configuration;
using RepoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CommonLayer.AddStateModel;

namespace RepoLayer.Services
{
    public class AddStateRL: IAddStateRL
    {
        private readonly IConfiguration configuration;
        private readonly IConfiguration _AppSetting;
        public AddStateRL(IConfiguration configuration, IConfiguration _AppSetting)
        {
            this.configuration = configuration;
            this._AppSetting = _AppSetting;
        }

        public AddStateModel AddState(AddStateModel addstatemodel)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(configuration["ConnectionString:TravelDB"]);
                SqlCommand cmd = new SqlCommand("spAddState", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@StateName", addstatemodel.StateName);
                cmd.Parameters.AddWithValue("@AboutState", addstatemodel.AboutState);
                cmd.Parameters.AddWithValue("@StateImage", addstatemodel.StateImage);

                connection.Open();
                var result = cmd.ExecuteNonQuery();
                connection.Close();

                if (result != 0)
                {
                    return addstatemodel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }

}
