Base url: GET http://localhost:8080/measurement/distance/{AirportCode_1}/{AirportCode_2}

Examle 1: Get distance between two airports
http://localhost:8080/measurement/distance/AMS/PEK

{
    "airportFrom": "AMS",
    "airportTo": "PEK",
    "length": 4227.790109660341,
    "measurement": "NauticalMile"
}

Examle 2: API gets can not proccedd correctly request
http://localhost:8080/measurement/distance/NONE_1/NONE_2
{
    "id": "91afec7a-5cde-4942-b59f-4d84583cc0b9",
    "datetime": "2024-03-02T14:13:04.0677775+01:00",
    "errors": [
        "Response status code does not indicate success: 400 (Bad Request)."
    ]
}

Examle 2: Network Issue
http://localhost:8080/measurement/distance/AMS/AMS

{
    "id": "f222f70d-f4cc-4fb4-9906-9be64e0451f4",
    "datetime": "2024-03-02T14:14:12.085227+01:00",
    "errors": [
        "No such host is known. (places-dev.cteleport.com:80)"
    ]
}


Settigns 

 "PlacesDev": {
    "Host": "http://places-dev.cteleport.com/airports/"
  },
  "AirportService": {
    "MeasurementUnit": 0 // NauticalMile
  }