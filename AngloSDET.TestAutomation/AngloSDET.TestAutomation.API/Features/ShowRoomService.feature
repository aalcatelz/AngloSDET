Feature: ShowRoomService
Description: This feature will test basic api ShowRoomService functionality.

Scenario Outline: GetCars_Positive
	Given request to the resource - Cars
	When user adds car type - <Type>
	And execute GET request
	Then response status code - <StatusCode>
	And all cars have type - <Type>
	Examples: 
	| Type      | StatusCode |
	| Hatchback | OK         |
	| Suv       | OK         |
	| Saloon    | OK         |

Scenario: GetCars_Negative
	Given request to the resource - Cars
	When user adds car type - Tractor
	And execute GET request
	Then response status code - NotFound