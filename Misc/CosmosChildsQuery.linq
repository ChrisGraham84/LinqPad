<Query Kind="Statements">
  <Connection>
    <ID>4ab3ef1b-1742-4102-943e-6e74adb0bb0c</ID>
    <Persist>true</Persist>
    <Driver Assembly="AzureCosmosDbDriver" PublicKeyToken="no-strong-name">AzureCosmosDbDriver.Dynamic.Driver</Driver>
    <Provider>CosmosDbProvider</Provider>
    <DriverData>
      <Uri>https://localhost:8081</Uri>
      <AccountKey>C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==</AccountKey>
      <Database>Families</Database>
    </DriverData>
  </Connection>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

var fams = Families.Take(10);
//fams.Dump();
var childs = fams.Where(f => f.children.Count > 1 ).Select(x => new { x.children });
var jchild = (JArray)childs.First().children;
jchild[0].Dump();