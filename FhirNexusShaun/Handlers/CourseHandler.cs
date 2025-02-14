using FhirNexusShaun.Data;
using Hl7.Fhir.Model;
using Ihis.FhirEngine.Context;
using Ihis.FhirEngine.Core;
using Ihis.FhirEngine.Core.Data;
using Ihis.FhirEngine.Core.Exceptions;
using Ihis.FhirEngine.Core.Models;
using Ihis.FhirEngine.Core.Search;
using System.Net;
using Task = System.Threading.Tasks.Task;

namespace FhirNexusShaun.Handlers
{
    [FhirHandlerClass(AcceptedType = nameof(Course))]
    public class CourseHandler(ISearchService<Course> searchService, IDataService<Course> dataService, IHttpClientFactory httpClientFactory)
    {
        [FhirHandler("PreEnroll", HandlerCategory.PreCRUD, FhirInteractionType.OperationInstance, 
            CustomOperation = "enroll")]
        public async Task PreEnroll(ResourceKey resourceKey, ResourceReference trainee, FhirContext context, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Pre Enroll Start");
            Console.WriteLine("---------------------------------------------");

            // Check if the trainee is already enrolled.
            // Check if the trainee enrolled in another overlapping course.

            // debug, write the course into log.
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(trainee);
            Console.WriteLine(json);
            Console.WriteLine(resourceKey);

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Pre Enroll End");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
        }

        [FhirHandler("Enroll", HandlerCategory.CRUD, FhirInteractionType.OperationInstance, 
            CustomOperation = "enroll")]
        public async Task Enroll(ResourceKey resourceKey, ResourceReference trainee, FhirContext context, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Enroll Start");
            Console.WriteLine("---------------------------------------------");

            // debug, write the course into log.
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(trainee);
            Console.WriteLine(json);

            Console.WriteLine(resourceKey);


            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Enroll End");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
        }

        // The PostCRUD handler sends the created patient to an external endpoint.
        [FhirHandler("PostEnroll", HandlerCategory.PostCRUD, FhirInteractionType.OperationInstance, 
            CustomOperation = "enroll")]
        public async Task PostEnroll(ResourceKey resourceKey, ResourceReference trainee, IFhirContext context, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Post Enroll Start");
            Console.WriteLine("---------------------------------------------");

            using HttpClient client = httpClientFactory.CreateClient();
            // var response = await client.PostAsJsonAsync("https://httpbin.org/anything", patient);
            // response.EnsureSuccessStatusCode();

            // context.Response.AddResource();
            context.Response.StatusCode = HttpStatusCode.OK;

            OperationOutcome outcome = new OperationOutcome
            {
                Issue = new List<OperationOutcome.IssueComponent>
                {
                    new OperationOutcome.IssueComponent
                    {
                        Severity = OperationOutcome.IssueSeverity.Success,
                        Code = OperationOutcome.IssueType.Success,
                        Diagnostics = "Enrollment successful."
                    }
                }
            };

            context.Response.AddResource(outcome);

            Console.WriteLine(resourceKey);


            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Post Enroll End");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
        }
    }
}