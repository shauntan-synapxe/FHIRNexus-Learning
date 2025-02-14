using FhirNexusShaun.Data;
using Hl7.Fhir.Model;
using Ihis.FhirEngine.Context;
using Ihis.FhirEngine.Core;
using Ihis.FhirEngine.Core.Data;
using Ihis.FhirEngine.Core.Exceptions;
using Ihis.FhirEngine.Core.Search;
using System.Net;
using Task = System.Threading.Tasks.Task;

namespace FhirNexusShaun.Handlers
{
    [FhirHandlerClass(AcceptedType = nameof(Course))]
    public class CourseHandler(ISearchService<Course> searchService, IDataService<Course> dataService, IHttpClientFactory httpClientFactory)
    {
        [FhirHandler("PreEnroll", HandlerCategory.PreCRUD, FhirInteractionType.OperationType, CustomOperation = "enroll")]
        public async Task PreEnroll(Parameters parameters, FhirContext context, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("PreEnroll Start");
            Console.WriteLine("---------------------------------------------");

            // Check if the trainee is already enrolled.
            // Check if the trainee enrolled in another overlapping course.

            // debug, write the course into log.
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(parameters);
            Console.WriteLine(json);

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("PreEnroll End");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
        }

        [FhirHandler("Enroll", HandlerCategory.CRUD, FhirInteractionType.OperationType, CustomOperation = "enroll")]
        public async Task Enroll(Parameters parameters, FhirContext context, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Enroll Start");
            Console.WriteLine("---------------------------------------------");

            // debug, write the course into log.
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(parameters);
            Console.WriteLine(json);


            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Enroll End");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
        }
    }
}