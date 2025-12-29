using HGS.Services;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HGS.Model;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace HGS.Services
{
    public class CustomerLoginServices: ICustomerLogin
    {

        private readonly IDapper _dapper;
        private readonly IConfiguration configuration;

        public CustomerLoginServices(IDapper dapper, IConfiguration configuration)
        {
            _dapper = dapper;
            this.configuration = configuration;
        }


        //public async Task<CustomerSignup> CustomerLogin(string emailaddress)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@emailaddress", emailaddress);
        //        string query = string.Empty;
        //        query = "select customerid,firstname,lastname,emailaddress,password,Nationality,OTP,OTPVerification from customerregistration where " +
        //            "emailaddress=@emailaddress and IsActive=1 and IsDelete=0";
        //        return await _dapper.GetFirstOrDefaultAsync<CustomerSignup>(query, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public async Task<string> ForgetPassword(string EmailAddress)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@EmailAddress", EmailAddress);
        //        string query = string.Empty;

        //        query = "select EmailAddress from customerregistration where EmailAddress=@EmailAddress";

        //        return await _dapper.GetFirstOrDefaultAsync<string>(query, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<CustomerSignup> Reset(string EmailAddress)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@EmailAddress", EmailAddress);
        //        string query = string.Empty;
        //        query = "select CustomerId,EmailAddress,Password from customerregistration where EmailAddress=@EmailAddress";
        //        return await _dapper.GetFirstOrDefaultAsync<CustomerSignup>(query, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task UpdatePassword(byte[] Password, int CustomerId)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@Password", Password);
        //        parameters.Add("@CustomerId", CustomerId);
        //        string query = string.Empty;
        //        query = $"update customerregistration set Password=@Password where CustomerId=@CustomerId";
        //        await _dapper.GetFirstOrDefaultAsync<CustomerSignup>(query, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<bool> CheckExistingMailId(string EmailAddress)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@EmailAddress", EmailAddress);
        //        string query = string.Empty;
        //        query = "Select count(CustomerId) from customerregistration WHERE isDelete=0 and EmailAddress=@EmailAddress";
        //        int count = await _dapper.GetFirstOrDefaultAsync<int>(query, parameters);
        //        if (count == 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex) { throw ex; }
        //}

        //public async Task UpdateOTPVerification(int CustomerId)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@CustomerId", CustomerId);
        //        string query = string.Empty;
        //        query = $"update CustomerRegistration set OTPVerification=1 where CustomerId=@CustomerId";
        //        await _dapper.InsertDelete(query, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public async Task UpdateOTP(string EmailAddress, string OTP)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@EmailAddress", EmailAddress);
        //        parameters.Add("@OTP", OTP);
        //        string query = string.Empty;
        //        query = $"update CustomerRegistration set OTP=@OTP where EmailAddress=@EmailAddress";
        //        await _dapper.InsertDelete(query, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public async Task UpdateLastLogin(int CustomerId)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@CustomerId", CustomerId);
        //        string query = string.Empty;
        //        query = $"update CustomerRegistration set LoginDateTime=GetDate() where CustomerId=@CustomerId";
        //        await _dapper.InsertDelete(query, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public  async Task InsertActivityLog(string CurrentUrl, int CustomerId)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@CurrentUrl", CurrentUrl);
        //        parameters.Add("@CustomerId", CustomerId);
        //        string query = string.Empty;
        //        query = $"insert into ActivityLog (Activity,CustomerId,CreateDate) Values(@CurrentUrl,@CustomerId,GetDate())";
        //        await _dapper.InsertDelete(query, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task AddVisitorCount(int Count)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@Count", Count);
        //        string query = string.Empty;
        //        query = $"insert into VisitorCount(Count,CreatedDate) values (@Count,GETDATE())";
        //        await _dapper.InsertDelete(query, parameters);
        //    }

        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}

        //public async Task UpdateVisitorCount(int Count)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@Count", Count);
        //        string query = string.Empty;
        //        query = $"update VisitorCount set Count=@Count,UpdatedDate=GETDATE()";
        //        await _dapper.InsertDelete(query, parameters);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        //public async Task<VisitorCountrModel> GetVisitorCount()
        //{
        //    try
        //    {
        //        string query = string.Empty;
        //        query = $"select Count from VisitorCount";
        //        return await _dapper.GetFirstOrDefaultAsync<VisitorCountrModel>(query);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

		public async Task<IList<BlogModel>> GetBlogList()
		{
			try
			{
				var ImageUrl = configuration.GetSection("BaseUrl")["AdminUrl"];
				var parameters = new DynamicParameters();
				string query = string.Empty;
				parameters.Add("@ImageUrl", ImageUrl);
				query = "select BlogId,AuthorName,BlogTopic,(@ImageUrl+BlogImageUrl) as BlogImageUrl,MetaDescreption,MetaTags,BlogContent,PostedDate from Blog where " +
					"IsActive=1 and IsDelete=0 order by BlogId desc";
				var data = await _dapper.GetAllAsync<BlogModel>(query, parameters);
				return data.ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        //public async Task<BlogModel> GetBlogById(int BlogId)
         //{
        //	try
        //	{
        //		var ImageUrl = configuration.GetSection("BaseUrl")["AdminUrl"];
        //		var parameters = new DynamicParameters();
        //		parameters.Add("@BlogId", BlogId);
        //		parameters.Add("@ImageUrl", ImageUrl);
        //		string query = string.Empty;
        //		query = "select BlogId,AuthorName,BlogTopic,(@ImageUrl+BlogImageUrl) as BlogImageUrl,MetaDescreption,MetaTags,BlogContent,BlogContent as BlogContentData,PostedDate " +
        //			"from Blog where BlogId=@BlogId and IsActive=1 and IsDelete=0 ";
        //		var data = await _dapper.GetFirstOrDefaultAsync<BlogModel>(query, parameters);
        //		return data;
        //	}
        //	catch (Exception ex)
        //	{
        //		throw ex;
        //	}
        //}

        public async Task<BlogModel> GetBlogByTopic(string blogTopic)
        {
            try
            {
                var ImageUrl = configuration.GetSection("BaseUrl")["AdminUrl"];
                var parameters = new DynamicParameters();
                parameters.Add("@BlogTopic", blogTopic);
                parameters.Add("@ImageUrl", ImageUrl); 

               string query = string.Empty;
                		query = "select BlogId,AuthorName,BlogTopic,(@ImageUrl+BlogImageUrl) as BlogImageUrl,MetaDescreption,MetaTags,BlogContent,BlogContent as BlogContentData,PostedDate " +
                        "from Blog where BlogTopic = @BlogTopic and IsActive=1 and IsDelete=0 ";

                var data = await _dapper.GetFirstOrDefaultAsync<BlogModel>(query, parameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
