
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
    public class AddStateRL : IAddStateRL
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

        public List<GetStateModel> GetallState()
        {
            List<GetStateModel> result = new List<GetStateModel>();
            using SqlConnection connection = new SqlConnection(configuration["ConnectionString:TravelDB"]);
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spGetAllState", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        GetStateModel model = new GetStateModel
                        {
                            StateId = reader["StateId"] == DBNull.Value ? default : reader.GetInt32("StateId"),
                            StateName = reader["StateName"] == DBNull.Value ? default : reader.GetString("StateName"),
                            AboutState = reader["AboutState"] == DBNull.Value ? default : reader.GetString("AboutState"),
                            StateImage = reader["StateImage"] == DBNull.Value ? default : reader.GetString("StateImage")
                        };
                        result.Add(model);
                    }

                    return result;
                }

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                connection.Close();
            }

        }
    }
}


