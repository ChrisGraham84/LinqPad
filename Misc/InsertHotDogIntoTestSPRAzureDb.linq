<Query Kind="Statements">
  <Connection>
    <ID>1f1b281c-03bb-4757-a7d4-d797cd60bb59</ID>
    <Persist>true</Persist>
    <Server>sprtestdbserver.database.windows.net</Server>
    <SqlSecurity>true</SqlSecurity>
    <Database>sprtestdb1</Database>
    <UserName>cgraham</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAgXhv9L0w/0GkVV7EVuiDpgAAAAACAAAAAAAQZgAAAAEAACAAAAAZ3Okmp3WCfn48HK/QUOO+Z7Ink6z9NRhXADqwtotBlAAAAAAOgAAAAAIAACAAAADfqjxr6o01MpY3QdNil3u6TMc8c7mETb+UP996RSE8RRAAAAD7bYrmCPIvRVUJODfZdaKCQAAAAAnQMN9H0VNzSdtbQo0Vh5e5Rkf+n165+OOAmUc+hq3JNlDEzLlQ2DR/vb1bAyCzsy6Cx3mt0eKCX4uvSkXF6vA=</Password>
    <DbVersion>Azure</DbVersion>
  </Connection>
</Query>

//Items.InsertOnSubmit(new Item {Name = "Hot Dog", Description = "Tubular meat in a poppy seet bun", Insert_date = DateTime.Now});
//SubmitChanges();

(from dm in this.Mapping.GetTable(typeof(Item)).RowType.DataMembers
 select new { dm.DbType, dm.Name, dm.IsPrimaryKey, dm.IsDbGenerated }
 ).Dump();