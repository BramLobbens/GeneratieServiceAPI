# GeneratieServiceAPI

Details regarding the API interface explained.

## The API Interface

### 1. Loonbrief POST  Request
* Route:
```
POST api/loonbrief
```

* Parameters:

A POST request for Loonbrief needs to specify the following non-empty parameters.

``` xml
<!-- [...] -->
<GenerateDocument>
	<OutputType><!-- {e.g XML} --></OutputType>
        <Parameters>
            <Name><!-- {...} --></Name>
            <LastName><!-- {...} --></LastName>
            <RegisterKey><!-- {...} --></RegisterKey>
            <Street><!-- {...} --></Street>
            <Number><!-- {...} --></Number>
            <PostalCode><!-- {...} --></PostalCode>
            <City><!-- {...} --></City>
            <Status><!-- {...} --></Status>
            <Dependents><!-- {...} --></Dependents>
        </Parameters>
</GenerateDocument>
<!-- [...] -->
```

### 2. Loonbrief GET  Request
A GET request can also be made using the following routes

1. Return `Content-Type: xml`
```
GET api/loonbrief
```

2. Return `Content-Type: xml`
```
GET api/loonbrief/{id}
```

3. Return `Content-Type: text\html`
```
GET api/loonbrief/html/{id}
```