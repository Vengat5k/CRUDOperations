using AuthorizationAPI.Controllers;
using Dapper;
using Newtonsoft.Json;
using System.Data;

namespace AuthorizationAPI.Repository
{
    public class CRURRepository : DBContext
    {
        public int InsertItemDetails(string ItemName, string UnitPrice, string Quantity, string Description, string TotalPrice, DateTime InsertedAt)
        {
            int result = 0;
            try
            {
                con.Open();
                var Param = new DynamicParameters();
                Param.Add("@ItemName", ItemName);
                Param.Add("@UnitPrice", UnitPrice);
                Param.Add("@Quantity", Quantity);
                Param.Add("@Description", Description);
                Param.Add("@TotalPrice", TotalPrice);
                Param.Add("@InsertedAt", InsertedAt);
                var res = con.Execute("SP_Insert", Param, commandType: CommandType.StoredProcedure);
                result = Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public int UpdateItemDetails(string ItemName, string UnitPrice, string Quantity, string Description, string TotalPrice, DateTime InsertedAt)
        {
            int result = 0;
            try
            {
                con.Open();
                var Param = new DynamicParameters();
                Param.Add("@ItemName", ItemName);
                Param.Add("@UnitPrice", UnitPrice);
                Param.Add("@Quantity", Quantity);
                Param.Add("@Description", Description);
                Param.Add("@TotalPrice", TotalPrice);
                Param.Add("@InsertedAt", InsertedAt);
                var res = con.Execute("SP_Update", Param, commandType: CommandType.StoredProcedure);
                result = Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public int DeleteItemDetails(string Id)
        {
            int result = 0;
            try
            {
                con.Open();
                var Param = new DynamicParameters();
                Param.Add("@Id", Id);
                var res = con.Execute("SP_Delete", Param, commandType: CommandType.StoredProcedure);
                result = Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public DataTable GetItemDetails(string Id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                con.Open();
                var p = new DynamicParameters();
                //p.Add("@Empid", Param.Empid);
                p.Add("@Id", Id);
                var result = con.QueryMultiple("SP_Select",
                       p,
                       commandType: CommandType.StoredProcedure,
                       commandTimeout: 200);
                dynamic rs = result.Read();
                var json = JsonConvert.SerializeObject(rs);
                dataTable = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
