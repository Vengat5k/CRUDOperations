using AuthorizationAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace AuthorizationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : Controller
    {
        CRURRepository _CrudRepo = new CRURRepository();

        [HttpPost("InsertItemDetails")]
        public IActionResult InsertItemDetails(string ItemName, string UnitPrice, string Quantity, string Description, string TotalPrice, DateTime InsertedAt)
        {
            string returnResult = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    int res = _CrudRepo.InsertItemDetails(ItemName, UnitPrice, Quantity, Description, TotalPrice, InsertedAt);
                    if (res == 1)
                    {
                        returnResult = "Record inserted successfully";
                        var json = JsonConvert.SerializeObject(
                            new
                            {
                                Result = returnResult
                            }
                            );

                        return Ok(json);
                    }
                }
                catch (Exception ex)
                {
                    returnResult = "Insert failed" + ex.Message;
                    var json = JsonConvert.SerializeObject("{Result:Record insert Failed}");
                    return Ok(json);
                }
            }
            else
            {
                returnResult = "Invalid Input";
            }
            return Ok(returnResult);
        }
        [HttpPut("UpdateItemDetails")]
        public IActionResult UpdateItemDetails(string ItemName, string UnitPrice, string Quantity, string Description, string TotalPrice, DateTime InsertedAt)
        {
            string returnResult = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    int res = _CrudRepo.UpdateItemDetails(ItemName, UnitPrice, Quantity, Description, TotalPrice, InsertedAt);
                    if (res == 1)
                    {
                        returnResult = "Record updated successfully";
                        var json = JsonConvert.SerializeObject(
                            new
                            {
                                Result = returnResult
                            }
                            );

                        return Ok(json);
                    }
                }
                catch (Exception ex)
                {
                    returnResult = "Update failed" + ex.Message;
                    var json = JsonConvert.SerializeObject("{Result:Record update Failed}");
                    return Ok(json);
                }
            }
            else
            {
                returnResult = "Invalid Input";
            }
            return Ok(returnResult);
        }
        [HttpDelete("DeleteItemDetails")]
        public IActionResult DeleteItemDetails(string Id)
        {
            string returnResult = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    int res = _CrudRepo.DeleteItemDetails(Id);
                    if (res == 1)
                    {
                        returnResult = "Record Delete successfully";
                        var json = JsonConvert.SerializeObject(
                            new
                            {
                                Result = returnResult
                            }
                            );

                        return Ok(json);
                    }
                }
                catch (Exception ex)
                {
                    returnResult = "Delete failed" + ex.Message;
                    var json = JsonConvert.SerializeObject("{Result:Record Delete Failed}");
                    return Ok(json);
                }
            }
            else
            {
                returnResult = "Invalid Input";
            }
            return Ok(returnResult);
        }

        [Authorize]
        [HttpGet("GetItemDetails")]
        public IActionResult GetItemDetails(String Id)
        {
            string returnResult = string.Empty;
            DataTable dataTable = new DataTable();
            if (ModelState.IsValid)
            {
                try
                {
                    dataTable = _CrudRepo.GetItemDetails(Id);
                    var json = JsonConvert.SerializeObject(dataTable);
                    return Ok(json);
                }


                catch (Exception ex)
                {
                    var json = JsonConvert.SerializeObject("{Result: Get Record Failed}");
                    return Ok(json);
                }
            }
            else
            {
                returnResult = "Invalid Input";
            }
            return Ok(returnResult);

        }
    }

}
