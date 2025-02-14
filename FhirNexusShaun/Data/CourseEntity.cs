using Hl7.Fhir.ElementModel.Types;
using Hl7.Fhir.Model;
using Ihis.FhirEngine.Data.Models;

namespace FhirNexusShaun.Data
{
    [CustomFhirResource]
    [Hl7.Fhir.Introspection.FhirType("Course", "http://hl7.org/fhir/StructureDefinition/Course", IsResource = true)]
    public class CourseEntity : ResourceEntity
    {
        public string? Title { get; set; }
        public int? Duration { get; set; }
        public DateEntity? StartDate { get; set; }
        public DateEntity? EndDate { get; set; }
        public string? Category { get; set; }
        public List<ResourceReferenceEntity>? Trainees { get; set; }
    }
}