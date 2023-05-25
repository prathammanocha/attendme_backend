using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;

        public AccountController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            // Populate the account details from DB
            var account = GetAccountDetails(Guid.NewGuid());

            // AccountViewModel accountViewModel = _mapper.Map<AccountViewModel>(account);

            return View(account);
        }

        private static AccountViewModel GetAccountDetails(Guid accountId)
        {
            // Call API method
            return null;

            //return new Account
            //{
            //    IdentityId = Guid.NewGuid(),
            //    ABN = "123 456 789",
            //    Address = new Address
            //    {
            //        Country = "Australia",
            //        PostCode = "3000",
            //        State = "VIC",
            //        StreetName = "Main Street",
            //        StreetNo = "1",
            //        Suburb = "Melbourne"
            //    },
            //    ContactName = "Steve Smith",
            //    ContactPhone = "0421 196 123",
            //    Email = "s.smith@acb.com.au",
            //    Name = "Australian Cricket Board"
            //};
        }

        //private static Account GetAccountDetails()

        //{
        //    return new Account
        //    {
        //        IdentityId = Guid.NewGuid(),
        //        ABN = "123 456 789",
        //        Address = new Address
        //        {
        //            Country = "Australia",
        //            PostCode = "3000",
        //            State = "VIC",
        //            StreetName = "Main Street",
        //            StreetNo = "1",
        //            Suburb = "Melbourne"
        //        },
        //        ContactName="Steve Smith",
        //        ContactPhone="0421 196 123",
        //        Email="s.smith@acb.com.au",
        //        Name="Australian Cricket Board"
        //    };
        //}
    }
}
