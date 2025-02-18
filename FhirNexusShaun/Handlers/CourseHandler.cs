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
        //* -------------------------------------------------------------------
        //* Course CRUD
        //* -------------------------------------------------------------------
        [FhirHandler("PreCreate", HandlerCategory.PreCRUD, FhirInteractionType.Create)]
        public async Task PreCreate(Course input, FhirContext context, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("PreCreate Start");
            Console.WriteLine("---------------------------------------------");

            // debug, write the input into log.
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(input);
            Console.WriteLine(json);

            //* Check that duplicate course (same title and start date) exists.
            SearchResult dupCourseResults = await searchService.SearchAsync(nameof(Course), [
                ("title", input.Title),
                ("startDate", input.StartDate)
            ], false, cancellationToken);

            if (dupCourseResults.Results.Any())
            {
                throw new PreconditionFailedException("Course with the same title and start date already exists.");
            }

            //* Course must be at least 1 month later than the created date.
            DateTime startDate = DateTime.Parse(input.StartDate);
            if (startDate < DateTime.Now.AddMonths(1))
            {
                throw new PreconditionFailedException("Course must be at least 1 month later than the created date.");
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("PreCreate End");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
        }

        //* -------------------------------------------------------------------
        //* Enroll CRUD
        //* -------------------------------------------------------------------
        [FhirHandler("PreEnroll", HandlerCategory.PreCRUD, FhirInteractionType.OperationInstance, CustomOperation = "enroll")]
        public async Task PreEnroll(ResourceKey resourceKey, ResourceReference trainee, FhirContext context, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("PreEnroll Start");
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
            Console.WriteLine("PreEnroll End");
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