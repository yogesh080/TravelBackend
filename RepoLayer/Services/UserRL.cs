using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CommonLayer.UserModel;

namespace RepoLayer.Interfaces
{
    public class UserRL:IUserRL
    {
        private readonly IConfiguration configuration;
        private readonly IConfiguration _AppSetting;
        public UserRL(IConfiguration configuration, IConfiguration _AppSetting)
        {
            this.configuration = configuration;
            this._AppSetting = _AppSetting;
        }

        public UserDataModel Register(UserDataModel usermodel)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(configuration["ConnectionString:TravelDB"]);
                SqlCommand cmd = new SqlCommand("spUserRegister", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@FullName", usermodel.FullName);
                cmd.Parameters.AddWithValue("@Email", usermodel.Email);
                cmd.Parameters.AddWithValue("@Password", usermodel.Password);
                cmd.Parameters.AddWithValue("@MobileNumber", usermodel.MobileNumber);

                connection.Open();
                var result = cmd.ExecuteNonQuery();
                connection.Close();

                if (result != 0)
                {
                    return usermodel;
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
