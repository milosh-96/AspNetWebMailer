# WebMailer

This is a demo ASP.NET Core 8 project for sending emails. 

## Why

There are many ways to send emails with ASP.NET, but you can follow this repo as a some sort of reference how to configure your project to be able to send emails via SMTP. 

## How to use?

This project uses ``secrets.json`` or ``appSettings.json``. You should put your SMTP settings in "MailSettings" section.

## File Structure

``Application/Mailing/MailService.cs`` - this service configures the SMTP client and and has a  method that send emails.


``Controllers/HomeController.cs`` - I decided to keep it simple, so the email service is called from the Index method.

``Domain/Settings/MailSettings.cs`` - "MailSettings" secton from the configuration file (``secrets.json`` or ``appSettings.json``) will be mapped to the properties of this class.

``Program.cs`` - `MailService` is added as a scoped service on the line 13.

## Identity
ASP.NET Core Identity expects that the mail service class implements ``IEmailSender`` interface. 
