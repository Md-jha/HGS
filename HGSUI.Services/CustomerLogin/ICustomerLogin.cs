using HGS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HGS.Services
{
    public interface ICustomerLogin
    {
        //Task<CustomerSignup> CustomerLogin(string EmailAddress);
        //Task<string> ForgetPassword(string EmailAddress);
        //Task<CustomerSignup> Reset(string EmailAddress);
        //Task UpdatePassword(byte[] Password, int CustomerId);
        //Task<bool> CheckExistingMailId(string EmailAddress);
        //Task UpdateOTPVerification(int CustomerId);
        //Task UpdateOTP(string EmailAddress, string OTP);
        //Task UpdateLastLogin(int CustomerId);
        //Task InsertActivityLog(string CurrentUrl,int CustomerId);
        //Task AddVisitorCount(int Count);
        //Task UpdateVisitorCount(int Count);
        //Task<VisitorCountrModel> GetVisitorCount();
		Task<IList<BlogModel>> GetBlogList();
		//Task<BlogModel> GetBlogById(int BlogId);
        Task<BlogModel> GetBlogByTopic(string blogTopic);

    }
}
