## RealtimeTracker
Realtime Vehicle Tracker
* An easy to use web application to track vehicle in real-time. 
* GPS devices on vehicle can use the POST methode to update their position on the database once they are authenticated.
* With the google map base webpage which uses GET to refresh vehicle positions in every 5 seconds.
### POST
#### Request
url :-  /login/Addval
POST /login/Addval HTTP/1.1
Host: localhost:44328
Content-Type: application/json
Cache-Control: no-cache
{ "lat":0.999, "lon":0.9888 }
### GET
url :-  /login/mapview
response :- { "lat":0.999, "lon":0.9888 }
(Last updated loctiation ot the vehicle)
For ease of demonstration a web page is created using google map api for which we can use url as local host along with port id.
https://localhost:44328/

* Json is used for data interchanging. Since it is simple and flexible.
* Entity framework  is used for implemention of relational database
* VS - 2019
* .Net Framework : .Net Framework 4.6

