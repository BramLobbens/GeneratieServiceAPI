# GeneratieServiceAPI

Instructions and explanations for this service.

## API Interface

### Loonbrief Request

A POST request for Loonbrief needs to specify the following non-empty parameters.

``` xml
<GenerateDocument>
	<OutputType><!-- {e.g XML} --></OutputType>
        <Parameters>
            <Name><!-- ... --></Name>
            <LastName><!-- ... --></LastName>
            <RegisterKey><!-- ... --></RegisterKey>
            <Street><!-- ... --></Street>
            <Number><!-- ... --></Number>
            <PostalCode><!-- ... --></PostalCode>
            <City><!-- ... --></City>
            <Status><!-- ... --></Status>
            <Dependents><!-- ... --></Dependents>
        </Parameters>
</GenerateDocument>
```
