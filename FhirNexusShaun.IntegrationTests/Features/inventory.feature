@Environment:Integration
Feature: Inventory

Background:
    And a new HttpClient as httpClient
        | HeaderName               | Value   |
        | X-Ihis-SourceApplication | testapp |

Scenario: Reading a newly created inventory resource returns exactly the same inventory
    Given a Resource is created from Samples/Inventory.json as createdInv
    When getting Inventory/{createdInv.Id} as readInv
    Then createdInv and readInv are exactly the same

Scenario: Reading a nonexistent inventory returns 404 status code
    When getting Inventory/{newguid} as readEdu
    Then readEdu is a Fhir OperationOutcome with data
        | Path       | Value |
        | statusCode | 404   |
        
Scenario: Updating a newly created inventory resource returns an inventory with an incremented versionId
    Given a Resource is created from Samples/Inventory.json as createdInv
    When updating createdInv with data as updatedInv
        | Path  | Value   | FhirType |
        | active | false | boolean   |
    And getting Inventory/{createdInv.Id}/_history/2 as readUpdatedInv
    Then updatedInv and readUpdatedInv are exactly the same
    And updatedInv is a Fhir Inventory with data
        | Path         | Value |
        | statusCode   | 200   |
        | headers.eTag | W/"2" |
    And readUpdatedInv is a Fhir Inventory with data
        | Path           | Value   | FhirType |
        | active          | false | boolean   |
        | meta.versionId | 2       | string   |
        
Scenario: Updating an inventory resource with a mismatch of id in the body and path returns 400 status code
    Given a Resource is created from Samples/Inventory.json as createdInv
    When updating createdInv with data as updatedInv
        | Path  | Value     | FhirType |
        | active | false   | boolean   |
        | id    | {newguid} | id       |
    Then updatedInv is a Fhir OperationOutcome with data
        | Path                            | Value                                                            | FhirType |
        | statusCode                      | 400                                                              |          |
        | issue[0].diagnostics            | Resource ID in resource does not match with Resource ID in path. | string   |
