# accounts-api-test

This is a simple ASP.NET Core REST API which can be used to create and get accounts.
It might be used for our website or mobile app to allow staff to create new accounts, or customers to view their account details.

## Development

### Prerequisites

* Visual Studio Code (or your favourite editor)
  * Sql Server (mssql) extension
* dotnetcore sdk 2.2
* SQL LocalDB
* HTTPie, Postman, or similar for testing

### Getting started

1. Open the directory in VS Code
2. Run the SQL initialization script `./sql/v0__init.sql` in your localdb. `Ctrl + Shift + E` is the default shortcut. Then pick `accounts-api-test` for the profile.
3. Run the API! `F5`
4. Test it out
  ```
  $ http localhost:5000/api/v1/accounts/1
  HTTP/1.1 200 OK
  Content-Type: application/json; charset=utf-8
  Date: Tue, 07 May 2019 00:37:40 GMT
  Server: Kestrel
  Transfer-Encoding: chunked

  {
      "accountId": 1,
      "contacts": [
          {
              "contactId": 1,
              "emailAddress": "steve.jobs@apple.com",
              "firstName": "Steve",
              "lastName": "Jobs",
              "mobileNumber": null,
              "phoneNumber": null,
              "role": "Billing"
          }
      ],
      "name": "Apple Inc.",
      "organisationalUnit": "Consumer"
  }
  ```