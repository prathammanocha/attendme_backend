using DEKODE.AttendMe.Api.Model.Entities;
using MimeKit;
using System.Collections.Generic;

namespace DEKODE.AttendMe.Api.Services
{
    public class Message
    {
        // https://code-maze.com/aspnetcore-send-email/

        public List<MailboxAddress> To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        // public Message(IEnumerable<string> to, string subject, string content)
        public Message(OrganisationUser user, string resetLink)
        {
            To = new List<MailboxAddress>();
            //To.AddRange(to.Select(x => new MailboxAddress(x, x)));
            To.Add(new MailboxAddress($"{user.FirstName} {user.LastName}", user.Email));
            Subject = "AttendMe: Password reset information";
            Content = $"Click below to reset your password{System.Environment.NewLine}{System.Environment.NewLine}{resetLink}";
        }
    }
}