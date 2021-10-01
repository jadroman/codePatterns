using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
//  1. first we have fat class:
//  	- Invoice Class:
//  		- Add invoice
//  		- Delete invoice
//  		- Send Invoice email
	    	
//  2. than we have seperated classes
//  	- invoice class
//  	- emailSender class
/// </summary>
namespace SOLID_SRP
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoice invc = new Invoice();
            invc.AddInvoice();
        }
    }

    class Invoice
    {
        public long InvAmount { get; set; }
        public DateTime InvDate { get; set; }
        private MailSender emailSender;
        public Invoice()
        {
            emailSender = new MailSender();
        }
        public void AddInvoice()
        {
            // Here we need to write the Code for adding invoice
            // Once the Invoice has been added, then send the  mail
            emailSender.EMailFrom = "emailfrom@xyz.com";
            emailSender.EMailTo = "emailto@xyz.com";
            emailSender.EMailSubject = "Single Responsibility Princile";
            emailSender.EMailBody = "A class should have only one reason to change";
            emailSender.SendEmail();
        }
        public void DeleteInvoice()
        {
            //Here we need to write the Code for Deleting the already generated invoice
        }
    }

    class MailSender
    {
        public string EMailFrom { get; set; }
        public string EMailTo { get; set; }
        public string EMailSubject { get; set; }
        public string EMailBody { get; set; }
        public void SendEmail()
        {
            // Here we need to write the Code for sending the mail
        }
    }

}
