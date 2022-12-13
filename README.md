The Capture Client API is a RESTful, local API exposed through whatever port you've configured.

# SDK's
SDK's for the API can be found in the folders of this repository.
Links to the packages on NuGet, npm, etc. will be added later.

# API
The base url for all endpoints is `http://localhost:7777` (or whatever you've set the port to).

### GET /user
Gets information about your account/user.

#### Example response body
```json
{
  "credit": 5 // in USD
}
```

### POST /solve
Solves a CAPTCHA challenge for the given site.

#### Example request body
```json
{
  "type": "hcaptcha", // hcaptcha, recaptcha, funcaptcha
  "url": "https://accounts.hcaptcha.com/demo"
  "site_key": "a5f74b19-9e45-40e0-b45d-47ff91b7a6c2"
}
```

#### Example response body*
```json
{
  "solution": "captcha solution/key here"
}
```
