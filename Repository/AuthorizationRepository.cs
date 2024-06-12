using Newtonsoft.Json;
using System.Data;
using Dapper;
using AuthorizationAPI.Controllers;

namespace AuthorizationAPI.Repository
{
    public class AuthorizationRepository : DBContext
    {
        public bool IsValidEmployee(string Empid)
        {
            bool result = false;
            try
            {
                con.Open();
                var param = new { Empid = Empid };
                var res = con.QueryMultiple("SP_CheckUser", param, commandType: CommandType.StoredProcedure);
                dynamic rs = res.Read();
                var json = JsonConvert.SerializeObject(rs);
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
                if (dt != null && dt.Rows.Count > 0)
                {
                    result = true;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                result = false;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
    }

}
