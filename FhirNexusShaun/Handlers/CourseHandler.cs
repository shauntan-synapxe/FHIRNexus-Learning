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
        [FhirHandler("PreEnroll", HandlerCategory.PreCRUD, FhirInteractionType.OperationInstance, CustomOperation = "enroll")]
        public async Task PreEnroll(ResourceKey resourceKey, ResourceReference trainee, FhirContext context, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Pre Enroll Start");
            Console.WriteLine("---------------------------------------------");

            Course course = await dataService.GetAsync<Course>(resourceKey, cancellationToken)
                ?? throw new ResourceNotFoundException(resourceKey);

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

        [FhirHandler("Enroll", HandlerCategory.CRUD, FhirInteractionType.OperationInstance, CustomOperation = "enroll")]
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

            Course course = await dataService.GetAsync<Course>(resourceKey, cancellationToken)
                ?? throw new ResourceNotFoundException(resourceKey);

            course.Trainees ??= [];
            course.Trainees.Add(trainee);

            await dataService.UpsertAsync(course, WeakETag.FromVersionId(course.VersionId), false, true, false, cancellationToken);

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

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Enroll End");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
        }
    }
}