#nullable disable
using ControllerSamples.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace ControllerSamples.Formatters
{
    public class VCardInputFormatter : TextInputFormatter //Microsoft.AspNetCore.Mvc.Formatters.TextInputFormatter;
    {
        public VCardInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        //buffer.AppendLine("BEGIN:VCARD");
        //    buffer.AppendLine("VERSION:2.1");
        //    buffer.AppendLine($"N:{contact.LastName};{contact.FirstName}");
        //    buffer.AppendLine($"FN:{contact.FirstName} {contact.LastName}");
        //    buffer.AppendLine($"UID:{contact.ID}");
        //    buffer.AppendLine("END:VCARD");


        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            
            HttpContext httpContext = context.HttpContext;
            
            IServiceProvider serviceProvider = httpContext.RequestServices;

            //Logger-Instanz aus IOC Container
            ILogger logger = serviceProvider.GetRequiredService<ILogger<InputFormatterResult>>();

            using StreamReader reader = new StreamReader(httpContext.Request.Body, encoding);

            string nameLine = null;
            string idLine = null;


            try
            {
                //ReadLineAsync
                await ReadLineAsync("BEGIN:VCARD", reader, context, logger);
                await ReadLineAsync("VERSION:", reader, context, logger);

                nameLine = await ReadLineAsync("N:", reader, context, logger);

                string[] split = nameLine.Split(";".ToCharArray());

                Contact contact = new Contact
                {
                    LastName = split[0].Substring(2),
                    FirstName = split[1]
                };

                string fnValue = await ReadLineAsync("FN:", reader, context, logger);
                idLine = await ReadLineAsync("UID:", reader, context, logger);

                string[] splitId = idLine.Split(":");
                contact.ID = splitId[1].ToString();

                await ReadLineAsync("END:VCARD", reader, context, logger);

                logger.LogInformation($"nameLine = {nameLine}", nameLine);

                return await InputFormatterResult.SuccessAsync(contact); //contact wird in der Post-Methode als Contact Parameter ausgeliefert
            }
            catch
            {
                logger.LogInformation($"Read failed: nameLine = {nameLine}");
                return await InputFormatterResult.FailureAsync();
            }
        }


        //BEGIN:VCARD
        //VERSION:123
        //FN:Kevin
        //LN:Winter
        private static async Task<string> ReadLineAsync(string expectedText, StreamReader reader, InputFormatterContext context, ILogger logger)
        {
            string line = await reader.ReadLineAsync();

            if (!line.StartsWith(expectedText))
            {
                string errorMessage = $"Looked for '{expectedText}' and got '{line}'";

                //Fehler wird manuell angegeben
                context.ModelState.TryAddModelError(context.ModelName, errorMessage);
                logger.LogError(errorMessage);

                throw new Exception(errorMessage);
            }

            return line;
        }
    }
}
