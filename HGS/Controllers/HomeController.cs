using HGS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HGS.Services.Mail;
using HGS.Utilites;
using HGS.Services;
using HGS.Model;
using System.Text.RegularExpressions;

namespace HGS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBasicUtility _basic;
        private readonly IJsonResponseFromat _jsonResponseFromat;
        private readonly IMailService _mailservice;
        private readonly ICustomerLogin _customerLogin;
        public HomeController(ILogger<HomeController> logger, IMailService mailservice, IBasicUtility basic, IJsonResponseFromat JsonResponseFromat, ICustomerLogin customerLogin)
        {
            _logger = logger;
            _mailservice = mailservice;
            _basic = basic;
            _jsonResponseFromat = JsonResponseFromat;
            _customerLogin = customerLogin;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult faqs()
        {
            return View();
        }
        public IActionResult blog()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        public IActionResult career()
        {
            return View();
        }
        public IActionResult about()
        {
            return View();
        }
        public IActionResult blaze()
        {
            return View();
        }
        public IActionResult leopard()
        {
            return View();
        }
        public IActionResult product()
        {
            return View();
        }
        public IActionResult productdetails()
        {
            return View();
        }
        public IActionResult sapphire()
        {
            return View();
        }
		public IActionResult FabricPrintingMachineandTextilePrinterGuide()
		{
			return View();
		}
		public IActionResult FabricsWorkBestForDigitalTextile()
		{
			return View();
		}
		public IActionResult FabricSelectionMatters()
		{
			return View();
		}
        public IActionResult TextilePrintervsFabricPrinter()
        {
            return View();
        }
        public IActionResult blog4()
		{
			return View();
		}
		public IActionResult KeyConsiderations()
		{
			return View();
		}
		public IActionResult huegush()
        {
            return View();
        }
        public IActionResult richotejas()
        {
            return View();
        }
        public IActionResult chrome()
        {
            return View();
        }
       
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Ludhiana()
        {
            return View();
        }
        public IActionResult Surat()
        {
            return View();
        }

        public IActionResult Delhi()
        {
            return View();
        }
        public IActionResult Tirupur()
        {
            return View();
        }
        public IActionResult Mumbai()
        {
            return View();
        }
        public IActionResult Banglore()
        {
            return View();
        }
        public IActionResult Gurgaon()
        {
            return View();
        }
        public IActionResult Hydrabad()
        {
            return View();
        }
        public IActionResult Kolkata()
        {
            return View();
        }
        public IActionResult Mohali()
        {
            return View();
        }
        public IActionResult Noida()
        {
            return View();
        }
		public IActionResult CompleteGuide()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> Contact(Contact data)
        {
            await SendMail(data);
            ModelState.Clear();
            TempData["SuccessMessage"] = "Thanks for Contacting us we will get back to you soon";
            return RedirectToAction("contact", "Home");
        }




        private async Task SendMail(Contact data)
        {
            MailRequest sendmail = new MailRequest();
            //sendmail.ToEmail = data.Email;
            sendmail.ToEmail = "madhavkumarjha84@gmail.com";
            sendmail.Subject = "Website Enquiry for HGS.";
            sendmail.Body = _basic.GenrateContactEmailTamplet(data);
            await _mailservice.SendEmailAsync(sendmail);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpGet]
        //public async Task<IActionResult> Blog1(int BlogId)
        //{
        //    try
        //    {
        //        IList<BlogModel> BlogList1 = new List<BlogModel>();
        //        var result = await _customerLogin.GetBlogById(BlogId);
        //        if (result != null)
        //        {
        //            string BlogContentDataSepration = result.BlogContentData.Replace("\r\n", "<br/>");
        //            BlogList1 = await _customerLogin.GetBlogList();

        //            BlogViewModel model = new BlogViewModel()
        //            {
        //                BlogList = (List<BlogModel>)BlogList1,
        //                BlogId = result.BlogId,
        //                AuthorName = result.AuthorName,
        //                BlogTopic = result.BlogTopic,
        //                BlogImage = result.BlogImage,
        //                BlogImageUrl = result.BlogImageUrl,
        //                BlogContent = result.BlogContent,
        //                BlogContentDataSepration = BlogContentDataSepration,
        //                PostedDate = result.PostedDate,
        //                MetaDescreption=result.MetaDescreption,
        //                MetaTags=result.MetaTags
        //            };

        //            return View(model);
        //        }
        //        else
        //        {
        //            BlogViewModel model = new BlogViewModel();
        //            return View(model);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [HttpGet("{blogTopic}")]
        public async Task<IActionResult> Blog1(string blogTopic)
        {
            try
            {
                IList<BlogModel> BlogList1 = new List<BlogModel>();

                // Convert slug back into normal topic
                var originalTopic = blogTopic.Replace("-", " ");

                // Fetch by topic
                var result = await _customerLogin.GetBlogByTopic(originalTopic);
                if (result != null)
                {
                    string BlogContentDataSepration = result.BlogContentData.Replace("\r\n", "<br/>");
                    BlogList1 = await _customerLogin.GetBlogList();

                    BlogViewModel model = new BlogViewModel()
                    {
                        BlogList = (List<BlogModel>)BlogList1,
                        BlogId = result.BlogId,
                        AuthorName = result.AuthorName,
                        BlogTopic = result.BlogTopic,
                        BlogImage = result.BlogImage,
                        BlogImageUrl = result.BlogImageUrl,
                        BlogContent = result.BlogContent,
                        BlogContentDataSepration = BlogContentDataSepration,
                        PostedDate = result.PostedDate,
                        MetaDescreption = result.MetaDescreption,
                        MetaTags = result.MetaTags
                    };

                    return View(model);
                }
                else
                {
                    return View(new BlogViewModel());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpGet]
        public async Task<IActionResult> Bloglist()
        {
            try
            {
                IList<BlogModel> blogList = new List<BlogModel>();
                blogList = await _customerLogin.GetBlogList();
                foreach (var obj in blogList)
                {
                    string BlogContent = Regex.Replace(obj.BlogContent, "<[^>]*?>", String.Empty);
                    string BlogContent2 = BlogContent.Replace("&nbsp;", "");
                    obj.BlogContent = BlogContent2;
                }
                return View(blogList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
