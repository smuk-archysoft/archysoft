using System;
using System.Globalization;
using System.IO;
using Archysoft.Domain.Model.Model.Employees;
using Archysoft.Domain.Model.Services.Abstract;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace Archysoft.Domain.Model.Services.Concrete
{
    public class PdfService : IPdfService
    {
        public EmployeePdfModel GeneratePdf(EmployeeDetailsModel user)
        {
            using (var memoryStream = new MemoryStream())
            {
                EmployeePdfModel employeePdf = new EmployeePdfModel();
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);

                PdfWriter pdfWriter = PdfWriter.GetInstance(document, memoryStream);

                document.AddAuthor("Archysoft");
                document.AddCreator("Archysoft");
                document.AddKeywords(user.FirstName + " resume");
                document.AddSubject(user.LastName);
                document.AddTitle("The document title - PDF creation using iTextSharp");

                document.Open();

                AddHeader(document, user);
                document.Add(new LineSeparator());
                AddPersonalInfo(document, user);
                AddExperience(document, user);
                AddEducation(document, user);
                AddSkills(document, user);
                AddLanguages(document, user);

                document.Close();
                pdfWriter.Close();
                employeePdf.Data = memoryStream.ToArray();
                return employeePdf;
            }
        }

        private static void AddHeader(IElementListener document, EmployeeDetailsModel user)
        {
            var table = new PdfPTable(3) { WidthPercentage = 100 };
            table.DefaultCell.Border = Rectangle.NO_BORDER;
            table.SpacingAfter = 20;

            Image image = Image.GetInstance(user.Photo);
            image.ScaleToFit(80,80);
            image.ScaleToFitHeight = true;
            

            var imageCell = new PdfPCell(image) { Border = Rectangle.NO_BORDER };
            var nameCell = new PdfPCell { Border = Rectangle.NO_BORDER };
            var namePhrase = new Phrase(user.FirstName + " " + user.LastName);
            nameCell.AddElement(namePhrase);

            var infoCell = GetUserContactsTable(user);

            table.AddCell(imageCell);
            table.AddCell(nameCell);
            table.AddCell(infoCell);

            document.Add(table);
        }

        private static PdfPTable GetUserContactsTable(EmployeeDetailsModel user)
        {
            var table = new PdfPTable(1) { WidthPercentage = 100 };
            table.DefaultCell.Border = Rectangle.NO_BORDER;

            var email = new Chunk("email: ");
            var userMail = new Chunk(user.Email) {Font = {Color = BaseColor.BLUE}};
            userMail.Font.SetStyle(20);
            var phrase = new Phrase {email, userMail};

            var emailCell = new PdfPCell(phrase) { HorizontalAlignment = Element.ALIGN_LEFT, Border = Rectangle.NO_BORDER  };
            var skypeCell = new PdfPCell(new Phrase("skype: " + user.Skype)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = Rectangle.NO_BORDER };
            var phoneCell = new PdfPCell(new Phrase("phone: " + user.PhoneNumber)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = Rectangle.NO_BORDER };
            var locationCell = new PdfPCell(new Phrase("location: " + user.Country + ", " + user.City)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = Rectangle.NO_BORDER };

            table.AddCell(emailCell);
            table.AddCell(phoneCell);
            table.AddCell(skypeCell);
            table.AddCell(locationCell);

            return table;
        }

        private static void AddPersonalInfo(IElementListener document, EmployeeDetailsModel user)
        {
            var table = new PdfPTable(1) { WidthPercentage = 100 };
            table.DefaultCell.Border = Rectangle.NO_BORDER;
            table.SpacingBefore = 20;
            var headerCell = new PdfPCell { Border = Rectangle.NO_BORDER };
            var headerPhrase = new Phrase("Personal Info");
            headerCell.Phrase = headerPhrase;
            headerPhrase.Font.Color = BaseColor.BLUE;
            table.AddCell(headerCell);
            table.AddCell(user.Description.Title);
            table.AddCell(user.Description.Text);
            document.Add(table);
        }

        private static void AddExperience(IElementListener document, EmployeeDetailsModel user)
        {
            var table = new PdfPTable(2) {WidthPercentage = 100};
            table.SetWidths(new int[] { 1, 4 });
            table.DefaultCell.Border = Rectangle.NO_BORDER;
            table.SpacingBefore = 20;
            var headerCell = new PdfPCell { Border = Rectangle.NO_BORDER, Colspan = 2 };
            var headerPhrase = new Phrase("Experience");
            headerCell.Phrase = headerPhrase;
            headerPhrase.Font.Color = BaseColor.BLUE;
            table.AddCell(headerCell);
            foreach (var experience in user.Experiences)
            {
                var endDate = experience.EndDate != null ? experience.EndDate?.ToString("MMMM yyyy", 
                    CultureInfo.CreateSpecificCulture("en-us")) 
                    : "Current time";
                var years = new Phrase(experience.BeginDate.ToString("MMMM yyyy", 
                                           CultureInfo.CreateSpecificCulture("en-us")) + " -\n" + endDate);
                var yearsCell = new PdfPCell(years) { Border = Rectangle.NO_BORDER, Rowspan = 2};
                table.AddCell(yearsCell);
                table.AddCell(experience.Position);
                table.AddCell(experience.Description);
            }
            document.Add(table);
        }

        private static void AddEducation(IElementListener document, EmployeeDetailsModel user)
        {
            var table = new PdfPTable(2) { WidthPercentage = 100 };
            table.SetWidths(new int[] {1, 4});
            table.DefaultCell.Border = Rectangle.NO_BORDER;
            table.SpacingBefore = 20;
            var headerCell = new PdfPCell { Border = Rectangle.NO_BORDER, Colspan = 2 };
            var headerPhrase = new Phrase("Education");
            headerCell.Phrase = headerPhrase;
            headerPhrase.Font.Color = BaseColor.BLUE;
            table.AddCell(headerCell);
            foreach (var education in user.Educations)
            {
                var yearAttendedTo = education.YearAttendedTo != 0 ? education.YearAttendedTo.ToString() :  "Current time";
                var years = new Phrase(education.YearAttendedFrom + " - " + yearAttendedTo);
                table.AddCell(years);
                table.AddCell(education.School);
                table.AddCell("");
                table.AddCell(education.Degree);
            }   
            document.Add(table);
        }

        private static void AddSkills(IElementListener document, EmployeeDetailsModel user)
        {
            var table = new PdfPTable(3) { WidthPercentage = 100 };
            table.DefaultCell.Border = Rectangle.NO_BORDER;
            table.SpacingBefore = 20;
            var headerCell = new PdfPCell {Border = Rectangle.NO_BORDER, Colspan = 3};
            var headerPhrase = new Phrase("Skills & Expertise");
            headerCell.Phrase = headerPhrase;
            headerPhrase.Font.Color = BaseColor.BLUE;
            table.AddCell(headerCell);
            foreach (var skill in user.Skills)
            {
                table.AddCell(skill);
            }
            var last = 3 - user.Skills.Count % 3;
            for (int i = 0; i < last; i++)
            {
                table.AddCell("");
            }
            document.Add(table);
        }

        private static void AddLanguages(IElementListener document, EmployeeDetailsModel user)
        {
            var table = new PdfPTable(1) { WidthPercentage = 100 };
            table.DefaultCell.Border = Rectangle.NO_BORDER;
            table.SpacingBefore = 20;
            var headerCell = new PdfPCell { Border = Rectangle.NO_BORDER };
            var headerPhrase = new Phrase("Language");
            headerCell.Phrase = headerPhrase;
            headerPhrase.Font.Color = BaseColor.BLUE;
            table.AddCell(headerCell);
            var languageContext = user.Languages[0];
            for (var i = 1; i < user.Languages.Count; i++)
            {
                languageContext += " | " + user.Languages[i];
            }
            var cellContext = new PdfPCell(new Phrase(languageContext)) {Border = Rectangle.NO_BORDER};
            table.AddCell(cellContext);
            document.Add(table);
        }
    }
}
